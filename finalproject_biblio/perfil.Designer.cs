namespace finalproject_biblio
{
    partial class perfil
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbphoto = new System.Windows.Forms.PictureBox();
            this.pbfav = new System.Windows.Forms.PictureBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtauthor = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.btnchange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrequest = new System.Windows.Forms.TextBox();
            this.txtnewemail = new System.Windows.Forms.TextBox();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.txtnewphone = new System.Windows.Forms.TextBox();
            this.lbleave = new System.Windows.Forms.Label();
            this.lbwarning1 = new System.Windows.Forms.Label();
            this.lbwarning2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfav)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finalproject_biblio.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 529);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbphoto
            // 
            this.pbphoto.Image = global::finalproject_biblio.Properties.Resources.noprofile;
            this.pbphoto.Location = new System.Drawing.Point(12, 104);
            this.pbphoto.Name = "pbphoto";
            this.pbphoto.Size = new System.Drawing.Size(168, 151);
            this.pbphoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbphoto.TabIndex = 1;
            this.pbphoto.TabStop = false;
            this.pbphoto.Click += new System.EventHandler(this.pbphoto_Click);
            // 
            // pbfav
            // 
            this.pbfav.Image = global::finalproject_biblio.Properties.Resources.nobook;
            this.pbfav.Location = new System.Drawing.Point(373, 262);
            this.pbfav.Name = "pbfav";
            this.pbfav.Size = new System.Drawing.Size(200, 252);
            this.pbfav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbfav.TabIndex = 2;
            this.pbfav.TabStop = false;
            this.pbfav.Click += new System.EventHandler(this.pbfav_Click);
            // 
            // txttitle
            // 
            this.txttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitle.Location = new System.Drawing.Point(208, 296);
            this.txttitle.Multiline = true;
            this.txttitle.Name = "txttitle";
            this.txttitle.ReadOnly = true;
            this.txttitle.Size = new System.Drawing.Size(159, 106);
            this.txttitle.TabIndex = 6;
            // 
            // txtauthor
            // 
            this.txtauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtauthor.Location = new System.Drawing.Point(208, 418);
            this.txtauthor.Name = "txtauthor";
            this.txtauthor.ReadOnly = true;
            this.txtauthor.Size = new System.Drawing.Size(159, 22);
            this.txtauthor.TabIndex = 7;
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(190, 104);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(187, 35);
            this.txtname.TabIndex = 8;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // txtemail
            // 
            this.txtemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(190, 190);
            this.txtemail.Name = "txtemail";
            this.txtemail.ReadOnly = true;
            this.txtemail.Size = new System.Drawing.Size(314, 35);
            this.txtemail.TabIndex = 10;
            // 
            // btnchange
            // 
            this.btnchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchange.ForeColor = System.Drawing.SystemColors.Control;
            this.btnchange.Location = new System.Drawing.Point(12, 268);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(167, 28);
            this.btnchange.TabIndex = 11;
            this.btnchange.Text = "Change Info";
            this.btnchange.UseVisualStyleBackColor = false;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Requested:";
            // 
            // txtrequest
            // 
            this.txtrequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrequest.Location = new System.Drawing.Point(317, 150);
            this.txtrequest.Name = "txtrequest";
            this.txtrequest.ReadOnly = true;
            this.txtrequest.Size = new System.Drawing.Size(60, 31);
            this.txtrequest.TabIndex = 14;
            // 
            // txtnewemail
            // 
            this.txtnewemail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnewemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewemail.Location = new System.Drawing.Point(22, 320);
            this.txtnewemail.Name = "txtnewemail";
            this.txtnewemail.Size = new System.Drawing.Size(145, 26);
            this.txtnewemail.TabIndex = 15;
            this.txtnewemail.TextChanged += new System.EventHandler(this.txtnewemail_TextChanged);
            this.txtnewemail.Enter += new System.EventHandler(this.txtnewemail_Enter);
            this.txtnewemail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnewemail_KeyPress);
            this.txtnewemail.Leave += new System.EventHandler(this.txtnewemail_Leave);
            this.txtnewemail.MouseEnter += new System.EventHandler(this.txtnewemail_MouseEnter);
            this.txtnewemail.MouseLeave += new System.EventHandler(this.txtnewemail_MouseLeave);
            // 
            // txtnewpass
            // 
            this.txtnewpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewpass.Location = new System.Drawing.Point(22, 364);
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.Size = new System.Drawing.Size(145, 26);
            this.txtnewpass.TabIndex = 16;
            this.txtnewpass.Enter += new System.EventHandler(this.txtnewpass_Enter);
            this.txtnewpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnewpass_KeyPress);
            this.txtnewpass.Leave += new System.EventHandler(this.txtnewpass_Leave);
            this.txtnewpass.MouseEnter += new System.EventHandler(this.txtnewpass_MouseEnter);
            this.txtnewpass.MouseLeave += new System.EventHandler(this.txtnewpass_MouseLeave);
            // 
            // txtnewphone
            // 
            this.txtnewphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewphone.Location = new System.Drawing.Point(22, 410);
            this.txtnewphone.Name = "txtnewphone";
            this.txtnewphone.Size = new System.Drawing.Size(145, 26);
            this.txtnewphone.TabIndex = 17;
            this.txtnewphone.Enter += new System.EventHandler(this.txtnewphone_Enter);
            this.txtnewphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnewphone_KeyPress);
            this.txtnewphone.Leave += new System.EventHandler(this.txtnewphone_Leave);
            this.txtnewphone.MouseEnter += new System.EventHandler(this.txtnewphone_MouseEnter);
            this.txtnewphone.MouseLeave += new System.EventHandler(this.txtnewphone_MouseLeave);
            // 
            // lbleave
            // 
            this.lbleave.AutoSize = true;
            this.lbleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleave.Location = new System.Drawing.Point(19, 512);
            this.lbleave.Name = "lbleave";
            this.lbleave.Size = new System.Drawing.Size(52, 16);
            this.lbleave.TabIndex = 18;
            this.lbleave.Text = "<- Back";
            this.lbleave.Click += new System.EventHandler(this.lbleave_Click);
            this.lbleave.MouseEnter += new System.EventHandler(this.lbleave_MouseEnter);
            this.lbleave.MouseLeave += new System.EventHandler(this.lbleave_MouseLeave);
            // 
            // lbwarning1
            // 
            this.lbwarning1.AutoSize = true;
            this.lbwarning1.BackColor = System.Drawing.Color.Red;
            this.lbwarning1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwarning1.ForeColor = System.Drawing.Color.White;
            this.lbwarning1.Location = new System.Drawing.Point(169, 262);
            this.lbwarning1.Name = "lbwarning1";
            this.lbwarning1.Size = new System.Drawing.Size(11, 18);
            this.lbwarning1.TabIndex = 19;
            this.lbwarning1.Text = "!";
            // 
            // lbwarning2
            // 
            this.lbwarning2.AutoSize = true;
            this.lbwarning2.BackColor = System.Drawing.Color.Red;
            this.lbwarning2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwarning2.ForeColor = System.Drawing.Color.White;
            this.lbwarning2.Location = new System.Drawing.Point(156, 410);
            this.lbwarning2.Name = "lbwarning2";
            this.lbwarning2.Size = new System.Drawing.Size(11, 18);
            this.lbwarning2.TabIndex = 20;
            this.lbwarning2.Text = "!";
            // 
            // perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 526);
            this.Controls.Add(this.lbwarning2);
            this.Controls.Add(this.lbwarning1);
            this.Controls.Add(this.lbleave);
            this.Controls.Add(this.txtnewphone);
            this.Controls.Add(this.txtnewpass);
            this.Controls.Add(this.txtnewemail);
            this.Controls.Add(this.txtrequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.txtauthor);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.pbfav);
            this.Controls.Add(this.pbphoto);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "perfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "perfil";
            this.Load += new System.EventHandler(this.perfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbphoto;
        private System.Windows.Forms.PictureBox pbfav;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtauthor;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtrequest;
        private System.Windows.Forms.TextBox txtnewemail;
        private System.Windows.Forms.TextBox txtnewpass;
        private System.Windows.Forms.TextBox txtnewphone;
        private System.Windows.Forms.Label lbleave;
        private System.Windows.Forms.Label lbwarning1;
        private System.Windows.Forms.Label lbwarning2;
    }
}