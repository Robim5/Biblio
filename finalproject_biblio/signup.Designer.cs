namespace finalproject_biblio
{
    partial class signup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.cbday = new System.Windows.Forms.ComboBox();
            this.cbmonth = new System.Windows.Forms.ComboBox();
            this.cbyear = new System.Windows.Forms.ComboBox();
            this.btnenter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbhave = new System.Windows.Forms.Label();
            this.lbleave = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtemail
            // 
            this.txtemail.BackColor = System.Drawing.Color.RosyBrown;
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(52, 262);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(258, 35);
            this.txtemail.TabIndex = 1;
            this.txtemail.Enter += new System.EventHandler(this.txtemail_Enter);
            this.txtemail.Leave += new System.EventHandler(this.txtemail_Leave);
            // 
            // txtname
            // 
            this.txtname.BackColor = System.Drawing.Color.Gray;
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(52, 327);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(258, 35);
            this.txtname.TabIndex = 2;
            this.txtname.Enter += new System.EventHandler(this.txtname_Enter);
            this.txtname.Leave += new System.EventHandler(this.txtname_Leave);
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(52, 482);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(258, 35);
            this.txtpassword.TabIndex = 3;
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // cbday
            // 
            this.cbday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbday.FormattingEnabled = true;
            this.cbday.Location = new System.Drawing.Point(52, 408);
            this.cbday.Name = "cbday";
            this.cbday.Size = new System.Drawing.Size(66, 32);
            this.cbday.TabIndex = 4;
            this.cbday.SelectedIndexChanged += new System.EventHandler(this.cbday_SelectedIndexChanged);
            // 
            // cbmonth
            // 
            this.cbmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmonth.FormattingEnabled = true;
            this.cbmonth.Location = new System.Drawing.Point(146, 408);
            this.cbmonth.Name = "cbmonth";
            this.cbmonth.Size = new System.Drawing.Size(92, 32);
            this.cbmonth.TabIndex = 5;
            this.cbmonth.SelectedIndexChanged += new System.EventHandler(this.cbmonth_SelectedIndexChanged);
            // 
            // cbyear
            // 
            this.cbyear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbyear.FormattingEnabled = true;
            this.cbyear.Location = new System.Drawing.Point(266, 408);
            this.cbyear.Name = "cbyear";
            this.cbyear.Size = new System.Drawing.Size(78, 32);
            this.cbyear.TabIndex = 6;
            this.cbyear.SelectedIndexChanged += new System.EventHandler(this.cbyear_SelectedIndexChanged);
            // 
            // btnenter
            // 
            this.btnenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnenter.Location = new System.Drawing.Point(91, 577);
            this.btnenter.Name = "btnenter";
            this.btnenter.Size = new System.Drawing.Size(183, 100);
            this.btnenter.TabIndex = 7;
            this.btnenter.Text = "Let´s See!";
            this.btnenter.UseVisualStyleBackColor = true;
            this.btnenter.Click += new System.EventHandler(this.btnenter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finalproject_biblio.Properties.Resources.signup;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 724);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbhave
            // 
            this.lbhave.AutoSize = true;
            this.lbhave.BackColor = System.Drawing.Color.Black;
            this.lbhave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbhave.Location = new System.Drawing.Point(111, 543);
            this.lbhave.Name = "lbhave";
            this.lbhave.Size = new System.Drawing.Size(145, 15);
            this.lbhave.TabIndex = 8;
            this.lbhave.Text = "I already have an account";
            this.lbhave.Click += new System.EventHandler(this.lbhave_Click);
            this.lbhave.MouseEnter += new System.EventHandler(this.lbhave_MouseEnter);
            this.lbhave.MouseLeave += new System.EventHandler(this.lbhave_MouseLeave);
            // 
            // lbleave
            // 
            this.lbleave.AutoSize = true;
            this.lbleave.BackColor = System.Drawing.Color.Black;
            this.lbleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbleave.Location = new System.Drawing.Point(153, 697);
            this.lbleave.Name = "lbleave";
            this.lbleave.Size = new System.Drawing.Size(54, 15);
            this.lbleave.TabIndex = 9;
            this.lbleave.Text = "<- Leave";
            this.lbleave.Click += new System.EventHandler(this.lbleave_Click);
            this.lbleave.MouseEnter += new System.EventHandler(this.lbleave_MouseEnter);
            this.lbleave.MouseLeave += new System.EventHandler(this.lbleave_MouseLeave);
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 721);
            this.Controls.Add(this.lbleave);
            this.Controls.Add(this.lbhave);
            this.Controls.Add(this.btnenter);
            this.Controls.Add(this.cbyear);
            this.Controls.Add(this.cbmonth);
            this.Controls.Add(this.cbday);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signup";
            this.Load += new System.EventHandler(this.signup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.ComboBox cbday;
        private System.Windows.Forms.ComboBox cbmonth;
        private System.Windows.Forms.ComboBox cbyear;
        private System.Windows.Forms.Button btnenter;
        private System.Windows.Forms.Label lbhave;
        private System.Windows.Forms.Label lbleave;
    }
}