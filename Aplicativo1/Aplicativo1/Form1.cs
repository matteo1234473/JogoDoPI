using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CantStopServer;

namespace Aplicativo1
{
    public partial class Form1 : Form
    {
        
        public int idPartida { get; set; }
        public string Senha { get; set; }
        public int IdJogador { get; set; }


        //Passando pro outro forms
        public Form1()
        {
            InitializeComponent();
            lblVersao.Text = "Versão " + Jogo.Versao;
         
        }


        //Função de pegar id da partida
        public int pegaIdDaPartida(string linha)
        {
            if (lstPartidas.SelectedItem.ToString() != "")
            {
                linha = lstPartidas.SelectedItem.ToString();
                string[] itens = linha.Split(',');
                int id = Convert.ToInt32(itens[0]);

                return id;
            }
            else return 0;
        }

        //Lista todas as partidas
        private void button1_Click(object sender, EventArgs e)
        {
            lstPartidas.Items.Clear();
            string retorno = Jogo.ListarPartidas("T");
            retorno = retorno.Replace("\r", "");
            string[] linha = retorno.Split('\n');

            for (int i = 0; i < linha.Length; i++)
            {
                lstPartidas.Items.Add(linha[i]);
            }
          
        }

        //Lista os jogadores da partida selecionada
        private void btnJogadores_Click(object sender, EventArgs e)
        {
            if (lstPartidas.SelectedItem != null)
            {
                int id = pegaIdDaPartida(lstPartidas.SelectedItem.ToString());
                txtJogadores.Text = Jogo.ListarJogadores(id);
            }
            else
                MessageBox.Show("ERRO: NENHUMA PARTIDA SELECIONADA");
        }

        //Entra na partida selecionada
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string jogador = txtNomeJogador.Text;
            string senha = txtSenhaPartida.Text;

            if (lstPartidas.SelectedItem != null) 
            {
                int id = pegaIdDaPartida(lstPartidas.SelectedItem.ToString());
                string entrar = Jogo.EntrarPartida(id, jogador, senha);
                if (entrar.StartsWith("ERRO"))
                {
                    MessageBox.Show(entrar);
                }
                else
                {
                    string[] itens = entrar.Split(',');
                    Senha = itens[1];
                    IdJogador = Convert.ToInt32(itens[0]);
                }
            }
            else
                MessageBox.Show("ERRO: NENHUMA PARTIDA SELECIONADA");

            txtNomeJogador.Clear();
            txtSenhaPartida.Clear();

        }
        //TesteGIT ja to profissa Thiago
        //Cria uma partida
        private void btnCriar_Click(object sender, EventArgs e)
        {
            string partida = txtNomePartida.Text;
            string senha = txtCriarSenha.Text;
            
            Jogo.CriarPartida(partida, senha);

            txtNomePartida.Clear();
            txtCriarSenha.Clear();
        }

        //Transfere o id da partida para o outro forms
        //E fecha o lobby
        private void btnTabuleiro_Click(object sender, EventArgs e)
        {
            int id = pegaIdDaPartida(lstPartidas.SelectedItem.ToString());
            this.idPartida = Convert.ToInt32(id);

            this.Close();
        }


        //Checa partidas J
        private void btnPartidasJ_Click(object sender, EventArgs e)
        {
                lstPartidas.Items.Clear();
                string retorno = Jogo.ListarPartidas("J");
                retorno = retorno.Replace("\r", "");
                string[] linha = retorno.Split('\n');

                for (int i = 0; i < linha.Length; i++)
                {
                    lstPartidas.Items.Add(linha[i]);
                }

        }

        private void btnIniciarP_Click(object sender, EventArgs e)
        {
            Jogo.IniciarPartida(IdJogador, Senha);
        }
    }
}
