namespace finalproject_biblio
{
    partial class explore
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
            this.dgvbooks = new System.Windows.Forms.DataGridView();
            this.pbimage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnfav = new System.Windows.Forms.Button();
            this.btnreq = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.rbnoadult = new System.Windows.Forms.RadioButton();
            this.rbonlyadult = new System.Windows.Forms.RadioButton();
            this.rball = new System.Windows.Forms.RadioButton();
            this.lbduvida = new System.Windows.Forms.Label();
            this.lbleave = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvbooks
            // 
            this.dgvbooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbooks.Location = new System.Drawing.Point(49, 161);
            this.dgvbooks.Name = "dgvbooks";
            this.dgvbooks.ReadOnly = true;
            this.dgvbooks.RowHeadersWidth = 51;
            this.dgvbooks.Size = new System.Drawing.Size(418, 342);
            this.dgvbooks.TabIndex = 1;
            this.dgvbooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbooks_CellClick);
            // 
            // pbimage
            // 
            this.pbimage.Image = global::finalproject_biblio.Properties.Resources.nobook;
            this.pbimage.Location = new System.Drawing.Point(530, 161);
            this.pbimage.Name = "pbimage";
            this.pbimage.Size = new System.Drawing.Size(220, 270);
            this.pbimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbimage.TabIndex = 2;
            this.pbimage.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::finalproject_biblio.Properties.Resources.explore;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 560);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnfav
            // 
            this.btnfav.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfav.Location = new System.Drawing.Point(647, 449);
            this.btnfav.Name = "btnfav";
            this.btnfav.Size = new System.Drawing.Size(103, 54);
            this.btnfav.TabIndex = 3;
            this.btnfav.Text = "Set As Favorite";
            this.btnfav.UseVisualStyleBackColor = true;
            this.btnfav.Click += new System.EventHandler(this.btnfav_Click);
            // 
            // btnreq
            // 
            this.btnreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreq.Location = new System.Drawing.Point(530, 449);
            this.btnreq.Name = "btnreq";
            this.btnreq.Size = new System.Drawing.Size(103, 54);
            this.btnreq.TabIndex = 4;
            this.btnreq.Text = "Request it";
            this.btnreq.UseVisualStyleBackColor = true;
            this.btnreq.Click += new System.EventHandler(this.btnreq_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(124, 31);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(455, 35);
            this.txtsearch.TabIndex = 5;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(576, 31);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(116, 35);
            this.btnsearch.TabIndex = 6;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // rbnoadult
            // 
            this.rbnoadult.AutoSize = true;
            this.rbnoadult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnoadult.Location = new System.Drawing.Point(143, 85);
            this.rbnoadult.Name = "rbnoadult";
            this.rbnoadult.Size = new System.Drawing.Size(98, 28);
            this.rbnoadult.TabIndex = 7;
            this.rbnoadult.TabStop = true;
            this.rbnoadult.Text = "No adult";
            this.rbnoadult.UseVisualStyleBackColor = true;
            this.rbnoadult.CheckedChanged += new System.EventHandler(this.rbnoadult_CheckedChanged);
            // 
            // rbonlyadult
            // 
            this.rbonlyadult.AutoSize = true;
            this.rbonlyadult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbonlyadult.Location = new System.Drawing.Point(273, 85);
            this.rbonlyadult.Name = "rbonlyadult";
            this.rbonlyadult.Size = new System.Drawing.Size(112, 28);
            this.rbonlyadult.TabIndex = 8;
            this.rbonlyadult.TabStop = true;
            this.rbonlyadult.Text = "Only adult";
            this.rbonlyadult.UseVisualStyleBackColor = true;
            this.rbonlyadult.CheckedChanged += new System.EventHandler(this.rbonlyadult_CheckedChanged);
            // 
            // rball
            // 
            this.rball.AutoSize = true;
            this.rball.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rball.Location = new System.Drawing.Point(428, 85);
            this.rball.Name = "rball";
            this.rball.Size = new System.Drawing.Size(49, 28);
            this.rball.TabIndex = 9;
            this.rball.TabStop = true;
            this.rball.Text = "All";
            this.rball.UseVisualStyleBackColor = true;
            this.rball.CheckedChanged += new System.EventHandler(this.rball_CheckedChanged);
            // 
            // lbduvida
            // 
            this.lbduvida.AutoSize = true;
            this.lbduvida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbduvida.Location = new System.Drawing.Point(726, 37);
            this.lbduvida.Name = "lbduvida";
            this.lbduvida.Size = new System.Drawing.Size(24, 25);
            this.lbduvida.TabIndex = 10;
            this.lbduvida.Text = "?";
            this.lbduvida.Click += new System.EventHandler(this.lbduvida_Click);
            // 
            // lbleave
            // 
            this.lbleave.AutoSize = true;
            this.lbleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbleave.Location = new System.Drawing.Point(12, 540);
            this.lbleave.Name = "lbleave";
            this.lbleave.Size = new System.Drawing.Size(63, 20);
            this.lbleave.TabIndex = 11;
            this.lbleave.Text = "<- Back";
            this.lbleave.Click += new System.EventHandler(this.lbleave_Click);
            this.lbleave.MouseEnter += new System.EventHandler(this.lbleave_MouseEnter);
            this.lbleave.MouseLeave += new System.EventHandler(this.lbleave_MouseLeave);
            // 
            // explore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.lbleave);
            this.Controls.Add(this.lbduvida);
            this.Controls.Add(this.rball);
            this.Controls.Add(this.rbonlyadult);
            this.Controls.Add(this.rbnoadult);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btnreq);
            this.Controls.Add(this.btnfav);
            this.Controls.Add(this.pbimage);
            this.Controls.Add(this.dgvbooks);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "explore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "explore";
            this.Load += new System.EventHandler(this.explore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvbooks;
        private System.Windows.Forms.PictureBox pbimage;
        private System.Windows.Forms.Button btnfav;
        private System.Windows.Forms.Button btnreq;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.RadioButton rbnoadult;
        private System.Windows.Forms.RadioButton rbonlyadult;
        private System.Windows.Forms.RadioButton rball;
        private System.Windows.Forms.Label lbduvida;
        private System.Windows.Forms.Label lbleave;
    }
}