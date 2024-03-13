namespace Lojistik
{
    partial class AracDüzenle
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label personel_IDLabel;
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            personel_IDLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(49, 98);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 16);
            label2.TabIndex = 25;
            label2.Text = "Adı : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(49, 192);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 16);
            label1.TabIndex = 22;
            label1.Text = "Plaka No : ";
            // 
            // personel_IDLabel
            // 
            personel_IDLabel.AutoSize = true;
            personel_IDLabel.Location = new System.Drawing.Point(49, 144);
            personel_IDLabel.Name = "personel_IDLabel";
            personel_IDLabel.Size = new System.Drawing.Size(69, 16);
            personel_IDLabel.TabIndex = 21;
            personel_IDLabel.Text = "Kapasite : ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(135, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(168, 22);
            this.textBox3.TabIndex = 26;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 187);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(168, 22);
            this.textBox2.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 52);
            this.button1.TabIndex = 20;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AracDüzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lojistik.Properties.Resources.Ekran_Alıntısı;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(369, 418);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(personel_IDLabel);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AracDüzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AracDüzenle";
            this.Load += new System.EventHandler(this.AracDüzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}