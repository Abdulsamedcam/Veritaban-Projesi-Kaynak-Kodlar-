namespace pgConnect
{
    partial class sipariş
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.sipformukaydet = new System.Windows.Forms.Button();
            this.vazgec = new System.Windows.Forms.Button();
            this.urunekle = new System.Windows.Forms.Button();
            this.urunsil = new System.Windows.Forms.Button();
            this.urunguncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Müşteri Kodu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.AliceBlue;
            this.label10.Location = new System.Drawing.Point(145, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "SİPARİŞ FORMU";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(288, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(229, 31);
            this.label11.TabIndex = 19;
            this.label11.Text = "SİPARİŞ FORMU";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 150);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(86, 99);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(231, 67);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Açıklama";
            // 
            // sipformukaydet
            // 
            this.sipformukaydet.Location = new System.Drawing.Point(86, 172);
            this.sipformukaydet.Name = "sipformukaydet";
            this.sipformukaydet.Size = new System.Drawing.Size(133, 23);
            this.sipformukaydet.TabIndex = 24;
            this.sipformukaydet.Text = "Sipariş Formu Oluştur";
            this.sipformukaydet.UseVisualStyleBackColor = true;
            this.sipformukaydet.Click += new System.EventHandler(this.button2_Click);
            // 
            // vazgec
            // 
            this.vazgec.Location = new System.Drawing.Point(234, 172);
            this.vazgec.Name = "vazgec";
            this.vazgec.Size = new System.Drawing.Size(70, 23);
            this.vazgec.TabIndex = 25;
            this.vazgec.Text = "Vazgeç";
            this.vazgec.UseVisualStyleBackColor = true;
            // 
            // urunekle
            // 
            this.urunekle.Enabled = false;
            this.urunekle.Location = new System.Drawing.Point(342, 225);
            this.urunekle.Name = "urunekle";
            this.urunekle.Size = new System.Drawing.Size(75, 23);
            this.urunekle.TabIndex = 26;
            this.urunekle.Text = "Ürün Ekle";
            this.urunekle.UseVisualStyleBackColor = true;
            this.urunekle.Click += new System.EventHandler(this.button4_Click);
            // 
            // urunsil
            // 
            this.urunsil.Enabled = false;
            this.urunsil.Location = new System.Drawing.Point(433, 225);
            this.urunsil.Name = "urunsil";
            this.urunsil.Size = new System.Drawing.Size(75, 23);
            this.urunsil.TabIndex = 27;
            this.urunsil.Text = "Ürün Sil";
            this.urunsil.UseVisualStyleBackColor = true;
            this.urunsil.Click += new System.EventHandler(this.urunsil_Click);
            // 
            // urunguncelle
            // 
            this.urunguncelle.Enabled = false;
            this.urunguncelle.Location = new System.Drawing.Point(514, 225);
            this.urunguncelle.Name = "urunguncelle";
            this.urunguncelle.Size = new System.Drawing.Size(94, 23);
            this.urunguncelle.TabIndex = 28;
            this.urunguncelle.Text = "Ürün Güncelle";
            this.urunguncelle.UseVisualStyleBackColor = true;
            this.urunguncelle.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // sipariş
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 348);
            this.Controls.Add(this.urunguncelle);
            this.Controls.Add(this.urunsil);
            this.Controls.Add(this.urunekle);
            this.Controls.Add(this.vazgec);
            this.Controls.Add(this.sipformukaydet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "sipariş";
            this.Text = "sipariş";
            this.Load += new System.EventHandler(this.sipariş_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button sipformukaydet;
        private System.Windows.Forms.Button vazgec;
        private System.Windows.Forms.Button urunekle;
        private System.Windows.Forms.Button urunsil;
        private System.Windows.Forms.Button urunguncelle;
    }
}