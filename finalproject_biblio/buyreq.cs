using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject_biblio
{
    public partial class buyreq : Form
    {
        public int activeuser { get; set; }
        public int activebook { get; set; }
        public buyreq()
        {
            InitializeComponent();
        }

        private void buyreq_Load(object sender, EventArgs e)
        {
            LoadBooks();
            if (activebook > 0)
            {
                for (int i = 0; i < cbname.Items.Count; i++)
                {
                    if (Convert.ToInt32(((DataRowView)cbname.Items[i])["id_book"]) == activebook)
                    {
                        cbname.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        void LoadBooks()
        {
            string query = "SELECT id_book, title FROM books ORDER BY id_book";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbname.DataSource = dt;
                        cbname.DisplayMember = "title";
                        cbname.ValueMember = "id_book";
                    }
                }
            }
        }

        void LoadBookDetails(int bookid)
        {
            string query = "SELECT title, author, image FROM books WHERE id_book = @bookid";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookid", bookid);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtautor.Text = dr["author"].ToString();
                            byte[] imageData = (byte[])dr["image"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pbphoto.Image = Image.FromStream(ms);
                            }
                            DateTime dueDate = DateTime.Now.AddMonths(2);
                            txtdate.Text = dueDate.ToString("yyyy-MM-dd");
                        }
                    }
                }
            }
        }

        private void cbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbname.SelectedValue != null)
            {
                int selectedbook = Convert.ToInt32(((DataRowView)cbname.SelectedItem)["id_book"]);
                LoadBookDetails(selectedbook);
            }
        }

        private int RandomStoreId()
        {
            int minid = 0;
            int maxid = 0;

            string query = "SELECT MIN(id_store) AS minid, MAX(id_store) AS maxid FROM stores";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            minid = reader.GetInt32("minid");
                            maxid = reader.GetInt32("maxid");
                        }
                    }
                }
            }

            if (minid == 0 && maxid == 0)
            {
                throw new Exception("No stores found in the database!");
            }

            Random random = new Random();
            return random.Next(minid, maxid + 1);
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (cbname.SelectedValue == null)
            {
                MessageBox.Show("Please select a book to request.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //random store because we don't have real stores to do this
            int storeid = RandomStoreId();
            int selectedbook = Convert.ToInt32(cbname.SelectedValue);
            DateTime requestdate = DateTime.Now;
            DateTime duedate = requestdate.AddMonths(2);

            string query = "INSERT INTO requisitions (user_id, book_id, store_id, date_requi, date_limit, returned)" +
                           "VALUES (@userid, @bookid, @storeid, @requestdate, @duedate, @returned)";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", activeuser);
                    cmd.Parameters.AddWithValue("@bookid", selectedbook);
                    cmd.Parameters.AddWithValue("@storeid", storeid);
                    cmd.Parameters.AddWithValue("@requestdate", requestdate);
                    cmd.Parameters.AddWithValue("@duedate", duedate);
                    cmd.Parameters.AddWithValue("@returned", false);

                    try
                    {
                        int rowsaffected = cmd.ExecuteNonQuery();

                        if (rowsaffected > 0)
                        {
                            MessageBox.Show("The book has been successfully requested. You can pick it up at the nearest library.",
                                            "Request Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while processing the request. Please try again.",
                                            "Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            guideuser guideuser = new guideuser();
            guideuser.activeuser = activeuser;
            guideuser.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            guideuser guideuser = new guideuser();
            guideuser.activeuser = activeuser;
            guideuser.Show();
            this.Hide();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            if (label2 != null)
            {
                label2.Font = new Font(label2.Font, FontStyle.Underline);
                label2.Cursor = Cursors.Hand;
            }
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            if (label2 != null)
            {
                label2.Font = new Font(label2.Font, FontStyle.Regular);
                label2.Cursor = Cursors.Default;
            }
        }
    }
}
