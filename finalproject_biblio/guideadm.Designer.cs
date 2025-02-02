namespace finalproject_biblio
{
    partial class guideadm
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
            this.btnnewbook = new System.Windows.Forms.Button();
            this.btnfines = new System.Windows.Forms.Button();
            this.btncustomer = new System.Windows.Forms.Button();
            this.btnchange = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbleave = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finalproject_biblio.Properties.Resources.menuadm;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(597, 536);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnnewbook
            // 
            this.btnnewbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnewbook.Location = new System.Drawing.Point(318, 208);
            this.btnnewbook.Name = "btnnewbook";
            this.btnnewbook.Size = new System.Drawing.Size(218, 57);
            this.btnnewbook.TabIndex = 1;
            this.btnnewbook.Text = "Add new Book";
            this.btnnewbook.UseVisualStyleBackColor = true;
            this.btnnewbook.Click += new System.EventHandler(this.btnnewbook_Click);
            // 
            // btnfines
            // 
            this.btnfines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfines.Location = new System.Drawing.Point(318, 293);
            this.btnfines.Name = "btnfines";
            this.btnfines.Size = new System.Drawing.Size(218, 57);
            this.btnfines.TabIndex = 2;
            this.btnfines.Text = "View customer fines";
            this.btnfines.UseVisualStyleBackColor = true;
            this.btnfines.Click += new System.EventHandler(this.btnfines_Click);
            // 
            // btncustomer
            // 
            this.btncustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncustomer.Location = new System.Drawing.Point(318, 379);
            this.btncustomer.Name = "btncustomer";
            this.btncustomer.Size = new System.Drawing.Size(218, 57);
            this.btncustomer.TabIndex = 3;
            this.btncustomer.Text = "View customer info";
            this.btncustomer.UseVisualStyleBackColor = true;
            this.btncustomer.Click += new System.EventHandler(this.btncustomer_Click);
            // 
            // btnchange
            // 
            this.btnchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchange.Location = new System.Drawing.Point(30, 208);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(236, 57);
            this.btnchange.TabIndex = 4;
            this.btnchange.Text = "Changes";
            this.btnchange.UseVisualStyleBackColor = true;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(360, 32);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(151, 30);
            this.txtname.TabIndex = 5;
            // 
            // lbleave
            // 
            this.lbleave.AutoSize = true;
            this.lbleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleave.Location = new System.Drawing.Point(507, 510);
            this.lbleave.Name = "lbleave";
            this.lbleave.Size = new System.Drawing.Size(70, 20);
            this.lbleave.TabIndex = 6;
            this.lbleave.Text = "<- Leave";
            this.lbleave.Click += new System.EventHandler(this.lbleave_Click);
            this.lbleave.MouseEnter += new System.EventHandler(this.lbleave_MouseEnter);
            this.lbleave.MouseLeave += new System.EventHandler(this.lbleave_MouseLeave);
            // 
            // guideadm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 535);
            this.Controls.Add(this.lbleave);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btnchange);
            this.Controls.Add(this.btncustomer);
            this.Controls.Add(this.btnfines);
            this.Controls.Add(this.btnnewbook);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "guideadm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "guideadm";
            this.Load += new System.EventHandler(this.guideadm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnnewbook;
        private System.Windows.Forms.Button btnfines;
        private System.Windows.Forms.Button btncustomer;
        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lbleave;
    }
}