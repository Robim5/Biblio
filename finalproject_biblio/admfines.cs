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
    public partial class admfines : Form
    {
        public int activeuser { get; set; }
        public admfines()
        {
            InitializeComponent();
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
            dgvfines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void admfines_Load(object sender, EventArgs e)
        {
            string query = @"SELECT  
                                 f.id_fine,  
                                 u.id_user, 
                                 u.name AS user_name,  
                                 f.cost,  
                                 r.date_limit AS date_given,  
                                 f.date_delivered  
                             FROM fines f  
                             JOIN user u ON f.user_id = u.id_user  
                             JOIN requisitions r ON f.book_id = r.book_id AND f.user_id = r.user_id  
                             ORDER BY f.id_fine;"
            ;
            LoadFines(query);
        }

        void LoadFines(string query)
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
                        dgvfines.DataSource = dt;
                        dgvfines.Columns["id_fine"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading fines: {ex.Message}");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string search = txtsearch.Text.Trim();

            string query = @"SELECT  
                                 f.id_fine,  
                                 u.id_user,
                                 u.name AS user_name,  
                                 f.cost,  
                                 r.date_limit AS date_given,  
                                 f.date_delivered  
                             FROM fines f  
                             JOIN user u ON f.user_id = u.id_user  
                             JOIN requisitions r ON f.book_id = r.book_id AND f.user_id = r.user_id  
                             WHERE u.name LIKE @search  
                             ORDER BY f.id_fine;"
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
                        dgvfines.DataSource = table;
                    }
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvfines.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a fine to delete.");
                return;
            }

            int fineid = Convert.ToInt32(dgvfines.SelectedRows[0].Cells["id_fine"].Value);
            int userid = Convert.ToInt32(dgvfines.SelectedRows[0].Cells["id_user"].Value);
            string nameuser = dgvfines.SelectedRows[0].Cells["user_name"].Value.ToString();

            DialogResult confirm1 = MessageBox.Show($"Are you sure you want to delete {nameuser}'s fine?",
                                                      "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm1 == DialogResult.Yes)
            {
                DialogResult confirm2 = MessageBox.Show($"This action is irreversible! The fine for {nameuser} will be deleted.",
                                                          "Last Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm2 == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new DataCone().GetConnection())
                    {
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string deletefines = "DELETE FROM fines WHERE id_fine = @fineid";
                            using (MySqlCommand cmd = new MySqlCommand(deletefines, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@fineid", fineid);
                                cmd.ExecuteNonQuery();
                            }
                            string lessfines = "UPDATE user SET fines = IFNULL(fines, 0) - 1 WHERE id_user = @userId";
                            using (MySqlCommand cmd = new MySqlCommand(lessfines, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@userId", userid);
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show($"The fine for {nameuser} has been successfully deleted!",
                                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            admfines_Load(null, null);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error deleting the fine: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dgvfines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int fineid = Convert.ToInt32(dgvfines.Rows[e.RowIndex].Cells["id_fine"].Value);
            }
        }

        private void lbleave_Click(object sender, EventArgs e)
        {
            guideadm guideadm = new guideadm();
            guideadm.activeuser = activeuser;
            guideadm.Show();
            this.Hide();
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

       
    }
}
