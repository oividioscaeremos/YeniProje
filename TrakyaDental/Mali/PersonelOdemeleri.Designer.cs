﻿namespace TrakyaDental
{
    partial class PersonelOdemeleri
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
            this.labelPlus = new System.Windows.Forms.Label();
            this.pbPlus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(893, 556);
            this.dataGridView1.TabIndex = 13;
            // 
            // labelPlus
            // 
            this.labelPlus.AutoSize = true;
            this.labelPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPlus.Location = new System.Drawing.Point(753, 9);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(146, 24);
            this.labelPlus.TabIndex = 15;
            this.labelPlus.Text = "YENİ OLUŞTUR";
            // 
            // pbPlus
            // 
            this.pbPlus.Image = global::TrakyaDental.Properties.Resources.plusNew;
            this.pbPlus.Location = new System.Drawing.Point(724, 6);
            this.pbPlus.Name = "pbPlus";
            this.pbPlus.Size = new System.Drawing.Size(26, 31);
            this.pbPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlus.TabIndex = 14;
            this.pbPlus.TabStop = false;
            // 
            // PersonelOdemeleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPlus);
            this.Controls.Add(this.pbPlus);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PersonelOdemeleri";
            this.Size = new System.Drawing.Size(899, 599);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.PictureBox pbPlus;
    }
}
