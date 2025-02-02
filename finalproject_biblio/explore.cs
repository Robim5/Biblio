using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Net;


namespace finalproject_biblio
{
    public partial class explore : Form
    {
        public int activeuser { get; set; }
        private int activebook;
        public explore()
        {
            InitializeComponent();
            //var pos = lbduvida.Parent.PointToScreen(lbduvida.Location);
            //pos = pictureBox1.PointToClient(pos);
            //lbduvida.Parent = pictureBox1;
            //lbduvida.Location = pos;
            //lbduvida.BackColor = Color.Transparent;
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
            dgvbooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void explore_Load(object sender, EventArgs e)
        {
            LoadBooks("SELECT id_book, title FROM books ORDER BY id_book");
            rball.Checked = true;
        }

        
        private void lbduvida_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "⚠️ You are about to delete a fine! \n\nPlease double-check before proceeding, as this action cannot be undone. Make sure this is the right decision. 💭\n\nDo you really want to continue?",
                "Confirm Fine Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
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
            guideuser guideuser = new guideuser();
            guideuser.activeuser = activeuser;
            guideuser.Show();
            this.Hide();
        }

        void LoadImage(int bookid)
        {
            try
            {
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT image FROM books WHERE id_book = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookid);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])result;
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                ms.Seek(0, SeekOrigin.Begin);
                                pbimage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pbimage.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error_log.txt", $"{DateTime.Now}: {ex.Message}\n{ex.StackTrace}\n\n");
                MessageBox.Show($"Error loading book image: {ex.Message}");
            }
        }
        void LoadBooks(string query)
        {
            try
            {
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                        {
                            adapter.Fill(dt);
                        }
                        dgvbooks.DataSource = dt;
                        dgvbooks.Columns["id_book"].Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}");
            }
        }

        private void dgvbooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int bookid = Convert.ToInt32(dgvbooks.Rows[e.RowIndex].Cells["id_book"].Value);
                LoadImage(bookid);
            }
        }

        private void rball_CheckedChanged(object sender, EventArgs e)
        {
            if (rball.Checked)
            {
                LoadBooks("SELECT id_book, title FROM books ORDER BY id_book");
            }
        }

        private void rbonlyadult_CheckedChanged(object sender, EventArgs e)
        {
            if (rbonlyadult.Checked)
            {
                LoadBooks("SELECT id_book, title FROM books WHERE adult = 1 ORDER BY id_book");
            }
        }

        private void rbnoadult_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnoadult.Checked)
            {
                LoadBooks("SELECT id_book, title FROM books WHERE adult = 0 ORDER BY id_book");
            }
        }

        private void btnfav_Click(object sender, EventArgs e)
        {
            if (dgvbooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to mark as favorite.");
                return;
            }

            int bookid = Convert.ToInt32(dgvbooks.SelectedRows[0].Cells["id_book"].Value);

            string query = "UPDATE user SET favorite = @bookId WHERE id_user = @userId";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookId", bookid);
                    cmd.Parameters.AddWithValue("@userId", activeuser);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Book added to your favorites!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update favorite book. Please try again.");
                    }
                }
            }
        }

        private void btnreq_Click(object sender, EventArgs e)
        {
            if (dgvbooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to requisition.");
                return;
            }
            activebook = Convert.ToInt32(dgvbooks.SelectedRows[0].Cells["id_book"].Value);
            buyreq reqForm = new buyreq
            {
                activebook = this.activebook, 
                activeuser = this.activeuser 
            };
            reqForm.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string search = txtsearch.Text.Trim();

            string query = "SELECT id_book, title FROM books WHERE title LIKE @search";

            if (rbonlyadult.Checked)
            {
                query += " AND adult = 1";
            }
            else if (rbnoadult.Checked)
            {
                query += " AND adult = 0";
            }
            query += " ORDER BY id_book";

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
                        dgvbooks.DataSource = table;
                    }
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            //btnsearch_Click(sender, e);
        }
    }
}
