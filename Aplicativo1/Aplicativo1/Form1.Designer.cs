
namespace Aplicativo1
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPartidas = new System.Windows.Forms.Button();
            this.lstPartidas = new System.Windows.Forms.ListBox();
            this.btnJogadores = new System.Windows.Forms.Button();
            this.txtJogadores = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnTabuleiro = new System.Windows.Forms.Button();
            this.lblJogador = new System.Windows.Forms.Label();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenhaPartida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomePartida = new System.Windows.Forms.TextBox();
            this.txtCriarSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnPartidasJ = new System.Windows.Forms.Button();
            this.btnIniciarP = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdjogador = new System.Windows.Forms.TextBox();
            this.btn_StatusTabu2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPartidas
            // 
            this.btnPartidas.BackColor = System.Drawing.Color.LightCyan;
            this.btnPartidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartidas.Location = new System.Drawing.Point(378, 202);
            this.btnPartidas.Name = "btnPartidas";
            this.btnPartidas.Size = new System.Drawing.Size(92, 42);
            this.btnPartidas.TabIndex = 1;
            this.btnPartidas.Text = "Partidas";
            this.btnPartidas.UseVisualStyleBackColor = false;
            this.btnPartidas.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstPartidas
            // 
            this.lstPartidas.BackColor = System.Drawing.Color.LightCyan;
            this.lstPartidas.FormattingEnabled = true;
            this.lstPartidas.Location = new System.Drawing.Point(348, 12);
            this.lstPartidas.Name = "lstPartidas";
            this.lstPartidas.Size = new System.Drawing.Size(334, 173);
            this.lstPartidas.TabIndex = 2;
            this.lstPartidas.SelectedIndexChanged += new System.EventHandler(this.lstPartidas_SelectedIndexChanged);
            // 
            // btnJogadores
            // 
            this.btnJogadores.BackColor = System.Drawing.Color.LightCyan;
            this.btnJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogadores.Location = new System.Drawing.Point(378, 271);
            this.btnJogadores.Name = "btnJogadores";
            this.btnJogadores.Size = new System.Drawing.Size(92, 42);
            this.btnJogadores.TabIndex = 4;
            this.btnJogadores.Text = "Jogadores";
            this.btnJogadores.UseVisualStyleBackColor = false;
            this.btnJogadores.Click += new System.EventHandler(this.btnJogadores_Click);
            // 
            // txtJogadores
            // 
            this.txtJogadores.BackColor = System.Drawing.Color.LightCyan;
            this.txtJogadores.Location = new System.Drawing.Point(522, 191);
            this.txtJogadores.Multiline = true;
            this.txtJogadores.Name = "txtJogadores";
            this.txtJogadores.Size = new System.Drawing.Size(160, 147);
            this.txtJogadores.TabIndex = 5;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.LightCyan;
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(113, 113);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(111, 37);
            this.btnEntrar.TabIndex = 6;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnCriar
            // 
            this.btnCriar.BackColor = System.Drawing.Color.LightCyan;
            this.btnCriar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriar.Location = new System.Drawing.Point(124, 271);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(85, 44);
            this.btnCriar.TabIndex = 7;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = false;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // btnTabuleiro
            // 
            this.btnTabuleiro.BackColor = System.Drawing.Color.LightCyan;
            this.btnTabuleiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabuleiro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTabuleiro.Location = new System.Drawing.Point(378, 334);
            this.btnTabuleiro.Name = "btnTabuleiro";
            this.btnTabuleiro.Size = new System.Drawing.Size(112, 44);
            this.btnTabuleiro.TabIndex = 8;
            this.btnTabuleiro.Text = "Tabuleiro";
            this.btnTabuleiro.UseVisualStyleBackColor = false;
            this.btnTabuleiro.Click += new System.EventHandler(this.btnTabuleiro_Click);
            // 
            // lblJogador
            // 
            this.lblJogador.AutoSize = true;
            this.lblJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJogador.Location = new System.Drawing.Point(12, 49);
            this.lblJogador.Name = "lblJogador";
            this.lblJogador.Size = new System.Drawing.Size(66, 16);
            this.lblJogador.TabIndex = 9;
            this.lblJogador.Text = "Jogador";
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(15, 68);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(140, 20);
            this.txtNomeJogador.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Senha";
            // 
            // txtSenhaPartida
            // 
            this.txtSenhaPartida.Location = new System.Drawing.Point(175, 68);
            this.txtSenhaPartida.Name = "txtSenhaPartida";
            this.txtSenhaPartida.Size = new System.Drawing.Size(143, 20);
            this.txtSenhaPartida.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Entrar na Partida";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Criar partida";
            // 
            // txtNomePartida
            // 
            this.txtNomePartida.Location = new System.Drawing.Point(12, 234);
            this.txtNomePartida.Name = "txtNomePartida";
            this.txtNomePartida.Size = new System.Drawing.Size(140, 20);
            this.txtNomePartida.TabIndex = 15;
            // 
            // txtCriarSenha
            // 
            this.txtCriarSenha.Location = new System.Drawing.Point(175, 234);
            this.txtCriarSenha.Name = "txtCriarSenha";
            this.txtCriarSenha.Size = new System.Drawing.Size(140, 20);
            this.txtCriarSenha.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nome";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(172, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Senha";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(625, 365);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(0, 13);
            this.lblVersao.TabIndex = 19;
            // 
            // btnPartidasJ
            // 
            this.btnPartidasJ.Location = new System.Drawing.Point(476, 190);
            this.btnPartidasJ.Name = "btnPartidasJ";
            this.btnPartidasJ.Size = new System.Drawing.Size(37, 20);
            this.btnPartidasJ.TabIndex = 20;
            this.btnPartidasJ.Text = "J";
            this.btnPartidasJ.UseVisualStyleBackColor = true;
            this.btnPartidasJ.Click += new System.EventHandler(this.btnPartidasJ_Click);
            // 
            // btnIniciarP
            // 
            this.btnIniciarP.Location = new System.Drawing.Point(519, 340);
            this.btnIniciarP.Name = "btnIniciarP";
            this.btnIniciarP.Size = new System.Drawing.Size(106, 33);
            this.btnIniciarP.TabIndex = 21;
            this.btnIniciarP.Text = "Inicar partida";
            this.btnIniciarP.UseVisualStyleBackColor = true;
            this.btnIniciarP.Click += new System.EventHandler(this.btnIniciarP_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "IdJogador";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtIdjogador
            // 
            this.txtIdjogador.Location = new System.Drawing.Point(12, 353);
            this.txtIdjogador.Name = "txtIdjogador";
            this.txtIdjogador.Size = new System.Drawing.Size(100, 20);
            this.txtIdjogador.TabIndex = 23;
            // 
            // btn_StatusTabu2
            // 
            this.btn_StatusTabu2.Location = new System.Drawing.Point(209, 337);
            this.btn_StatusTabu2.Name = "btn_StatusTabu2";
            this.btn_StatusTabu2.Size = new System.Drawing.Size(106, 41);
            this.btn_StatusTabu2.TabIndex = 24;
            this.btn_StatusTabu2.Text = "Status Tabuleiro";
            this.btn_StatusTabu2.UseVisualStyleBackColor = true;
            this.btn_StatusTabu2.Click += new System.EventHandler(this.btn_StatusTabu2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(694, 390);
            this.Controls.Add(this.btn_StatusTabu2);
            this.Controls.Add(this.txtIdjogador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnIniciarP);
            this.Controls.Add(this.btnPartidasJ);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCriarSenha);
            this.Controls.Add(this.txtNomePartida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSenhaPartida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeJogador);
            this.Controls.Add(this.lblJogador);
            this.Controls.Add(this.btnTabuleiro);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtJogadores);
            this.Controls.Add(this.btnJogadores);
            this.Controls.Add(this.lstPartidas);
            this.Controls.Add(this.btnPartidas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPartidas;
        private System.Windows.Forms.ListBox lstPartidas;
        private System.Windows.Forms.Button btnJogadores;
        private System.Windows.Forms.TextBox txtJogadores;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button btnTabuleiro;
        private System.Windows.Forms.Label lblJogador;
        private System.Windows.Forms.TextBox txtNomeJogador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenhaPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomePartida;
        private System.Windows.Forms.TextBox txtCriarSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnPartidasJ;
        private System.Windows.Forms.Button btnIniciarP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdjogador;
        private System.Windows.Forms.Button btn_StatusTabu2;
    }
}

