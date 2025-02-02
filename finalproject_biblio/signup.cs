using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject_biblio
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
            var pos = lbhave.Parent.PointToScreen(lbhave.Location);
            pos = pictureBox1.PointToClient(pos);
            lbhave.Parent = pictureBox1;  
            lbhave.Location = pos;  
            lbhave.BackColor = Color.Transparent;  
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;  
            lbleave.Location = pos2;  
            lbleave.BackColor = Color.Transparent;  
        }

        private void signup_Load(object sender, EventArgs e)
        {
            txtemail.Text = "Email...";
            txtpassword.Text = "Password...";
            txtname.Text = "Name...";

            for (int year = 1960; year <= DateTime.Now.Year; year++)
            {
                cbyear.Items.Add(year);
            }

            for (int month = 1; month <= 12; month++)
            {
                cbmonth.Items.Add(month);
            }

            cbmonth.Enabled = false;
            cbday.Enabled = false;
        }

        private void lbhave_Click(object sender, EventArgs e)
        {
            signin signin = new signin();
            signin.Show();
            this.Hide();
        }

        private void lbhave_MouseEnter(object sender, EventArgs e)
        {
            if (lbhave != null)
            {
                lbhave.Font = new Font(lbhave.Font, FontStyle.Underline); 
                lbhave.Cursor = Cursors.Hand; 
            }
        }

        private void lbhave_MouseLeave(object sender, EventArgs e)
        {
            if (lbhave != null)
            {
                lbhave.Font = new Font(lbhave.Font, FontStyle.Regular);
                lbhave.Cursor = Cursors.Default;
            }
        }

        private void lbleave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to leave me? 😢\nI promise I'll be good!",
                "Please don't go...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lbleave_MouseEnter(object sender, EventArgs e)
        {
            if (lbleave != null)
            {
                lbleave.Font = new Font(lbleave.Font, FontStyle.Underline);
                lbleave.Cursor = Cursors.Hand;
            }
        }

        private void lbleave_MouseLeave(object sender, EventArgs e)
        {
            if (lbleave != null)
            {
                lbleave.Font = new Font(lbleave.Font, FontStyle.Regular);
                lbleave.Cursor = Cursors.Default;
            }
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            if (txtemail.Text == "Email...")
            {
                txtemail.Text = "";
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                txtemail.Text = "Email...";
            }
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == "Name...")
            {
                txtname.Text = "";
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtname.Text = "Name...";
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password...")
            {
                txtpassword.Text = "";
                txtpassword.PasswordChar = '*';
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "Password...";
                txtpassword.PasswordChar = '\0';
            }
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            //name
            string username = txtname.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("The name cannot be empty");
                return;
            }

            //email
            string useremail = txtemail.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("The email cannot be empty");
                return;
            }
            else if (!useremail.Contains("@") && !useremail.Contains("."))
            {
                MessageBox.Show("The email need to contain '@' and '.' dont forget");
                return;
            }

            //date
            if (cbyear.SelectedItem == null || cbmonth.SelectedItem == null || cbday.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid date.");
                return;
            }
            DateTime userdate;
            try
            {
                int year = Convert.ToInt32(cbyear.SelectedItem);
                int month = Convert.ToInt32(cbmonth.SelectedItem);
                int day = Convert.ToInt32(cbday.SelectedItem);
                userdate = new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid date: {ex.Message}");
                return;
            }
            string formdate = userdate.ToString("yyyy-MM-dd");

            //password
            string userpass = txtpassword.Text;

            if (string.IsNullOrEmpty(userpass) ||
                !userpass.Any(char.IsDigit) ||
                !userpass.Any(char.IsUpper) ||
                userpass.Length < 6 ||
                userpass.Length > 20)
            {
                MessageBox.Show("The password should follow these rules:\n\n" +
                    "- Not be empty\n" +
                    "- Contain at least one number\n" +
                    "- Contain at least one uppercase letter\n" +
                    "- Be between 6 and 20 characters long");
                return;
            }

            //MessageBox.Show("Signup completed successfully!");
            MessageBox.Show($"{username} \n {userpass} \n {useremail} \n {userdate}");

            //add bd
            string query = "INSERT INTO user(name, email,password, date_birth) VALUES (@username, @useremail, @userpass, @userdate); SELECT LAST_INSERT_ID();";

            int userId = 0;

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@useremail", useremail);
                    cmd.Parameters.AddWithValue("@userpass", userpass);
                    cmd.Parameters.AddWithValue("@userdate", userdate);
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            MessageBox.Show("Connection sucessful");
            if (userId > 0)
            {
                MessageBox.Show("Welcome!!");


                guideuser guide = new guideuser
                {
                    activeuser = userId
                };
                guide.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something wrong try again later!!");
            }
        }

        private void cbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbyear.SelectedItem == null || cbmonth.SelectedItem == null) return;

            int year = Convert.ToInt32(cbyear.SelectedItem);
            int month = Convert.ToInt32(cbmonth.SelectedItem);

            int daysInMonth = DateTime.DaysInMonth(year, month);

            cbday.Items.Clear();
            for (int day = 1; day <= daysInMonth; day++)
            {
                cbday.Items.Add(day);
            }
            cbday.Enabled = true;
        }

        private void cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbmonth.Enabled = true;
            cbday.Items.Clear();
        }

        private void cbday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
