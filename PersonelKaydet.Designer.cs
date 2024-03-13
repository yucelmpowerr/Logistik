namespace Lojistik
{
    partial class PersonelEkle
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
            System.Windows.Forms.Label personel_IDLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            personel_IDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // personel_IDLabel
            // 
            personel_IDLabel.AutoSize = true;
            personel_IDLabel.Location = new System.Drawing.Point(36, 66);
            personel_IDLabel.Name = "personel_IDLabel";
            personel_IDLabel.Size = new System.Drawing.Size(36, 16);
            personel_IDLabel.TabIndex = 3;
            personel_IDLabel.Text = "Adı : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(36, 114);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 16);
            label1.TabIndex = 5;
            label1.Text = "Soyadı : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(36, 157);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 16);
            label2.TabIndex = 7;
            label2.Text = "Görevi : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(36, 201);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 16);
            label3.TabIndex = 9;
            label3.Text = "Depo :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 22);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 109);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(168, 22);
            this.textBox2.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(122, 201);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 157);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(168, 22);
            this.textBox3.TabIndex = 11;
            // 
            // PersonelEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lojistik.Properties.Resources.WhatsApp_Image_2024_01_04_at_13_16_45;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(369, 418);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(personel_IDLabel);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "PersonelEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersonelEkle";
            this.Load += new System.EventHandler(this.PersonelEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox3;
    }
}