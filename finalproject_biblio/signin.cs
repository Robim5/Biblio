using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject_biblio
{
    public partial class signin : Form
    {
        string connectionString = "Server=localhost;Database=biblio;Uid=root;Pwd=mysql;";
        public signin()
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

        private void signin_Load(object sender, EventArgs e)
        {
            txtemail.Text = "Email...";
            txtpassword.Text = "Password...";
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

        private void lbhave_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.Show();
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
            string useremail = txtemail.Text;
            string userpassword = txtpassword.Text;


            if (string.IsNullOrEmpty(useremail) || string.IsNullOrEmpty(userpassword))
            {
                MessageBox.Show("The email and/or password cannot be empty!!");
                return;
            }

            int userId = -1;
            bool isAdmin = false;

            string query = "SELECT id_user, is_adm FROM user WHERE email = @useremail AND password = @userpass";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@useremail", useremail);
                    cmd.Parameters.AddWithValue("@userpass", userpassword);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32("id_user");
                            isAdmin = reader.GetBoolean("is_adm");
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                            return;
                        }
                    }
                }
            }

            if (userId > 0)
            {
                if (isAdmin)
                {
                    MessageBox.Show("Welcome, Admin!");
                    guideadm adminForm = new guideadm();
                    adminForm.activeuser = userId;
                    adminForm.Show();
                }
                else
                {
                    MessageBox.Show("Welcome again!");
                    guideuser guide = new guideuser();
                    guide.activeuser = userId;
                    guide.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again later!");
            }
        }
    }
}
