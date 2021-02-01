namespace HavuzProblemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGraphCiz = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMusluk = new System.Windows.Forms.TextBox();
            this.richBaglanti = new System.Windows.Forms.RichTextBox();
            this.richKapasite = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBitis = new System.Windows.Forms.TextBox();
            this.txtBaslangic = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMaxFlow = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Musluk Sayısını Giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bağlantı Bilgilerini Giriniz:\r\n";
            // 
            // btnGraphCiz
            // 
            this.btnGraphCiz.Location = new System.Drawing.Point(139, 451);
            this.btnGraphCiz.Margin = new System.Windows.Forms.Padding(4);
            this.btnGraphCiz.Name = "btnGraphCiz";
            this.btnGraphCiz.Size = new System.Drawing.Size(88, 26);
            this.btnGraphCiz.TabIndex = 3;
            this.btnGraphCiz.Text = "Graph Çiz";
            this.btnGraphCiz.UseVisualStyleBackColor = true;
            this.btnGraphCiz.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Boru Hatlarının Kapasitelerini Giriniz:";
            // 
            // txtMusluk
            // 
            this.txtMusluk.Location = new System.Drawing.Point(248, 30);
            this.txtMusluk.Name = "txtMusluk";
            this.txtMusluk.Size = new System.Drawing.Size(100, 21);
            this.txtMusluk.TabIndex = 5;
            // 
            // richBaglanti
            // 
            this.richBaglanti.Location = new System.Drawing.Point(248, 96);
            this.richBaglanti.Name = "richBaglanti";
            this.richBaglanti.Size = new System.Drawing.Size(100, 96);
            this.richBaglanti.TabIndex = 6;
            this.richBaglanti.Text = "";
            // 
            // richKapasite
            // 
            this.richKapasite.Location = new System.Drawing.Point(248, 215);
            this.richKapasite.Name = "richKapasite";
            this.richKapasite.Size = new System.Drawing.Size(100, 96);
            this.richKapasite.TabIndex = 7;
            this.richKapasite.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBitis);
            this.groupBox1.Controls.Add(this.txtBaslangic);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richBaglanti);
            this.groupBox1.Controls.Add(this.richKapasite);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMusluk);
            this.groupBox1.Controls.Add(this.btnGraphCiz);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 495);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // txtBitis
            // 
            this.txtBitis.Location = new System.Drawing.Point(248, 372);
            this.txtBitis.Name = "txtBitis";
            this.txtBitis.Size = new System.Drawing.Size(100, 21);
            this.txtBitis.TabIndex = 11;
            // 
            // txtBaslangic
            // 
            this.txtBaslangic.Location = new System.Drawing.Point(248, 332);
            this.txtBaslangic.Name = "txtBaslangic";
            this.txtBaslangic.Size = new System.Drawing.Size(100, 21);
            this.txtBaslangic.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bitiş Düğümünü Giriniz:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Başlangıç Düğümünü Giriniz:";
            // 
            // lblMaxFlow
            // 
            this.lblMaxFlow.AutoSize = true;
            this.lblMaxFlow.Location = new System.Drawing.Point(402, 384);
            this.lblMaxFlow.Name = "lblMaxFlow";
            this.lblMaxFlow.Size = new System.Drawing.Size(63, 15);
            this.lblMaxFlow.TabIndex = 9;
            this.lblMaxFlow.Text = "Max Flow:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1011, 519);
            this.Controls.Add(this.lblMaxFlow);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGraphCiz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMusluk;
        private System.Windows.Forms.RichTextBox richBaglanti;
        private System.Windows.Forms.RichTextBox richKapasite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBitis;
        private System.Windows.Forms.TextBox txtBaslangic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMaxFlow;
    }
}

