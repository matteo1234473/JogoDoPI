
namespace Aplicativo1
{
    partial class Tabuleiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tabuleiro));
            this.btnRodadado = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtDado1 = new System.Windows.Forms.TextBox();
            this.txtDado2 = new System.Windows.Forms.TextBox();
            this.txtDado4 = new System.Windows.Forms.TextBox();
            this.txtDado3 = new System.Windows.Forms.TextBox();
            this.txtJogadores = new System.Windows.Forms.TextBox();
            this.btn_statusTabu = new System.Windows.Forms.Button();
            this.txtTestezada = new System.Windows.Forms.TextBox();
            this.pictureBox85 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox85)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRodadado
            // 
            this.btnRodadado.Location = new System.Drawing.Point(10, 18);
            this.btnRodadado.Name = "btnRodadado";
            this.btnRodadado.Size = new System.Drawing.Size(75, 23);
            this.btnRodadado.TabIndex = 8;
            this.btnRodadado.Text = "Rodar Dado";
            this.btnRodadado.UseVisualStyleBackColor = true;
            this.btnRodadado.Click += new System.EventHandler(this.btnRodadado_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 44);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(10, 116);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 44);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 166);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 44);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(10, 219);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(45, 44);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // txtDado1
            // 
            this.txtDado1.Location = new System.Drawing.Point(10, 77);
            this.txtDado1.Name = "txtDado1";
            this.txtDado1.Size = new System.Drawing.Size(43, 20);
            this.txtDado1.TabIndex = 14;
            this.txtDado1.TextChanged += new System.EventHandler(this.txtDado1_TextChanged);
            // 
            // txtDado2
            // 
            this.txtDado2.Location = new System.Drawing.Point(10, 128);
            this.txtDado2.Name = "txtDado2";
            this.txtDado2.Size = new System.Drawing.Size(43, 20);
            this.txtDado2.TabIndex = 15;
            this.txtDado2.TextChanged += new System.EventHandler(this.txtDado2_TextChanged);
            // 
            // txtDado4
            // 
            this.txtDado4.Location = new System.Drawing.Point(10, 230);
            this.txtDado4.Name = "txtDado4";
            this.txtDado4.Size = new System.Drawing.Size(43, 20);
            this.txtDado4.TabIndex = 17;
            this.txtDado4.TextChanged += new System.EventHandler(this.txtDado4_TextChanged);
            // 
            // txtDado3
            // 
            this.txtDado3.Location = new System.Drawing.Point(10, 178);
            this.txtDado3.Name = "txtDado3";
            this.txtDado3.Size = new System.Drawing.Size(43, 20);
            this.txtDado3.TabIndex = 18;
            this.txtDado3.TextChanged += new System.EventHandler(this.txtDado3_TextChanged);
            // 
            // txtJogadores
            // 
            this.txtJogadores.BackColor = System.Drawing.Color.LightGray;
            this.txtJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJogadores.Location = new System.Drawing.Point(621, 20);
            this.txtJogadores.Multiline = true;
            this.txtJogadores.Name = "txtJogadores";
            this.txtJogadores.Size = new System.Drawing.Size(151, 103);
            this.txtJogadores.TabIndex = 7;
            this.txtJogadores.TextChanged += new System.EventHandler(this.txtJogadores_TextChanged);
            // 
            // btn_statusTabu
            // 
            this.btn_statusTabu.Location = new System.Drawing.Point(12, 488);
            this.btn_statusTabu.Name = "btn_statusTabu";
            this.btn_statusTabu.Size = new System.Drawing.Size(113, 61);
            this.btn_statusTabu.TabIndex = 123;
            this.btn_statusTabu.Text = "Status Tabuleiro";
            this.btn_statusTabu.UseVisualStyleBackColor = true;
            this.btn_statusTabu.Click += new System.EventHandler(this.btn_statusTabu_Click);
            // 
            // txtTestezada
            // 
            this.txtTestezada.Location = new System.Drawing.Point(631, 509);
            this.txtTestezada.Name = "txtTestezada";
            this.txtTestezada.Size = new System.Drawing.Size(112, 20);
            this.txtTestezada.TabIndex = 124;
            // 
            // pictureBox85
            // 
            this.pictureBox85.Location = new System.Drawing.Point(644, 270);
            this.pictureBox85.Name = "pictureBox85";
            this.pictureBox85.Size = new System.Drawing.Size(27, 22);
            this.pictureBox85.TabIndex = 110;
            this.pictureBox85.TabStop = false;
            // 
            // Tabuleiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtTestezada);
            this.Controls.Add(this.btn_statusTabu);
            this.Controls.Add(this.pictureBox85);
            this.Controls.Add(this.txtDado3);
            this.Controls.Add(this.txtDado4);
            this.Controls.Add(this.txtDado2);
            this.Controls.Add(this.txtDado1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRodadado);
            this.Controls.Add(this.txtJogadores);
            this.Name = "Tabuleiro";
            this.Load += new System.EventHandler(this.Tabuleiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox85)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRodadado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtDado1;
        private System.Windows.Forms.TextBox txtDado2;
        private System.Windows.Forms.TextBox txtDado4;
        private System.Windows.Forms.TextBox txtDado3;
        private System.Windows.Forms.TextBox txtJogadores;
        private System.Windows.Forms.Button btn_statusTabu;
        private System.Windows.Forms.TextBox txtTestezada;
        private System.Windows.Forms.PictureBox pictureBox85;
    }
}