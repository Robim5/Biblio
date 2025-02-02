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
    public partial class guideadm : Form
    {
        public int activeuser { get; set; }
        public guideadm()
        {
            InitializeComponent();
        }

        private void guideadm_Load(object sender, EventArgs e)
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
                            string name = reader["name"].ToString();
                            txtname.Text = name;
                        }
                    }
                }
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

        private void btnchange_Click(object sender, EventArgs e)
        {
            changes chang = new changes();
            chang.activeuser = activeuser;
            chang.Show();
            this.Hide();
        }

        private void btnnewbook_Click(object sender, EventArgs e)
        {
            admadd chang = new admadd();
            chang.activeuser = activeuser;
            chang.Show();
            this.Hide();
        }

        private void btnfines_Click(object sender, EventArgs e)
        {
            admfines fines = new admfines();
            fines.activeuser = activeuser;
            fines.Show();
            this.Hide();
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            admsearch search = new admsearch();
            search.activeuser = activeuser;
            search.Show();
            this.Hide();
        }
    }
}
