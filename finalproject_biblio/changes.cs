using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
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
using System.Xml.Linq;

namespace finalproject_biblio
{
    public partial class changes : Form
    {
        public int activeuser { get; set; }
        public Image defaultdelbook;
        public Image defaulteditbook;
        public Image defaultprof;
        public changes()
        {
            InitializeComponent();
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
        }

        private void changes_Load(object sender, EventArgs e)
        {
            pnaddfine.Visible = false;
            pndelete.Visible = false;
            pnedit.Visible = false;

            defaultdelbook = pbdelbook.Image;
            defaulteditbook = pbbookedit.Image;
            defaultprof = pbprofile.Image;

            //EDIT AREA ----------------------------
            LoadBooks();
            LoadCategories();

            //DELETE AREA -------------------------------- 
            LoadBooksDel();

            //ADD AREA -----------------------------
            LoadUsers();
            for (int year = 2020; year <= DateTime.Now.Year; year++)
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

        private void txtstock_TextChanged(object sender, EventArgs e)
        {

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

        private void btneditbook_Click(object sender, EventArgs e)
        {
            pnaddfine.Visible = false;
            pndelete.Visible = false;
            pnedit.Visible = true;
        }

        private void btndeletebook_Click(object sender, EventArgs e)
        {
            pnaddfine.Visible = false;
            pndelete.Visible = true;
            pnedit.Visible = false;
        }

        private void btnaddfine_Click(object sender, EventArgs e)
        {
            pnaddfine.Visible = true;
            pndelete.Visible = false;
            pnedit.Visible = false;
        }


        //EDIT AREA -----------------------------------------------------
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (cbbook.SelectedValue == null)
            {
                MessageBox.Show("Please select a book to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int bookid = Convert.ToInt32(cbbook.SelectedValue);
            string newtitle = txttitle.Text;
            string newauthor = txtauthor.Text;
            int categoryId = Convert.ToInt32(cbcategory.SelectedValue);
            //MessageBox.Show("CATEGORY ID: " + categoryId);
            string store = cbstore.SelectedItem?.ToString();
            int stock = int.TryParse(txtstock.Text, out int s) ? s : 0;
            bool isAdult = rbadult.Checked;
            byte[] imageBytes = null;
            if (pbbookedit.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(pbbookedit.Image))
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    imageBytes = ms.ToArray();
                }
            }

            string queryBooks = @"UPDATE books 
                                  SET title = @title, 
                                      author = @author, 
                                      category_id = @categoryid, 
                                      adult = @adult, 
                                      image = @image
                                  WHERE id_book = @bookid";


            string queryStores = @"UPDATE stores 
                                   SET available = @stock 
                                   WHERE book_id = @bookid AND name_store = @store";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(queryBooks, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@title", newtitle);
                            cmd.Parameters.AddWithValue("@author", newauthor);
                            cmd.Parameters.AddWithValue("@categoryid", categoryId);
                            cmd.Parameters.AddWithValue("@adult", isAdult);
                            cmd.Parameters.AddWithValue("@image", imageBytes ?? (object)DBNull.Value);
                            cmd.Parameters.AddWithValue("@bookid", bookid);
                            cmd.ExecuteNonQuery();
                        }
                        if (!string.IsNullOrEmpty(store))
                        {
                            using (MySqlCommand cmd = new MySqlCommand(queryStores, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@stock", stock);
                                cmd.Parameters.AddWithValue("@store", store);
                                cmd.Parameters.AddWithValue("@bookid", bookid);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show("The book details have been updated successfully.", "Update Successful",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        guideadm guideadm = new guideadm();
                        guideadm.activeuser = activeuser;
                        guideadm.Show();
                        this.Hide();
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred: " + ex.Message, "Database Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void LoadCategories()
        {
            string query = "SELECT id_category, name FROM categories ORDER BY name";
            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cbcategory.DataSource = dt;
                    cbcategory.DisplayMember = "name";
                    cbcategory.ValueMember = "id_category";
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

                        cbbook.DataSource = dt;
                        cbbook.DisplayMember = "title";
                        cbbook.ValueMember = "id_book";
                    }
                }
            }
        }
        void LoadBookDetails(int bookid)
        {
            string query = @"SELECT 
                                  b.title, 
                                  b.author, 
                                  b.image, 
                                  b.adult, 
                                  c.id_category,
                                  c.name AS category_name, 
                                  s.name_store, 
                                  s.available
                              FROM books b
                              LEFT JOIN categories c ON b.category_id = c.id_category
                              LEFT JOIN stores s ON b.id_book = s.book_id
                              WHERE b.id_book = @bookid"
            ;
            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookid", bookid);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        cbstore.Items.Clear();
                        if (dr.Read())
                        {
                            txttitle.Text = dr["title"].ToString();
                            txtauthor.Text = dr["author"].ToString();

                            if (dr["image"] != DBNull.Value)
                            {
                                try
                                {
                                    byte[] imageData = (byte[])dr["image"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        pbbookedit.Image = Image.FromStream(ms);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error uploading image: " + ex.Message);
                                }
                            }
                            else
                            {
                                pbbookedit.Image = defaulteditbook;
                            }


                            if (dr["id_category"] != DBNull.Value)
                            {
                                int catId = Convert.ToInt32(dr["id_category"]);
                                cbcategory.SelectedValue = catId;
                            }
                            else
                            {
                                cbcategory.SelectedIndex = -1;
                            }

                            while (dr.Read())
                            {
                                if (dr["name_store"] != DBNull.Value)
                                {
                                    string storename = dr["name_store"].ToString();
                                    cbstore.Items.Add(storename);
                                }
                                //string storename = dr["name_store"].ToString();
                                //cbstore.Items.Add(storename);
                            }
                            if (cbstore.Items.Count == 0)
                            {
                                cbstore.Items.Add("N/A");
                                cbstore.SelectedIndex = 0;
                                txtstock.Text = "N/A";
                            }
                            else
                            {
                                cbstore.SelectedIndex = 0;
                                if (dr["available"] != DBNull.Value)
                                {
                                    txtstock.Text = dr["available"].ToString();
                                }
                                else
                                {
                                    txtstock.Text = "N/A";
                                }
                            }


                            if (dr["adult"] != DBNull.Value)
                            {
                                bool isAdult = Convert.ToBoolean(dr["adult"]);
                                rbadult.Checked = isAdult;
                            }
                            else
                            {
                                rbadult.Checked = false;
                            }
                        }
                    }
                }
            }
        }

        private void cbbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbook.SelectedValue != null)
            {
                int selectedbook = Convert.ToInt32(((DataRowView)cbbook.SelectedItem)["id_book"]);
                LoadBookDetails(selectedbook);
            }
        }

        private void pbbookedit_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbbookedit.Image = Image.FromFile(ofd.FileName);
                    byte[] imagebyte = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        private void cbstore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbstore.SelectedItem != null && cbbook.SelectedValue != null)
            {
                int bookid = Convert.ToInt32(((DataRowView)cbbook.SelectedItem)["id_book"]);
                string store = cbstore.SelectedItem.ToString();

                string query = @"SELECT available FROM stores WHERE book_id = @bookid AND name_store = @store";

                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookid", bookid);
                        cmd.Parameters.AddWithValue("@store", store);
                        object result = cmd.ExecuteScalar();

                        txtstock.Text = result != null ? result.ToString() : "N/A";
                    }
                }
            }
        }

        //DELETE BOOK AREA -----------------------------------

        void LoadBooksDel()
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

                        cbdelbook.DataSource = dt;
                        cbdelbook.DisplayMember = "title";
                        cbdelbook.ValueMember = "id_book";
                    }
                }
            }
        }

        void LoadDelBookDetails(int bookid)
        {
            string query = @"SELECT 
                                 b.title, 
                                 b.author, 
                                 b.image,
                                 c.name AS category_name, 
                                 s.name_store, 
                                 s.available
                             FROM books b
                             LEFT JOIN categories c ON b.category_id = c.id_category
                             LEFT JOIN stores s ON b.id_book = s.book_id
                             WHERE b.id_book = @bookid"
            ;
            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookid", bookid);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        cbdelstore.Items.Clear();
                        if (dr.Read())
                        {
                            txtdeltitle.Text = dr["title"].ToString();
                            txtdelauthor.Text = dr["author"].ToString();
                            if (dr["image"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])dr["image"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pbdelbook.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pbdelbook.Image = defaultdelbook;
                            }
                            if (dr["category_name"] != DBNull.Value)
                            {
                                txtcategory.Text = dr["category_name"].ToString();
                            }
                            while (dr.Read())
                            {
                                if (dr["name_store"] != DBNull.Value)
                                {
                                    string storename = dr["name_store"].ToString();
                                    cbdelstore.Items.Add(storename);
                                }
                                //string storename = dr["name_store"].ToString();
                                //cbstore.Items.Add(storename);
                            }
                            if (cbdelstore.Items.Count == 0)
                            {
                                cbdelstore.Items.Add("N/A");
                                cbdelstore.SelectedIndex = 0;
                                txtdelstock.Text = "N/A";
                            }
                            else
                            {
                                cbdelstore.SelectedIndex = 0;
                                if (dr["available"] != DBNull.Value)
                                {
                                    txtdelstock.Text = dr["available"].ToString();
                                }
                                else
                                {
                                    txtdelstock.Text = "N/A";
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btndelbook_Click(object sender, EventArgs e)
        {
            if(cbdelbook.SelectedValue == null)
            {
                MessageBox.Show("Select a book to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookid = Convert.ToInt32(cbdelbook.SelectedValue);
            string bookTitle = cbdelbook.Text;

            DialogResult confirm1 = MessageBox.Show($"Are you sure you want to delete '{bookTitle}'? \nThis action will remove all information from the book.",
                                                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm1 == DialogResult.Yes)
            {
                DialogResult confirm2 = MessageBox.Show($"This action is irreversible! The book '{bookTitle}', its requests, tickets and favorites will be deleted.\nWant to continue?",
                                                        "Last Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm2 == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new DataCone().GetConnection())
                    {
                        conn.Open();
                        MySqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string deleterequisitions = "DELETE FROM requisitions WHERE book_id = @bookid";
                            using (MySqlCommand cmd = new MySqlCommand(deleterequisitions, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@bookid", bookid);
                                cmd.ExecuteNonQuery();
                            }
                            string deletefines = "DELETE FROM fines WHERE book_id = @bookid";
                            using (MySqlCommand cmd = new MySqlCommand(deletefines, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@bookid", bookid);
                                cmd.ExecuteNonQuery();
                            }
                            string updatefavorites = "UPDATE user SET favorite = NULL WHERE favorite = @bookid";
                            using (MySqlCommand cmd = new MySqlCommand(updatefavorites, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@bookid", bookid);
                                cmd.ExecuteNonQuery();
                            }
                            string deletestores = "DELETE FROM stores WHERE book_id = @bookid";
                            using (MySqlCommand cmd = new MySqlCommand(deletestores, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@bookid", bookid);
                                cmd.ExecuteNonQuery();
                            }
                            string deletebook = "DELETE FROM books WHERE id_book = @bookid";
                            using (MySqlCommand cmd = new MySqlCommand(deletebook, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@bookid", bookid);
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                            MessageBox.Show($"The book '{bookTitle}' has been successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            guideadm guideadm = new guideadm();
                            guideadm.activeuser = activeuser;
                            guideadm.Show();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error deleting the book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void cbdelbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbdelbook.SelectedValue != null)
            {
                int selectedbook = Convert.ToInt32(((DataRowView)cbdelbook.SelectedItem)["id_book"]);
                LoadDelBookDetails(selectedbook);
            }
        }
        private void cbdelstore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbstore.SelectedItem != null && cbbook.SelectedValue != null)
            {
                int bookid = Convert.ToInt32(cbbook.SelectedValue);
                string store = cbstore.SelectedItem.ToString();

                string query = @"SELECT available FROM stores WHERE book_id = @bookid AND name_store = @store";

                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookid", bookid);
                        cmd.Parameters.AddWithValue("@store", store);
                        object result = cmd.ExecuteScalar();

                        txtdelstock.Text = result != null ? result.ToString() : "N/A";
                    }
                }
            }
        }


        //ADD FINE AREA --------------------------------
        void LoadUsers()
        {
            string query = "SELECT id_user, name FROM user WHERE is_adm = 0 ORDER BY id_user";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbuser.DataSource = dt;
                        cbuser.DisplayMember = "name";
                        cbuser.ValueMember = "id_user";
                    }
                }
            }
        }
        void LoadUsersDetails(int userid)
        {
            string query = @"SELECT name, email, phone, image FROM user WHERE id_user = @userid";
            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userid);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtname.Text = dr["name"].ToString();
                            txtemail.Text = dr["email"].ToString();
                            if (dr["phone"] != DBNull.Value)
                            {
                                txtphone.Text = dr["phone"].ToString();
                            }
                            else
                            {
                                txtphone.Text = "No phone number";
                            }
                            if (dr["image"] != DBNull.Value)
                            {
                                byte[] imageData = (byte[])dr["image"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pbprofile.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pbprofile.Image = defaultprof;
                            }

                        }
                    }
                }
            }
        }
        void LoadUserBooks(int userid)
        {
            string query = @"SELECT r.book_id, b.title FROM requisitions r INNER JOIN books b ON r.book_id = b.id_book WHERE r.user_id = @userid";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userid);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbuserbook.DataSource = dt;
                        cbuserbook.DisplayMember = "title";
                        cbuserbook.ValueMember = "book_id";
                    }
                }
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cbuser.SelectedValue == null || cbuserbook.SelectedValue == null || string.IsNullOrWhiteSpace(txtcost.Text))
            {
                MessageBox.Show("Fill in all the required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userid = Convert.ToInt32(cbuser.SelectedValue);
            int bookid = Convert.ToInt32(cbuserbook.SelectedValue);
            double cost;

            if (!double.TryParse(txtcost.Text, out cost))
            {
                MessageBox.Show("The amount of the fine must be a valid number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? dateDelivered = null;
            if (cbyear.SelectedItem != null && cbmonth.SelectedItem != null && cbday.SelectedItem != null)
            {
                int year = Convert.ToInt32(cbyear.SelectedItem);
                int month = Convert.ToInt32(cbmonth.SelectedItem);
                int day = Convert.ToInt32(cbday.SelectedItem);
                dateDelivered = new DateTime(year, month, day);
            }
            DateTime dateFine = DateTime.Now;

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryLimit = "SELECT date_limit FROM requisitions WHERE user_id = @userid AND book_id = @bookid";
                        DateTime dataLimit;

                        using (MySqlCommand cmd = new MySqlCommand(queryLimit, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userid", userid);
                            cmd.Parameters.AddWithValue("@bookid", bookid);
                            object result = cmd.ExecuteScalar();
                            if (result == null)
                            {
                                MessageBox.Show("Error searching for the request deadline!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            dataLimit = Convert.ToDateTime(result);
                        }

                        string insertFine = @"INSERT INTO fines (user_id, book_id, cost, date_given, date_delivered, date_fine) VALUES (@userId, @bookId, @cost, @dateGiven, @dateDelivered, @dateFine)";

                        using (MySqlCommand cmd = new MySqlCommand(insertFine, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userid);
                            cmd.Parameters.AddWithValue("@bookId", bookid);
                            cmd.Parameters.AddWithValue("@cost", cost);
                            cmd.Parameters.AddWithValue("@dateGiven", dataLimit);
                            cmd.Parameters.AddWithValue("@dateDelivered", (object)dateDelivered ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@dateFine", dateFine);
                            cmd.ExecuteNonQuery();
                        }

                        string updateUserFines = "UPDATE user SET fines = IFNULL(fines, 0) + 1 WHERE id_user = @userId";
                        using (MySqlCommand cmd = new MySqlCommand(updateUserFines, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userid);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Fine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        guideadm guideadm = new guideadm();
                        guideadm.activeuser = activeuser;
                        guideadm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error adding fine: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void cbuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbuser.SelectedValue != null)
            {
                int selecteduser = Convert.ToInt32(((DataRowView)cbuser.SelectedItem)["id_user"]);
                LoadUsersDetails(selecteduser);
                LoadUserBooks(selecteduser);
            }
        }

        private void cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbmonth.Enabled = true;
            cbday.Items.Clear();
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

        private void cbday_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "If the delivery date fields are left empty, the date will be set to NULL, meaning the book has not been returned.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
