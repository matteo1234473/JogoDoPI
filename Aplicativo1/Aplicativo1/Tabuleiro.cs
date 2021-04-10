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
    public partial class Tabuleiro : Form
    {
        int mais1 = 0;
        Form1 form1 = new Form1();

        private void btnMais1_Click(object sender, EventArgs e)
        {
            mais1 += 1;
        }

        private void pboxJ4T12_Click(object sender, EventArgs e)
        {

        }


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


                while (linha[i] != "")
                {
                    string linhas = linha[i];
                    string[] dados = linhas.Split(',');
                    StatusTabu Status = new StatusTabu(Convert.ToInt32(dados[0]), Convert.ToInt32(dados[1]), Convert.ToInt32(dados[2]), Convert.ToChar(dados[3]));
                    Status.position += mais1;


                    switch (Status.jogador)
                    {
                        case 1://jogador 1


                            switch (Status.trilha)
                            {

                                case 2:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T2.Visible = true;
                                                pboxJ1T2.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T2.Visible = true;
                                                pboxAJ1T2.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T2.Visible = true;
                                                pboxJ1T2.BackColor = Color.Red;
                                                pboxJ1T2.Location = new Point(110, 296 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T2.Visible = true;
                                                pboxAJ1T2.BackColor = Color.Black;
                                                pboxAJ1T2.Location = new Point(110, 296 - 28);
                                            }


                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T2.Visible = true;
                                                pboxJ1T2.BackColor = Color.Red;
                                                pboxJ1T2.Location = new Point(112, (296 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T2.Visible = true;
                                                pboxAJ1T2.BackColor = Color.Black;
                                                pboxAJ1T2.Location = new Point(112, (296 - 28) - 28);
                                            }

                                            break;
                                    }

                                    break;

                                case 3:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T3.Visible = true;
                                                pboxJ1T3.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T3.Visible = true;
                                                pboxAJ1T3.BackColor = Color.Black;
                                            }



                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T3.Visible = true;
                                                pboxJ1T3.BackColor = Color.Red;
                                                pboxJ1T3.Location = new Point(163, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T3.Visible = true;
                                                pboxAJ1T3.BackColor = Color.Black;
                                                pboxAJ1T3.Location = new Point(163, 325 - 28);
                                            }



                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T3.Visible = true;
                                                pboxJ1T3.BackColor = Color.Red;
                                                pboxJ1T3.Location = new Point(163, (325 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T3.Visible = true;
                                                pboxAJ1T3.BackColor = Color.Black;
                                                pboxAJ1T3.Location = new Point(163, (325 - 28) - 28);
                                            }




                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T3.Visible = true;
                                                pboxJ1T3.BackColor = Color.Red;
                                                pboxJ1T3.Location = new Point(163, 325 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T3.Visible = true;
                                                pboxAJ1T3.BackColor = Color.Black;
                                                pboxAJ1T3.Location = new Point(163, 325 - (28 * 3));
                                            }




                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T3.Visible = true;
                                                pboxJ1T3.BackColor = Color.Red;
                                                pboxJ1T3.Location = new Point(163, 325 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T3.Visible = true;
                                                pboxAJ1T3.BackColor = Color.Black;
                                                pboxAJ1T3.Location = new Point(163, 325 - (28 * 4));
                                            }




                                            break;
                                    }
                                    break;

                                case 4:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxJ1T4.Location = new Point(217, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, 325 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxJ1T4.Location = new Point(217, (354 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, (354 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxJ1T4.Location = new Point(217, 354 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, 354 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxJ1T4.Location = new Point(217, 354 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, 354 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxJ1T4.Location = new Point(217, 354 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, 354 - (28 * 5));
                                            }




                                            break;
                                        case 7:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxJ1T4.Location = new Point(217, 354 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, 354 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 5:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;

                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;

                                            }


                                            break;

                                        case 2:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, (381 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, (381 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - (28 * 3));
                                            }


                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T5.Visible = true;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T5.Visible = true;
                                                pboxAJ1T5.BackColor = Color.Black;
                                                pboxAJ1T5.Location = new Point(270, 381 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;

                                case 6:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - 28);
                                            }

                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, (410 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, (410 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T6.Visible = true;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Location = new Point(323, 410 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ1T6.Visible = true;
                                                pboxAJ1T6.BackColor = Color.Black;
                                                pboxAJ1T6.Location = new Point(323, 410 - (28 * 10));
                                            }

                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - 28);
                                            }



                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - 28);
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 10));
                                            }

                                            break;
                                        case 12:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 11));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 11));
                                            }

                                            break;
                                        case 13:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 12));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 12));
                                            }

                                            break;
                                    }
                                    break;
                                case 8:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, (410 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, (410 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 8));
                                            }

                                            break;
                                        case 11:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T8.Visible = true;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T8.Visible = true;
                                                pboxAJ1T8.BackColor = Color.Black;
                                                pboxAJ1T8.Location = new Point(429, 410 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 9:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, (381 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, (381 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T9.Visible = true;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ1T9.Visible = true;
                                                pboxAJ1T9.BackColor = Color.Black;
                                                pboxAJ1T9.Location = new Point(482, 381 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 10:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, 325 - 28);
                                            }




                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, (354 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, (354 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 354 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, 354 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 354 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, 354 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 354 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, 354 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 354 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, 354 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 11:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T11.Visible = true;
                                                pboxJ1T11.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T11.Visible = true;
                                                pboxAJ1T11.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T11.Visible = true;
                                                pboxJ1T11.BackColor = Color.Red;
                                                pboxJ1T11.Location = new Point(589, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T11.Visible = true;
                                                pboxAJ1T11.BackColor = Color.Black;
                                                pboxAJ1T11.Location = new Point(589, 325 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T11.Visible = true;
                                                pboxJ1T11.BackColor = Color.Red;
                                                pboxJ1T11.Location = new Point(589, (325 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T11.Visible = true;
                                                pboxAJ1T11.BackColor = Color.Black;
                                                pboxAJ1T11.Location = new Point(589, (325 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T11.Visible = true;
                                                pboxJ1T11.BackColor = Color.Red;
                                                pboxJ1T11.Location = new Point(589, 325 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ1T11.Visible = true;
                                                pboxAJ1T11.BackColor = Color.Black;
                                                pboxAJ1T11.Location = new Point(589, 325 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T11.Visible = true;
                                                pboxJ1T11.BackColor = Color.Red;
                                                pboxJ1T11.Location = new Point(589, 325 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ1T11.Visible = true;
                                                pboxAJ1T11.BackColor = Color.Black;
                                                pboxAJ1T11.Location = new Point(589, 325 - (28 * 4));
                                            }

                                            break;
                                    }
                                    break;

                                case 12:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T12.Visible = true;
                                                pboxJ1T12.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                pboxAJ1T12.Visible = true;
                                                pboxAJ1T12.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T12.Visible = true;
                                                pboxJ1T12.BackColor = Color.Red;
                                                pboxJ1T12.Location = new Point(642, 296 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T12.Visible = true;
                                                pboxAJ1T12.BackColor = Color.Black;
                                                pboxAJ1T12.Location = new Point(642, 296 - 28);
                                            }

                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T12.Visible = true;
                                                pboxJ1T12.BackColor = Color.Red;
                                                pboxJ1T12.Location = new Point(642, (296 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T12.Visible = true;
                                                pboxAJ1T12.BackColor = Color.Black;
                                                pboxAJ1T12.Location = new Point(642, (296 - 28) - 28);
                                            }

                                            break;
                                    }


                                    break;

                            }


                            break;
                        case 2://Jogador 2
                            switch (Status.trilha)
                            {

                                case 2:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T2.Visible = true;
                                                pboxJ2T2.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T2.Visible = true;
                                                pboxAJ2T2.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T2.Visible = true;
                                                pboxJ2T2.BackColor = Color.Blue;
                                                pboxJ2T2.Location = new Point(129, 296 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T2.Visible = true;
                                                pboxAJ2T2.BackColor = Color.Black;
                                                pboxAJ2T2.Location = new Point(129, 296 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T2.Visible = true;
                                                pboxJ2T2.BackColor = Color.Blue;
                                                pboxJ2T2.Location = new Point(129, (296 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T2.Visible = true;
                                                pboxAJ2T2.BackColor = Color.Black;
                                                pboxAJ2T2.Location = new Point(129, (296 - 28) - 28);
                                            }

                                            break;
                                    }

                                    break;

                                case 3:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T3.Visible = true;
                                                pboxJ2T3.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T3.Visible = true;
                                                pboxAJ2T3.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T3.Visible = true;
                                                pboxJ2T3.BackColor = Color.Blue;
                                                pboxJ1T3.Location = new Point(181, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T3.Visible = true;
                                                pboxAJ2T3.BackColor = Color.Black;
                                                pboxAJ1T3.Location = new Point(181, 325 - 28);
                                            }


                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T3.Visible = true;
                                                pboxJ2T3.BackColor = Color.Blue;
                                                pboxJ2T3.Location = new Point(181, (325 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T3.Visible = true;
                                                pboxAJ2T3.BackColor = Color.Black;
                                                pboxAJ2T3.Location = new Point(181, (325 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T3.Visible = true;
                                                pboxJ2T3.BackColor = Color.Blue;
                                                pboxJ2T3.Location = new Point(181, 325 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T3.Visible = true;
                                                pboxAJ2T3.BackColor = Color.Black;
                                                pboxAJ2T3.Location = new Point(181, 325 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T3.Visible = true;
                                                pboxJ2T3.BackColor = Color.Blue;
                                                pboxJ2T3.Location = new Point(181, 325 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T3.Visible = true;
                                                pboxAJ2T3.BackColor = Color.Black;
                                                pboxAJ2T3.Location = new Point(181, 325 - (28 * 4));
                                            }

                                            break;
                                    }
                                    break;

                                case 4:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, 325 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, (354 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, (354 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 354 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, 354 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 354 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, 354 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 354 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, 354 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 354 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, 354 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 5:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, (381 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, (381 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T5.Visible = true;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T5.Visible = true;
                                                pboxAJ2T5.BackColor = Color.Black;
                                                pboxAJ2T5.Location = new Point(287, 381 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;

                                case 6:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, (410 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, (410 - 28) - 28);
                                            }




                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 5));
                                            }



                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 8));
                                            }

                                            break;
                                        case 11:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T6.Visible = true;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - 28);
                                            }

                                            break;
                                        case 3:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, (438 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, (438 - 28) - 28);
                                            }

                                            break;
                                        case 4:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 3));
                                            }

                                            break;
                                        case 5:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 4));
                                            }

                                            break;
                                        case 6:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 5));
                                            }

                                            break;
                                        case 7:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 6));
                                            }

                                            break;
                                        case 8:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 7));
                                            }

                                            break;
                                        case 9:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 8));
                                            }

                                            break;
                                        case 10:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 9));
                                            }

                                            break;
                                        case 11:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 10));
                                            }

                                            break;
                                        case 12:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 11));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 11));
                                            }

                                            break;
                                        case 13:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T7.Visible = true;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 12));
                                            }
                                            else
                                            {
                                                pboxAJ2T7.Visible = true;
                                                pboxAJ2T7.BackColor = Color.Black;
                                                pboxAJ2T7.Location = new Point(395, 438 - (28 * 12));
                                            }

                                            break;
                                    }
                                    break;
                                case 8:
                                    switch (Status.position)
                                    {
                                        case 1:



                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, (410 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, (410 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Black;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 8));
                                            }

                                            break;
                                        case 11:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T8.Visible = true;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ2T8.Visible = true;
                                                pboxAJ2T8.BackColor = Color.Black;
                                                pboxAJ2T8.Location = new Point(447, 410 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 9:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                            }



                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, (381 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, (381 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxJ2T9.Visible = true;
                                                pboxJ2T9.BackColor = Color.Black;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 10:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                                pboxAJ2T10.Location = new Point(553, 325 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, (354 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                                pboxAJ2T10.Location = new Point(553, (354 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, 354 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                                pboxAJ2T10.Location = new Point(553, 354 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, 354 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                                pboxAJ2T10.Location = new Point(553, 354 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, 354 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                                pboxAJ2T10.Location = new Point(553, 354 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T10.Visible = true;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, 354 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ2T10.Visible = true;
                                                pboxAJ2T10.BackColor = Color.Black;
                                                pboxAJ2T10.Location = new Point(553, 354 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 11:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T11.Visible = true;
                                                pboxJ2T11.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T11.Visible = true;
                                                pboxAJ2T11.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T11.Visible = true;
                                                pboxJ2T11.BackColor = Color.Blue;
                                                pboxJ2T11.Location = new Point(607, 325 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T11.Visible = true;
                                                pboxAJ2T11.BackColor = Color.Black;
                                                pboxAJ2T11.Location = new Point(607, 325 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T11.Visible = true;
                                                pboxJ2T11.BackColor = Color.Blue;
                                                pboxJ2T11.Location = new Point(607, (325 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T11.Visible = true;
                                                pboxAJ2T11.BackColor = Color.Black;
                                                pboxAJ2T11.Location = new Point(607, (325 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T11.Visible = true;
                                                pboxJ2T11.BackColor = Color.Blue;
                                                pboxJ2T11.Location = new Point(607, 325 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ2T11.Visible = true;
                                                pboxAJ2T11.BackColor = Color.Black;
                                                pboxAJ2T11.Location = new Point(607, 325 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T11.Visible = true;
                                                pboxJ2T11.BackColor = Color.Blue;
                                                pboxJ2T11.Location = new Point(607, 325 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ2T11.Visible = true;
                                                pboxAJ2T11.BackColor = Color.Black;
                                                pboxAJ2T11.Location = new Point(607, 325 - (28 * 4));
                                            }

                                            break;
                                    }
                                    break;

                                case 12:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T12.Visible = true;
                                                pboxJ2T12.BackColor = Color.Blue;
                                            }
                                            else
                                            {
                                                pboxAJ2T12.Visible = true;
                                                pboxAJ2T12.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T12.Visible = true;
                                                pboxJ2T12.BackColor = Color.Blue;
                                                pboxJ2T12.Location = new Point(660, 296 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T12.Visible = true;
                                                pboxAJ2T12.BackColor = Color.Black;
                                                pboxAJ2T12.Location = new Point(660, 296 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T12.Visible = true;
                                                pboxJ2T12.BackColor = Color.Blue;
                                                pboxJ2T12.Location = new Point(660, (296 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T12.Visible = true;
                                                pboxAJ2T12.BackColor = Color.Black;
                                                pboxAJ2T12.Location = new Point(660, (296 - 28) - 28);
                                            }
                                            break;
                                    }
                                    break;


                            }
                            break;







                        case 3://jogador3
                            switch (Status.trilha)
                            {

                                case 2:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T2.Visible = true;
                                                pboxJ3T2.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T2.Visible = true;
                                                pboxAJ3T2.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T2.Visible = true;
                                                pboxJ3T2.BackColor = Color.Green;
                                                pboxJ3T2.Location = new Point(110, 306 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T2.Visible = true;
                                                pboxAJ3T2.BackColor = Color.Black;
                                                pboxAJ3T2.Location = new Point(110, 306 - 28);
                                            }


                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T2.Visible = true;
                                                pboxJ3T2.BackColor = Color.Green;
                                                pboxJ3T2.Location = new Point(112, (306 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T2.Visible = true;
                                                pboxAJ3T2.BackColor = Color.Black;
                                                pboxAJ3T2.Location = new Point(112, (306 - 28) - 28);
                                            }

                                            break;
                                    }

                                    break;

                                case 3:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T3.Visible = true;
                                                pboxJ3T3.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T3.Visible = true;
                                                pboxAJ3T3.BackColor = Color.Black;
                                            }



                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T3.Visible = true;
                                                pboxJ3T3.BackColor = Color.Green;
                                                pboxJ3T3.Location = new Point(163, 334 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T3.Visible = true;
                                                pboxAJ3T3.BackColor = Color.Black;
                                                pboxAJ3T3.Location = new Point(163, 334 - 28);
                                            }



                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T3.Visible = true;
                                                pboxJ3T3.BackColor = Color.Green;
                                                pboxJ3T3.Location = new Point(163, (334 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T3.Visible = true;
                                                pboxAJ3T3.BackColor = Color.Black;
                                                pboxAJ3T3.Location = new Point(163, (334 - 28) - 28);
                                            }




                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T3.Visible = true;
                                                pboxJ3T3.BackColor = Color.Green;
                                                pboxJ3T3.Location = new Point(163, 334 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T3.Visible = true;
                                                pboxAJ3T3.BackColor = Color.Black;
                                                pboxAJ3T3.Location = new Point(163, 334 - (28 * 3));
                                            }




                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T3.Visible = true;
                                                pboxJ3T3.BackColor = Color.Green;
                                                pboxJ3T3.Location = new Point(163, 334 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T3.Visible = true;
                                                pboxAJ3T3.BackColor = Color.Black;
                                                pboxAJ3T3.Location = new Point(163, 334 - (28 * 4));
                                            }




                                            break;
                                    }
                                    break;

                                case 4:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, 363 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Black;
                                                pboxAJ3T4.Location = new Point(217, 363 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, (363 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Black;
                                                pboxAJ3T4.Location = new Point(217, (363 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, 363 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Black;
                                                pboxAJ3T4.Location = new Point(217, 363 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, 363 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Green;
                                                pboxAJ3T4.Location = new Point(217, 363 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, 363 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Black;
                                                pboxAJ3T4.Location = new Point(217, 363 - (28 * 5));
                                            }




                                            break;
                                        case 7:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T4.Visible = true;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, 363 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T4.Visible = true;
                                                pboxAJ3T4.BackColor = Color.Black;
                                                pboxAJ3T4.Location = new Point(217, 363 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 5:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;

                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;

                                            }


                                            break;

                                        case 2:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, (391 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, (391 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - (28 * 3));
                                            }


                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T5.Visible = true;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T5.Visible = true;
                                                pboxAJ3T5.BackColor = Color.Black;
                                                pboxAJ3T5.Location = new Point(270, 391 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;

                                case 6:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - 28);
                                            }

                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, (420 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, (420 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T6.Visible = true;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ3T6.Visible = true;
                                                pboxAJ3T6.BackColor = Color.Black;
                                                pboxAJ3T6.Location = new Point(323, 420 - (28 * 10));
                                            }

                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - 28);
                                            }



                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - 28);
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 10));
                                            }

                                            break;
                                        case 12:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 11));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 11));
                                            }

                                            break;
                                        case 13:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T7.Visible = true;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 12));
                                            }
                                            else
                                            {
                                                pboxAJ3T7.Visible = true;
                                                pboxAJ3T7.BackColor = Color.Black;
                                                pboxAJ3T7.Location = new Point(376, 447 - (28 * 12));
                                            }

                                            break;
                                    }
                                    break;
                                case 8:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, (420 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, (420 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 8));
                                            }

                                            break;
                                        case 11:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T8.Visible = true;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T8.Visible = true;
                                                pboxAJ3T8.BackColor = Color.Black;
                                                pboxAJ3T8.Location = new Point(429, 420 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 9:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, (391 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, (391 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T9.Visible = true;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ3T9.Visible = true;
                                                pboxAJ3T9.BackColor = Color.Black;
                                                pboxAJ3T9.Location = new Point(482, 391 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 10:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, 363 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                                pboxAJ3T10.Location = new Point(536, 363 - 28);
                                            }




                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, (363 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                                pboxAJ3T10.Location = new Point(536, (363 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, 363 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                                pboxAJ3T10.Location = new Point(536, 363 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, 363 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                                pboxAJ3T10.Location = new Point(536, 363 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, 363 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                                pboxAJ3T10.Location = new Point(536, 363 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T10.Visible = true;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, 363 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ3T10.Visible = true;
                                                pboxAJ3T10.BackColor = Color.Black;
                                                pboxAJ3T10.Location = new Point(536, 363 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 11:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T11.Visible = true;
                                                pboxJ3T11.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T11.Visible = true;
                                                pboxAJ3T11.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T11.Visible = true;
                                                pboxJ3T11.BackColor = Color.Green;
                                                pboxJ3T11.Location = new Point(589, 334 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T11.Visible = true;
                                                pboxAJ3T11.BackColor = Color.Black;
                                                pboxAJ3T11.Location = new Point(589, 334 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T11.Visible = true;
                                                pboxJ3T11.BackColor = Color.Green;
                                                pboxJ3T11.Location = new Point(589, (334 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T11.Visible = true;
                                                pboxAJ3T11.BackColor = Color.Black;
                                                pboxAJ3T11.Location = new Point(589, (334 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T11.Visible = true;
                                                pboxJ3T11.BackColor = Color.Green;
                                                pboxJ3T11.Location = new Point(589, 334 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ3T11.Visible = true;
                                                pboxAJ3T11.BackColor = Color.Black;
                                                pboxAJ3T11.Location = new Point(589, 334 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T11.Visible = true;
                                                pboxJ3T11.BackColor = Color.Green;
                                                pboxJ3T11.Location = new Point(589, 334 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ3T11.Visible = true;
                                                pboxAJ3T11.BackColor = Color.Black;
                                                pboxAJ3T11.Location = new Point(589, 334 - (28 * 4));
                                            }

                                            break;
                                    }
                                    break;

                                case 12:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T12.Visible = true;
                                                pboxJ3T12.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                pboxAJ3T12.Visible = true;
                                                pboxAJ3T12.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T12.Visible = true;
                                                pboxJ3T12.BackColor = Color.Green;
                                                pboxJ3T12.Location = new Point(642, 306 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T12.Visible = true;
                                                pboxAJ3T12.BackColor = Color.Black;
                                                pboxAJ3T12.Location = new Point(642, 306 - 28);
                                            }

                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ3T12.Visible = true;
                                                pboxJ3T12.BackColor = Color.Green;
                                                pboxJ3T12.Location = new Point(642, (306 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ3T12.Visible = true;
                                                pboxAJ3T12.BackColor = Color.Black;
                                                pboxAJ3T12.Location = new Point(642, (306 - 28) - 28);
                                            }

                                            break;
                                    }


                                    break;

                            }


                            break;


                        case 4://Jogador4
                            switch (Status.trilha)
                            {

                                case 2:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T2.Visible = true;
                                                pboxJ4T2.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T2.Visible = true;
                                                pboxAJ4T2.BackColor = Color.Black;
                                            }

                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T2.Visible = true;
                                                pboxJ4T2.BackColor = Color.Yellow;
                                                pboxJ4T2.Location = new Point(129, 306 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T2.Visible = true;
                                                pboxAJ4T2.BackColor = Color.Black;
                                                pboxAJ4T2.Location = new Point(129, 306 - 28);
                                            }


                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T2.Visible = true;
                                                pboxJ4T2.BackColor = Color.Yellow;
                                                pboxJ4T2.Location = new Point(129, (306 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T2.Visible = true;
                                                pboxAJ4T2.BackColor = Color.Black;
                                                pboxAJ4T2.Location = new Point(129, (306 - 28) - 28);
                                            }

                                            break;
                                    }

                                    break;

                                case 3:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T3.Visible = true;
                                                pboxJ4T3.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T3.Visible = true;
                                                pboxAJ4T3.BackColor = Color.Black;
                                            }



                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T3.Visible = true;
                                                pboxJ4T3.BackColor = Color.Yellow;
                                                pboxJ4T3.Location = new Point(181, 334 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T3.Visible = true;
                                                pboxAJ4T3.BackColor = Color.Black;
                                                pboxAJ4T3.Location = new Point(181, 334 - 28);
                                            }



                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T3.Visible = true;
                                                pboxJ4T3.BackColor = Color.Yellow;
                                                pboxJ4T3.Location = new Point(181, (334 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T3.Visible = true;
                                                pboxAJ4T3.BackColor = Color.Black;
                                                pboxAJ4T3.Location = new Point(181, (334 - 28) - 28);
                                            }




                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T3.Visible = true;
                                                pboxJ4T3.BackColor = Color.Yellow;
                                                pboxJ4T3.Location = new Point(181, 334 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T3.Visible = true;
                                                pboxAJ4T3.BackColor = Color.Black;
                                                pboxAJ4T3.Location = new Point(181, 334 - (28 * 3));
                                            }




                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T3.Visible = true;
                                                pboxJ4T3.BackColor = Color.Yellow;
                                                pboxJ4T3.Location = new Point(181, 334 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T3.Visible = true;
                                                pboxAJ4T3.BackColor = Color.Black;
                                                pboxAJ4T3.Location = new Point(181, 334 - (28 * 4));
                                            }




                                            break;
                                    }
                                    break;

                                case 4:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, 363 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Black;
                                                pboxAJ4T4.Location = new Point(235, 363 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, (363 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Black;
                                                pboxAJ4T4.Location = new Point(235, (363 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, 363 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Black;
                                                pboxAJ4T4.Location = new Point(235, 363 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, 363 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Green;
                                                pboxAJ4T4.Location = new Point(235, 363 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, 363 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Black;
                                                pboxAJ4T4.Location = new Point(235, 363 - (28 * 5));
                                            }




                                            break;
                                        case 7:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T4.Visible = true;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, 363 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T4.Visible = true;
                                                pboxAJ4T4.BackColor = Color.Black;
                                                pboxAJ4T4.Location = new Point(235, 363 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 5:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;

                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;

                                            }


                                            break;

                                        case 2:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, (391 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, (391 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - (28 * 3));
                                            }


                                            break;
                                        case 5:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T5.Visible = true;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T5.Visible = true;
                                                pboxAJ4T5.BackColor = Color.Black;
                                                pboxAJ4T5.Location = new Point(287, 391 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;

                                case 6:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - 28);
                                            }

                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, (420 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, (420 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T6.Visible = true;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ4T6.Visible = true;
                                                pboxAJ4T6.BackColor = Color.Black;
                                                pboxAJ4T6.Location = new Point(341, 420 - (28 * 10));
                                            }

                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (Status.position)
                                    {
                                        case 1:


                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - 28);
                                            }



                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - 28);
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 10));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 10));
                                            }

                                            break;
                                        case 12:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 11));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 11));
                                            }

                                            break;
                                        case 13:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T7.Visible = true;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 12));
                                            }
                                            else
                                            {
                                                pboxAJ4T7.Visible = true;
                                                pboxAJ4T7.BackColor = Color.Black;
                                                pboxAJ4T7.Location = new Point(395, 447 - (28 * 12));
                                            }

                                            break;
                                    }
                                    break;
                                case 8:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, (420 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, (420 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 8));
                                            }

                                            break;
                                        case 10:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 8));
                                            }

                                            break;
                                        case 11:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T8.Visible = true;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T8.Visible = true;
                                                pboxAJ4T8.BackColor = Color.Black;
                                                pboxAJ4T8.Location = new Point(447, 420 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 9:
                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                            }

                                            break;
                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, (391 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, (391 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - (28 * 6));
                                            }

                                            break;
                                        case 8:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 7));
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - (28 * 7));
                                            }

                                            break;
                                        case 9:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T9.Visible = true;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 8));
                                            }
                                            else
                                            {
                                                pboxAJ4T9.Visible = true;
                                                pboxAJ4T9.BackColor = Color.Black;
                                                pboxAJ4T9.Location = new Point(500, 391 - (28 * 8));
                                            }

                                            break;
                                    }
                                    break;
                                case 10:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, 363 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                                pboxAJ4T10.Location = new Point(553, 363 - 28);
                                            }




                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, (363 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                                pboxAJ4T10.Location = new Point(553, (363 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, 363 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                                pboxAJ4T10.Location = new Point(553, 363 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, 363 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                                pboxAJ4T10.Location = new Point(553, 363 - (28 * 4));
                                            }

                                            break;
                                        case 6:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, 363 - (28 * 5));
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                                pboxAJ4T10.Location = new Point(553, 363 - (28 * 5));
                                            }

                                            break;
                                        case 7:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T10.Visible = true;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, 363 - (28 * 6));
                                            }
                                            else
                                            {
                                                pboxAJ4T10.Visible = true;
                                                pboxAJ4T10.BackColor = Color.Black;
                                                pboxAJ4T10.Location = new Point(553, 363 - (28 * 6));
                                            }

                                            break;
                                    }
                                    break;

                                case 11:

                                    switch (Status.position)
                                    {
                                        case 1:


                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T11.Visible = true;
                                                pboxJ4T11.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T11.Visible = true;
                                                pboxAJ4T11.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T11.Visible = true;
                                                pboxJ4T11.BackColor = Color.Yellow;
                                                pboxJ4T11.Location = new Point(607, 334 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T11.Visible = true;
                                                pboxAJ4T11.BackColor = Color.Black;
                                                pboxAJ4T11.Location = new Point(607, 334 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T11.Visible = true;
                                                pboxJ4T11.BackColor = Color.Yellow;
                                                pboxJ4T11.Location = new Point(607, (334 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T11.Visible = true;
                                                pboxAJ4T11.BackColor = Color.Black;
                                                pboxAJ4T11.Location = new Point(607, (334 - 28) - 28);
                                            }

                                            break;
                                        case 4:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T11.Visible = true;
                                                pboxJ4T11.BackColor = Color.Yellow;
                                                pboxJ4T11.Location = new Point(607, 334 - (28 * 3));
                                            }
                                            else
                                            {
                                                pboxAJ4T11.Visible = true;
                                                pboxAJ4T11.BackColor = Color.Black;
                                                pboxAJ4T11.Location = new Point(607, 334 - (28 * 3));
                                            }

                                            break;
                                        case 5:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T11.Visible = true;
                                                pboxJ4T11.BackColor = Color.Yellow;
                                                pboxJ4T11.Location = new Point(607, 334 - (28 * 4));
                                            }
                                            else
                                            {
                                                pboxAJ4T11.Visible = true;
                                                pboxAJ4T11.BackColor = Color.Black;
                                                pboxAJ4T11.Location = new Point(607, 334 - (28 * 4));
                                            }

                                            break;
                                    }
                                    break;

                                case 12:

                                    switch (Status.position)
                                    {
                                        case 1:

                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T12.Visible = true;
                                                pboxJ3T12.BackColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                pboxAJ4T12.Visible = true;
                                                pboxAJ4T12.BackColor = Color.Black;
                                            }


                                            break;

                                        case 2:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T12.Visible = true;
                                                pboxJ4T12.BackColor = Color.Yellow;
                                                pboxJ4T12.Location = new Point(660, 306 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T12.Visible = true;
                                                pboxAJ4T12.BackColor = Color.Black;
                                                pboxAJ4T12.Location = new Point(660, 306 - 28);
                                            }

                                            break;
                                        case 3:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ4T12.Visible = true;
                                                pboxJ4T12.BackColor = Color.Yellow;
                                                pboxJ4T12.Location = new Point(660, (306 - 28) - 28);
                                            }
                                            else
                                            {
                                                pboxAJ4T12.Visible = true;
                                                pboxAJ4T12.BackColor = Color.Black;
                                                pboxAJ4T12.Location = new Point(660, (306 - 28) - 28);
                                            }

                                            break;
                                    }


                                    break;

                            }

                            break;

                    }



                    i++;
                }

                MessageBox.Show(status);
            }
        }
    }
}