namespace finalproject_biblio
{
    partial class admadd
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
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtauthor = new System.Windows.Forms.TextBox();
            this.lbleave = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.cbcatagory = new System.Windows.Forms.ComboBox();
            this.rbadult = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finalproject_biblio.Properties.Resources.addbook;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 673);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbphoto
            // 
            this.pbphoto.Image = global::finalproject_biblio.Properties.Resources.nobook;
            this.pbphoto.Location = new System.Drawing.Point(131, 214);
            this.pbphoto.Name = "pbphoto";
            this.pbphoto.Size = new System.Drawing.Size(213, 265);
            this.pbphoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbphoto.TabIndex = 1;
            this.pbphoto.TabStop = false;
            this.pbphoto.Click += new System.EventHandler(this.pbphoto_Click);
            // 
            // txttitle
            // 
            this.txttitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttitle.Location = new System.Drawing.Point(47, 109);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(384, 31);
            this.txttitle.TabIndex = 2;
            this.txttitle.Enter += new System.EventHandler(this.txttitle_Enter);
            this.txttitle.Leave += new System.EventHandler(this.txttitle_Leave);
            // 
            // txtauthor
            // 
            this.txtauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtauthor.Location = new System.Drawing.Point(47, 163);
            this.txtauthor.Name = "txtauthor";
            this.txtauthor.Size = new System.Drawing.Size(384, 31);
            this.txtauthor.TabIndex = 3;
            this.txtauthor.Enter += new System.EventHandler(this.txtauthor_Enter);
            this.txtauthor.Leave += new System.EventHandler(this.txtauthor_Leave);
            // 
            // lbleave
            // 
            this.lbleave.AutoSize = true;
            this.lbleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleave.Location = new System.Drawing.Point(12, 651);
            this.lbleave.Name = "lbleave";
            this.lbleave.Size = new System.Drawing.Size(63, 20);
            this.lbleave.TabIndex = 4;
            this.lbleave.Text = "<- Back";
            this.lbleave.Click += new System.EventHandler(this.lbleave_Click);
            this.lbleave.MouseEnter += new System.EventHandler(this.lbleave_MouseEnter);
            this.lbleave.MouseLeave += new System.EventHandler(this.lbleave_MouseLeave);
            // 
            // btnadd
            // 
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(131, 560);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(212, 91);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "Add Book";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cbcatagory
            // 
            this.cbcatagory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbcatagory.FormattingEnabled = true;
            this.cbcatagory.Location = new System.Drawing.Point(86, 485);
            this.cbcatagory.Name = "cbcatagory";
            this.cbcatagory.Size = new System.Drawing.Size(290, 24);
            this.cbcatagory.TabIndex = 6;
            this.cbcatagory.SelectedIndexChanged += new System.EventHandler(this.cbcatagory_SelectedIndexChanged);
            // 
            // rbadult
            // 
            this.rbadult.AutoSize = true;
            this.rbadult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbadult.Location = new System.Drawing.Point(189, 515);
            this.rbadult.Name = "rbadult";
            this.rbadult.Size = new System.Drawing.Size(98, 22);
            this.rbadult.TabIndex = 7;
            this.rbadult.TabStop = true;
            this.rbadult.Text = "Adult Book";
            this.rbadult.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // admadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 671);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbadult);
            this.Controls.Add(this.cbcatagory);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lbleave);
            this.Controls.Add(this.txtauthor);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.pbphoto);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "admadd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admadd";
            this.Load += new System.EventHandler(this.admadd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbphoto;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtauthor;
        private System.Windows.Forms.Label lbleave;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ComboBox cbcatagory;
        private System.Windows.Forms.RadioButton rbadult;
        private System.Windows.Forms.Label label2;
    }
}