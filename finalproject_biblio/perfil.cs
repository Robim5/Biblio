using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace finalproject_biblio
{
    public partial class perfil : Form
    {
        public int activeuser { get; set; }
        public perfil()
        {
            InitializeComponent();
            var pos2 = lbleave.Parent.PointToScreen(lbleave.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lbleave.Parent = pictureBox1;
            lbleave.Location = pos2;
            lbleave.BackColor = Color.Transparent;
        }

        private void perfil_Load(object sender, EventArgs e)
        {
            txtnewemail.Visible = false;
            txtnewpass.Visible = false;
            txtnewphone.Visible = false;
            txtnewphone.Text = "Insert number...";
            txtnewemail.Text = "New email...";
            txtnewpass.Text = "New password...";
            UserLoad();
            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();

                string query = "SELECT phone FROM user WHERE id_user = @activeuser";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@activeuser", activeuser);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value && !string.IsNullOrWhiteSpace(result.ToString()))
                    {
                        lbwarning1.Visible = false;
                        lbwarning2.Visible = false; 
                    }
                    else
                    {
                        lbwarning1.Visible = true;
                        lbwarning2.Visible = false;
                    }
                }
            }
        }

        void UserLoad()
        {
            string query = @"SELECT 
                                   user.name, 
                                   user.email, 
                                   user.image, 
                                   COUNT(requisitions.id_requi) AS total_requests,
                                   books.title AS favorite_title,
                                   books.author AS favorite_author,
                                   books.image AS favorite_image
                                FROM 
                                   user
                                LEFT JOIN 
                                   requisitions 
                                ON 
                                   user.id_user = requisitions.user_id
                                LEFT JOIN 
                                   books 
                                ON 
                                   user.favorite = books.id_book
                                WHERE 
                                   user.id_user = @activeUser
                                GROUP BY 
                                   user.id_user;";

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
                            //user info
                            txtname.Text = reader["name"].ToString();
                            txtemail.Text = reader["email"].ToString();
                            txtrequest.Text = reader["total_requests"].ToString();
                            //photo
                            if (reader["image"] != DBNull.Value)
                            {
                                byte[] photo = (byte[])reader["image"];
                                using (MemoryStream ms = new MemoryStream(photo))
                                {
                                    pbphoto.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pbphoto.Image = null;
                            }

                            //book info
                            if (reader["favorite_title"] != DBNull.Value)
                            {
                                txttitle.Text = reader["favorite_title"].ToString();
                                txtauthor.Text = reader["favorite_author"].ToString();
                                //photo
                                if (reader["favorite_image"] != DBNull.Value)
                                {
                                    byte[] photo = (byte[])reader["favorite_image"];
                                    using (MemoryStream ms = new MemoryStream(photo))
                                    {
                                        pbfav.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pbfav.Image = null;
                                }
                            }
                            else
                            {
                                txttitle.Text = "No favorite book selected";
                                txtauthor.Text = "No author";
                                pbfav.Image = null;
                            }
                        }
                    }
                }
            }
        }

        void UpdatePhoto(byte[] photo)
        {
            string query = "UPDATE user SET image = @photo WHERE id_user = @activeuser";
            using (MySqlConnection conn = new DataCone().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@photo", photo);
                    cmd.Parameters.AddWithValue("@activeuser", activeuser);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Photo updated!");
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if(txtnewemail.Visible == true || txtnewpass.Visible == true || txtnewphone.Visible == true)
            {
                txtnewemail.Visible = false;
                txtnewpass.Visible = false;
                txtnewphone.Visible = false;
            }
            else
            {
                txtnewemail.Visible = true;
                txtnewpass.Visible = true;
                txtnewphone.Visible = true;
            }

            if(lbwarning1.Visible == true)
            {
                lbwarning2.Visible = true;
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
                    UpdatePhoto(imagebyte);
                }
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string name = txtname.Text;
                string query = "UPDATE user SET name = @name WHERE id_user = @activeuser";
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@activeuser", activeuser);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Name updated!");
                UserLoad();
            }
        }

        private void txtnewemail_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtnewemail_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void txtnewemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string email = txtnewemail.Text;
                string query = "UPDATE user SET email = @email WHERE id_user = @activeuser";
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@activeuser", activeuser);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Email updated!");
                UserLoad();
            }
        }

        private void txtnewpass_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtnewpass_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void txtnewpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string pass = txtnewpass.Text;
                if (string.IsNullOrEmpty(pass) ||
                !pass.Any(char.IsDigit) ||
                !pass.Any(char.IsUpper) ||
                pass.Length < 6 ||
                pass.Length > 20)
                {
                    MessageBox.Show("The password should follow these rules:\n\n" +
                        "- Not be empty\n" +
                        "- Contain at least one number\n" +
                        "- Contain at least one uppercase letter\n" +
                        "- Be between 6 and 20 characters long");
                    return;
                }
                string query = "UPDATE user SET password = @pass WHERE id_user = @activeuser";
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.Parameters.AddWithValue("@activeuser", activeuser);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Password updated!");
                UserLoad();
            }
        }

        private void txtnewphone_MouseEnter(object sender, EventArgs e)
        {
        }

        private void txtnewphone_MouseLeave(object sender, EventArgs e)
        {
        }

        private void txtnewphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string phone = txtnewphone.Text;
                if (!Regex.IsMatch(phone, @"^\+?\d{9,15}$"))
                {
                    MessageBox.Show("Invalid phone number. Please enter a valid number (e.g., +123123456789 or 123456789).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = "UPDATE user SET phone = @phone WHERE id_user = @activeuser";
                using (MySqlConnection conn = new DataCone().GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@activeuser", activeuser);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Phone number updated!");
                perfil perfil = new perfil();
                perfil.activeuser = activeuser;
                perfil.Show();
                this.Hide();
            }
        }

        private void txtnewemail_Enter(object sender, EventArgs e)
        {
            if (txtnewemail.Text == "New email...")
            {
                txtnewemail.Text = "";
            }
        }

        private void txtnewemail_Leave(object sender, EventArgs e)
        {
            if (txtnewemail.Text == "")
            {
                txtnewemail.Text = "New email...";
            }
        }

        private void txtnewpass_Enter(object sender, EventArgs e)
        {
            if (txtnewpass.Text == "New password...")
            {
                txtnewpass.Text = "";
            }
        }

        private void txtnewpass_Leave(object sender, EventArgs e)
        {
            if (txtnewpass.Text == "")
            {
                txtnewpass.Text = "New password...";
            }
        }

        private void txtnewphone_Enter(object sender, EventArgs e)
        {
            if (txtnewphone.Text == "Insert number...")
            {
                txtnewphone.Text = "";
            }
        }

        private void txtnewphone_Leave(object sender, EventArgs e)
        {
            if (txtnewphone.Text == "")
            {
                txtnewphone.Text = "Insert number...";
            }
        }

        private void lbleave_Click(object sender, EventArgs e)
        {
            guideuser guideuser = new guideuser();
            guideuser.activeuser = activeuser;
            guideuser.Show();
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

        private void pbfav_Click(object sender, EventArgs e)
        {

        }

        private void txtnewemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
