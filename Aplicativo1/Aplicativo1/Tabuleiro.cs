﻿using System;
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
    public partial class Tabuleiro : Form
    {
        Form1 form1 = new Form1();
        
        public Tabuleiro()
        {
            
            form1.ShowDialog();

            InitializeComponent();

            txtJogadores.Text = Jogo.ListarJogadores(form1.idPartida);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void btnRodadado_Click(object sender, EventArgs e)
        {
            string dados = Jogo.RolarDados(form1.IdJogador, form1.Senha);
            if (dados.StartsWith("ERRO"))
            {
                MessageBox.Show(dados);
            }
            else
            {

                dados = dados.Replace("\r", "");
                string[] linha = dados.Split('\n');


                double[] dadoInt = { Convert.ToDouble(linha[0]) / 10, Convert.ToDouble(linha[1]) / 10, Convert.ToDouble(linha[2]) / 10, Convert.ToDouble(linha[3]) / 10 };


                string dado1 = Convert.ToString(dadoInt[0]);
                string dado2 = Convert.ToString(dadoInt[1]);
                string dado3 = Convert.ToString(dadoInt[2]);
                string dado4 = Convert.ToString(dadoInt[3]);

                string[] dadoTratado1 = dado1.Split(',');
                string[] dadoTratado2 = dado2.Split(',');
                string[] dadoTratado3 = dado3.Split(',');
                string[] dadoTratado4 = dado4.Split(',');


                txtDado1.Text = dadoTratado1[1];
                txtDado2.Text = dadoTratado2[1];
                txtDado3.Text = dadoTratado3[1];
                txtDado4.Text = dadoTratado4[1];

            }

            
            
               
            MessageBox.Show(dados);

        }


        private void txtJogadores_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtDado1_TextChanged(object sender, EventArgs e)
        {
            

        }
        private void txtDado2_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtDado3_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtDado4_TextChanged(object sender, EventArgs e)
        {


        }

        private void Tabuleiro_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox86_Click(object sender, EventArgs e)
        {

        }

        private void btn_statusTabu_Click(object sender, EventArgs e)
        {
            string status = Jogo.ExibirTabuleiro(form1.idPartida);

            if (status.StartsWith("ERRO"))
            {
                MessageBox.Show(status);
            }
            else
            {
                int i = 0;
                status = status.Replace("\r", "");
                string[] linha = status.Split('\n');

                while(linha[i] != "")
                {
                    string linhas = linha[i];
                    string[] dados = linhas.Split(',');
                    StatusTabu Status = new StatusTabu(Convert.ToInt32(dados[0]), Convert.ToInt32(dados[1]), Convert.ToInt32(dados[2]), Convert.ToChar(dados[3]));

                    if(Status.trilha == 2)
                    {


                    }









                    i++;
                }

                
                


                MessageBox.Show(status);
            }
        }
    }
}