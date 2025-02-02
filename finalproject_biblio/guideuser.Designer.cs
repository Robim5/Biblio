namespace finalproject_biblio
{
    partial class guideuser
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
            this.btnexplore = new System.Windows.Forms.Button();
            this.btnrequest = new System.Windows.Forms.Button();
            this.btnsee = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbduvida = new System.Windows.Forms.Label();
            this.lbleave = new System.Windows.Forms.Label();
            this.lbwarning1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finalproject_biblio.Properties.Resources.menunormal;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 557);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnexplore
            // 
            this.btnexplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexplore.Location = new System.Drawing.Point(50, 216);
            this.btnexplore.Name = "btnexplore";
            this.btnexplore.Size = new System.Drawing.Size(364, 79);
            this.btnexplore.TabIndex = 1;
            this.btnexplore.Text = "Explore Books";
            this.btnexplore.UseVisualStyleBackColor = true;
            this.btnexplore.Click += new System.EventHandler(this.btnexplore_Click);
            // 
            // btnrequest
            // 
            this.btnrequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrequest.Location = new System.Drawing.Point(50, 320);
            this.btnrequest.Name = "btnrequest";
            this.btnrequest.Size = new System.Drawing.Size(364, 79);
            this.btnrequest.TabIndex = 2;
            this.btnrequest.Text = "Request Book";
            this.btnrequest.UseVisualStyleBackColor = true;
            this.btnrequest.Click += new System.EventHandler(this.btnrequest_Click);
            // 
            // btnsee
            // 
            this.btnsee.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsee.Location = new System.Drawing.Point(50, 425);
            this.btnsee.Name = "btnsee";
            this.btnsee.Size = new System.Drawing.Size(364, 79);
            this.btnsee.TabIndex = 3;
            this.btnsee.Text = "See my profille";
            this.btnsee.UseVisualStyleBackColor = true;
            this.btnsee.Click += new System.EventHandler(this.btnsee_Click);
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(468, 34);
            this.txtname.Name = "txtname";
            this.txtname.ReadOnly = true;
            this.txtname.Size = new System.Drawing.Size(186, 30);
            this.txtname.TabIndex = 4;
            // 
            // lbduvida
            // 
            this.lbduvida.AutoSize = true;
            this.lbduvida.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbduvida.Location = new System.Drawing.Point(738, 28);
            this.lbduvida.Name = "lbduvida";
            this.lbduvida.Size = new System.Drawing.Size(34, 37);
            this.lbduvida.TabIndex = 5;
            this.lbduvida.Text = "?";
            this.lbduvida.Click += new System.EventHandler(this.lbduvida_Click);
            // 
            // lbleave
            // 
            this.lbleave.AutoSize = true;
            this.lbleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleave.Location = new System.Drawing.Point(21, 532);
            this.lbleave.Name = "lbleave";
            this.lbleave.Size = new System.Drawing.Size(77, 24);
            this.lbleave.TabIndex = 6;
            this.lbleave.Text = "<- leave";
            this.lbleave.Click += new System.EventHandler(this.lbleave_Click);
            this.lbleave.MouseEnter += new System.EventHandler(this.lbleave_MouseEnter);
            this.lbleave.MouseLeave += new System.EventHandler(this.lbleave_MouseLeave);
            // 
            // lbwarning1
            // 
            this.lbwarning1.AutoSize = true;
            this.lbwarning1.BackColor = System.Drawing.Color.Red;
            this.lbwarning1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwarning1.ForeColor = System.Drawing.Color.White;
            this.lbwarning1.Location = new System.Drawing.Point(405, 414);
            this.lbwarning1.Name = "lbwarning1";
            this.lbwarning1.Size = new System.Drawing.Size(18, 25);
            this.lbwarning1.TabIndex = 20;
            this.lbwarning1.Text = "!";
            // 
            // guideuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 554);
            this.Controls.Add(this.lbwarning1);
            this.Controls.Add(this.lbleave);
            this.Controls.Add(this.lbduvida);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.btnsee);
            this.Controls.Add(this.btnrequest);
            this.Controls.Add(this.btnexplore);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "guideuser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "guideuser";
            this.Load += new System.EventHandler(this.guideuser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnexplore;
        private System.Windows.Forms.Button btnrequest;
        private System.Windows.Forms.Button btnsee;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lbduvida;
        private System.Windows.Forms.Label lbleave;
        private System.Windows.Forms.Label lbwarning1;
    }
}