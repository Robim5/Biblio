using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject_biblio
{
    public partial class guideuser : Form
    {

        public int activeuser { get; set; }
        public guideuser()
        {
            InitializeComponent();
            var pos = lbduvida.Parent.PointToScreen(lbduvida.Location);
            pos = pictureBox1.PointToClient(pos);
            lbduvida.Parent = pictureBox1;
            lbduvida.Location = pos;
            lbduvida.BackColor = Color.Transparent;
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
        }

        private void guideuser_Load(object sender, EventArgs e)
        {
            string query = "SELECT name FROM user WHERE id_user= @activeuser";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@activeuser", activeuser);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //load name
                            string name = reader["name"].ToString();
                            txtname.Text = name;
                        }
                    }
                }
            }

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();

                string query2 = "SELECT phone FROM user WHERE id_user = @activeuser";
                using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                {
                    cmd.Parameters.AddWithValue("@activeuser", activeuser);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value && !string.IsNullOrWhiteSpace(result.ToString()))
                    {
                        lbwarning1.Visible = false;
                    }
                    else
                    {
                        lbwarning1.Visible = true;
                    }
                }
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

        private void lbduvida_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Welcome! 🌟 We're so happy to have you here! 💖\nTake your time exploring, and we hope you enjoy every moment! 😊\n\nIf you have any questions, feel free to reach out at supportbooks@biblio.com! 📩",
                "Hello there! 🥰",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnexplore_Click(object sender, EventArgs e)
        {
            explore exp = new explore();
            exp.activeuser = activeuser;
            exp.Show();
            this.Hide();
        }

        private void btnrequest_Click(object sender, EventArgs e)
        {
            buyreq req = new buyreq();
            req.activeuser = activeuser;
            req.Show();
            this.Hide();
        }

        private void btnsee_Click(object sender, EventArgs e)
        {
            perfil perf = new perfil();
            perf.activeuser = activeuser;
            perf.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
