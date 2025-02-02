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
    public partial class admsearch : Form
    {
        public int activeuser { get; set; }
        public admsearch()
        {
            InitializeComponent();
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
            dgvcust.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            guideadm guideadm = new guideadm();
            guideadm.activeuser = activeuser;
            guideadm.Show();
            this.Hide();
        }


        private void admsearch_Load(object sender, EventArgs e)
        {
            string query = @"SELECT  
                                u.id_user,  
                                u.name AS user_name, 
                                u.email,
                                u.fines AS user_fines,
                                COUNT(r.id_requi) AS total_requisitions
                            FROM user u
                            LEFT JOIN requisitions r ON u.id_user = r.user_id
                            WHERE u.is_adm = 0
                            GROUP BY u.id_user
                            ORDER BY u.id_user;"
            ;
            LoadUsers(query);
        }

        void LoadUsers(string query)
        {
            try
            {
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                        dgvcust.DataSource = dt;
                        dgvcust.Columns["id_user"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }


        private void btnsearch_Click(object sender, EventArgs e)
        {
            string search = txtsearch.Text.Trim();

            string query = @"SELECT  
                                u.id_user,  
                                u.name AS user_name, 
                                u.email,
                                u.fines AS user_fines,
                                COUNT(r.id_requi) AS total_requisitions
                            FROM user u
                            LEFT JOIN requisitions r ON u.id_user = r.user_id
                            WHERE u.is_adm = 0 AND u.name LIKE @search  
                            GROUP BY u.id_user
                            ORDER BY u.id_user;"
            ;

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", $"%{search}%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvcust.DataSource = table;
                    }
                }
            }
        }

        

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvcust.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            int userid = Convert.ToInt32(dgvcust.SelectedRows[0].Cells["id_user"].Value);
            string nameuser = dgvcust.SelectedRows[0].Cells["user_name"].Value.ToString();

            DialogResult confirm1 = MessageBox.Show($"Are you sure you want to delete user: {nameuser}?",
                                                      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm1 == DialogResult.Yes)
            {
                DialogResult confirm2 = MessageBox.Show($"This action is irreversible! The user {nameuser} will be deleted.",
                                                          "Last Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm2 == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new DataCone().GetConnection())
                    {
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string deleteuser = "DELETE FROM user WHERE id_user = @userid";
                            using (MySqlCommand cmd = new MySqlCommand(deleteuser, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@userid", userid);
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show($"The user {nameuser} has been successfully deleted!",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            admsearch_Load(null, null);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error deleting the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvcust_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int userid = Convert.ToInt32(dgvcust.Rows[e.RowIndex].Cells["id_user"].Value);
            }
        }
        private void dgvcust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


    }
}
