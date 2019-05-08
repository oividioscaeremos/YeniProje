namespace TrakyaDental
{
    partial class GenelPersonelOdemeleri
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IslemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IslemTipiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bakiye = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbPlus = new System.Windows.Forms.PictureBox();
            this.labelPlus = new System.Windows.Forms.Label();
            this.doktorOdemeleriYeni1 = new TrakyaDental.Stok.DoktorOdemeleriYeni();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IslemID,
            this.PersonelID,
            this.IslemTipiID,
            this.Bakiye});
            this.dataGridView1.Location = new System.Drawing.Point(3, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(893, 556);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IslemID
            // 
            this.IslemID.HeaderText = "IslemID";
            this.IslemID.Name = "IslemID";
            // 
            // PersonelID
            // 
            this.PersonelID.HeaderText = "PersonelID";
            this.PersonelID.Name = "PersonelID";
            // 
            // IslemTipiID
            // 
            this.IslemTipiID.HeaderText = "IslemTipiID";
            this.IslemTipiID.Name = "IslemTipiID";
            // 
            // Bakiye
            // 
            this.Bakiye.HeaderText = "Bakiye";
            this.Bakiye.Name = "Bakiye";
            // 
            // pbPlus
            // 
            this.pbPlus.Image = global::TrakyaDental.Properties.Resources.plusNew;
            this.pbPlus.Location = new System.Drawing.Point(699, 6);
            this.pbPlus.Name = "pbPlus";
            this.pbPlus.Size = new System.Drawing.Size(26, 31);
            this.pbPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlus.TabIndex = 11;
            this.pbPlus.TabStop = false;
            this.pbPlus.Click += new System.EventHandler(this.labelPlus_Click);
            // 
            // labelPlus
            // 
            this.labelPlus.AutoSize = true;
            this.labelPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPlus.Location = new System.Drawing.Point(728, 9);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(146, 24);
            this.labelPlus.TabIndex = 12;
            this.labelPlus.Text = "YENİ OLUŞTUR";
            this.labelPlus.Click += new System.EventHandler(this.labelPlus_Click);
            // 
            // doktorOdemeleriYeni1
            // 
            this.doktorOdemeleriYeni1.Location = new System.Drawing.Point(340, 217);
            this.doktorOdemeleriYeni1.Name = "doktorOdemeleriYeni1";
            this.doktorOdemeleriYeni1.Size = new System.Drawing.Size(239, 195);
            this.doktorOdemeleriYeni1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TrakyaDental.Properties.Resources.refresh;
            this.pictureBox1.Location = new System.Drawing.Point(123, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DoktorOdemeleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.doktorOdemeleriYeni1);
            this.Controls.Add(this.labelPlus);
            this.Controls.Add(this.pbPlus);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DoktorOdemeleri";
            this.Size = new System.Drawing.Size(899, 599);
            this.Load += new System.EventHandler(this.DoktorOdemeleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pbPlus;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.DataGridViewTextBoxColumn IslemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IslemTipiID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bakiye;
        private Stok.DoktorOdemeleriYeni doktorOdemeleriYeni1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
