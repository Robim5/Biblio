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
using System.Xml.Linq;
using System.IO;

namespace finalproject_biblio
{
    public partial class admadd : Form
    {
        public int activeuser { get; set; }
        private Image defaultimage;
        public admadd()
        {
            InitializeComponent();
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
        }

        private void admadd_Load(object sender, EventArgs e)
        {
            LoadCategories();
            defaultimage = pbphoto.Image;
        }

        private void lbleave_Click(object sender, EventArgs e)
        {
            guideadm guide = new guideadm();
            guide.activeuser = activeuser;
            guide.Show();
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
        void LoadCategories()
        {
            string query = "SELECT id_category, name FROM categories ORDER BY id_category";

            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbcatagory.DataSource = dt;
                        cbcatagory.DisplayMember = "name";
                        cbcatagory.ValueMember = "id_category";
                    }
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //title
            string title = txttitle.Text;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("The name cannot be empty");
                return;
            }

            //author
            string author = txtauthor.Text;
            if (string.IsNullOrEmpty(author))
            {
                MessageBox.Show("The email cannot be empty");
                return;
            }

            //image
            byte[] imageBytes = null;
            if (pbphoto.Image != null && pbphoto.Image != defaultimage)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbphoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
            }
            else
            {
                MessageBox.Show("No image has been inserted yet.", "Check Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //category
            if (cbcatagory.SelectedValue == null)
            {
                MessageBox.Show("Please select a book to request.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int selectedcategory = Convert.ToInt32(cbcatagory.SelectedValue);

            //is adult or not
            bool isadult = false;
            if (rbadult.Checked)
            {
                isadult = true;
            }

            //add bd
            string query = "INSERT INTO books(title, author, category_id, image, adult) VALUES (@title, @author, @category_id, @image, @adult); SELECT LAST_INSERT_ID();";


            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@category_id", selectedcategory);
                    cmd.Parameters.AddWithValue("@image", imageBytes);
                    cmd.Parameters.AddWithValue("@adult", isadult);

                    try
                    {
                        int rowsaffected = cmd.ExecuteNonQuery();

                        if (rowsaffected > 0)
                        {
                            MessageBox.Show("The book has been successfully add!",
                                            "Book Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            guideadm guide = new guideadm();
                            guide.activeuser = activeuser;
                            guide.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while processing the request. Please try again.",
                                            "Book Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            
        }

        private void cbcatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbcatagory.SelectedValue != null)
            {
                int selectedbook = Convert.ToInt32(((DataRowView)cbcatagory.SelectedItem)["id_category"]);
            }
        }

        private void pbphoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbphoto.Image = Image.FromFile(ofd.FileName);
                    byte[] imagebyte = File.ReadAllBytes(ofd.FileName);

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The 'Adult' selection for books is not solely for content of a sexual nature. 📚✨\n\nIt also includes books aimed at a more mature audience, even though some may be suitable for younger readers. However, the primary focus is on content recommended for those aged 18 and older. 🔞\n\nIf you have any questions, feel free to contact us at bookloverssupport@biblio.com! 📩",
                "About 'Adult' Selection",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void txttitle_Enter(object sender, EventArgs e)
        {
            if (txttitle.Text == "Title...")
            {
                txttitle.Text = "";
            }
        }

        private void txttitle_Leave(object sender, EventArgs e)
        {
            if (txttitle.Text == "")
            {
                txttitle.Text = "Title...";
            }
        }

        private void txtauthor_Enter(object sender, EventArgs e)
        {
            if (txtauthor.Text == "Author...")
            {
                txtauthor.Text = "";
            }
        }

        private void txtauthor_Leave(object sender, EventArgs e)
        {
            if (txtauthor.Text == "")
            {
                txtauthor.Text = "Author...";
            }
        }
    }
}
