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
        int idJuqui;
        Jogador Player;
        Jogadas joga = new Jogadas("0");
        
        
        List<Jogador> listaDeJogadores = new List<Jogador>();
        List<Dado> listaDeDados = new List<Dado>();
        List<Jogadas> listaDeJogadas = new List<Jogadas>();
        List<FilWin> ListadeFileiras = new List<FilWin>();

        int alp = 3;
        int dado12 = 0, dado13 = 0, dado14 = 0, dado24 = 0, dado23 = 0, dado34 = 0;
        string d1234, d1324, d1423, dado12S, dado13S, dado14S, dado24S, dado23S, dado34S;
        
        

        public Tabuleiro()
        {
            form1.ShowDialog();
            InitializeComponent();

            timer1.Enabled = true;
            string dadosJogadores = Jogo.ListarJogadores(form1.idPartida);

            dadosJogadores = dadosJogadores.Replace("\r", "");
            string[] _jogadores = dadosJogadores.Split('\n');
            foreach (string linha in _jogadores)
            {
                if (linha != "")
                {
                    listaDeJogadores.Add(new Jogador(int.Parse(linha.Split(',')[0]), linha.Split(',')[1], linha.Split(',')[2]));
                }
            }
            foreach (Jogador jogador in listaDeJogadores)
            {
                txtJogadores.Text += jogador.Id + ": " + jogador.Nome + "\r\n";
            }

            foreach (Jogador idJogador in listaDeJogadores)
            {
                if (idJogador.Nome.ToUpper() == "JUQUITIBA")
                {
                    idJuqui = idJogador.Id;
                }
                Player = idJogador;
            }

        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtHistorico.Text = Jogo.ExibirHistorico(form1.idPartida);
            lblqtdAlp.Text = alp.ToString();
            if (alp == 0)
            {
                parar();
            }
            else
            {

                string retorno = Jogo.VerificarVez(form1.idPartida);
                retorno = retorno.Replace("\r", "");
                retorno = retorno.Replace("\n", "");
                string[] vetor = retorno.Split(',');

                if (vetor[0].StartsWith("ERRO"))
                {
                    MessageBox.Show(vetor[0]);
                }
                else
                {

                    foreach (Jogador jogador in listaDeJogadores)
                    {
                        if (vetor[1] == jogador.Id.ToString())
                        {
                            lblJogador.Text = jogador.Cor;
                        }
                        else
                        {
                            atualizaTabu();
                        }
                    }
                    if (vetor[1] == idJuqui.ToString())
                    {
                        rolaDado();
                        timer1.Enabled = false;
                        mover();
                        txtHistorico.Text = Jogo.ExibirHistorico(form1.idPartida);
                        lblqtdAlp.Text = alp.ToString();

                    }
                    else
                    {
                        atualizaTabu();
                    }

                }

                atualizaTabu();
            }
        }

        public void mover()
        {
            string erro;
            string retorno = escolha();
            string[] vetor = retorno.Split(',');


            erro = Jogo.Mover(idJuqui, form1.Senha, vetor[0], vetor[1]);
            if (erro.StartsWith("ERRO"))
            {
                MessageBox.Show(erro);
            }
            else
            {
                listaDeDados.Clear();
                atualizaTabu();
                timer1.Enabled = true;
            }
        }

        public void rolaDado()
        {
            string dados = Jogo.RolarDados(form1.IdJogador, form1.Senha);
            if (dados.StartsWith("ERRO"))
            {
                MessageBox.Show(dados);
            }
            else
            {

                dados = dados.Replace("\r", "");
                string[] _linha = dados.Split('\n');

                double[] dadoInt = { Convert.ToDouble(_linha[0]) / 10, Convert.ToDouble(_linha[1]) / 10, Convert.ToDouble(_linha[2]) / 10, Convert.ToDouble(_linha[3]) / 10 };
                string[] dadoString = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    dadoString[i] = Convert.ToString(dadoInt[i]);
                }
                int j = 0;
                foreach (string linha in dadoString)
                {

                    listaDeDados.Add(new Dado(int.Parse(dadoString[j].Split(',')[1]), int.Parse(dadoString[j].Split(',')[0])));
                    j++;
                }

                if (listaDeDados[0].Numero == 1)
                    picbxDado1.Image = Aplicativo1.Properties.Resources.dado1;
                if (listaDeDados[0].Numero == 2)
                    picbxDado1.Image = Aplicativo1.Properties.Resources.dado2;
                if (listaDeDados[0].Numero == 3)
                    picbxDado1.Image = Aplicativo1.Properties.Resources.dado3;
                if (listaDeDados[0].Numero == 4)
                    picbxDado1.Image = Aplicativo1.Properties.Resources.dado4;
                if (listaDeDados[0].Numero == 5)
                    picbxDado1.Image = Aplicativo1.Properties.Resources.dado5;
                if (listaDeDados[0].Numero == 6)
                    picbxDado1.Image = Aplicativo1.Properties.Resources.dado6;

                if (listaDeDados[1].Numero == 1)
                    picbxDado2.Image = Aplicativo1.Properties.Resources.dado1;
                if (listaDeDados[1].Numero == 2)
                    picbxDado2.Image = Aplicativo1.Properties.Resources.dado2;
                if (listaDeDados[1].Numero == 3)
                    picbxDado2.Image = Aplicativo1.Properties.Resources.dado3;
                if (listaDeDados[1].Numero == 4)
                    picbxDado2.Image = Aplicativo1.Properties.Resources.dado4;
                if (listaDeDados[1].Numero == 5)
                    picbxDado2.Image = Aplicativo1.Properties.Resources.dado5;
                if (listaDeDados[1].Numero == 6)
                    picbxDado2.Image = Aplicativo1.Properties.Resources.dado6;

                if (listaDeDados[2].Numero == 1)
                    picbxDado3.Image = Aplicativo1.Properties.Resources.dado1;
                if (listaDeDados[2].Numero == 2)
                    picbxDado3.Image = Aplicativo1.Properties.Resources.dado2;
                if (listaDeDados[2].Numero == 3)
                    picbxDado3.Image = Aplicativo1.Properties.Resources.dado3;
                if (listaDeDados[2].Numero == 4)
                    picbxDado3.Image = Aplicativo1.Properties.Resources.dado4;
                if (listaDeDados[2].Numero == 5)
                    picbxDado3.Image = Aplicativo1.Properties.Resources.dado5;
                if (listaDeDados[2].Numero == 6)
                    picbxDado3.Image = Aplicativo1.Properties.Resources.dado6;

                if (listaDeDados[3].Numero == 1)
                    picbxDado4.Image = Aplicativo1.Properties.Resources.dado1;
                if (listaDeDados[3].Numero == 2)
                    picbxDado4.Image = Aplicativo1.Properties.Resources.dado2;
                if (listaDeDados[3].Numero == 3)
                    picbxDado4.Image = Aplicativo1.Properties.Resources.dado3;
                if (listaDeDados[3].Numero == 4)
                    picbxDado4.Image = Aplicativo1.Properties.Resources.dado4;
                if (listaDeDados[3].Numero == 5)
                    picbxDado4.Image = Aplicativo1.Properties.Resources.dado5;
                if (listaDeDados[3].Numero == 6)
                    picbxDado4.Image = Aplicativo1.Properties.Resources.dado6;

                dado12 = listaDeDados[0].Numero + listaDeDados[1].Numero;
                dado13 = listaDeDados[0].Numero + listaDeDados[2].Numero;
                dado14 = listaDeDados[0].Numero + listaDeDados[3].Numero;
                dado24 = listaDeDados[1].Numero + listaDeDados[3].Numero;
                dado23 = listaDeDados[1].Numero + listaDeDados[2].Numero;
                dado34 = listaDeDados[2].Numero + listaDeDados[3].Numero;



                dado12S = dado12.ToString();
                dado13S = dado13.ToString();
                dado14S = dado14.ToString();
                dado24S = dado24.ToString();
                dado23S = dado23.ToString();
                dado34S = dado34.ToString();


                d1234 = dado12S + dado34S;
                d1324 = dado13S + dado24S;
                d1423 = dado14S + dado23S;

                


            }
        }

        public void hex1234()
        {
            if (dado12 == 10 || dado12 == 11 || dado12 == 12)
                dado12S = dado12.ToString("X");

            if (dado34 == 10 || dado34 == 11 || dado34 == 12)
                dado34S = dado34.ToString("X");
        }
        public void hex1423()
        {
            if (dado14 == 10 || dado14 == 11 || dado14 == 12)
                dado14S = dado14.ToString("X");

            if (dado23 == 10 || dado23 == 11 || dado23 == 12)
                dado23S = dado23.ToString("X");
        }

        public void hex1324()
        {
            if (dado13 == 10 || dado13 == 11 || dado13 == 12)
                dado13S = dado13.ToString("X");

            if (dado24 == 10 || dado24 == 11 || dado24 == 12)
                dado24S = dado24.ToString("X");
        }


        public string escolha()
        {
            
            if (alp == 3)
            {

                foreach (FilWin fila in ListadeFileiras)
                {

                    if (dado12.ToString() == fila.Filwin && dado34.ToString() == fila.Filwin)
                    {

                        if (dado14.ToString() == fila.Filwin && dado23.ToString() == fila.Filwin)
                        {

                            if (dado24 == dado13 && dado24.ToString() != fila.Filwin)
                            {
                                hex1324();
                                alp -= 2;

                                listaDeJogadas.Add(new Jogadas(dado13S));
                                listaDeJogadas.Add(new Jogadas(dado24S));
                                return ("1324," + dado13S + dado24S);

                            }

                            if (dado24.ToString() == fila.Filwin)
                            {
                                hex1324();
                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado13S));
                                
                                return ("1324," + dado13S + "0");
                            }

                            if (dado13.ToString() == fila.Filwin)
                            {
                                hex1324();

                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado24S));
                                return ("2413," + dado24S + "0");
                            }
                        }
                        else
                        {

                            if (dado14 == dado23 && dado14.ToString() != fila.Filwin)
                            {
                                hex1423();
                                alp -= 2;
                                listaDeJogadas.Add(new Jogadas(dado14S));
                                listaDeJogadas.Add(new Jogadas(dado23S));

                                return ("1423," + dado14S + dado23S);

                            }

                            if (dado14.ToString() == fila.Filwin)
                            {
                                hex1423();
                                alp -= 1;
                                listaDeJogadas.Add(new Jogadas(dado23S));

                                return ("2314," + dado23S + "0");
                            }

                            if (dado23.ToString() == fila.Filwin)
                            {
                                hex1423();

                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado14S));

                                return ("1423," + dado14S + "0");
                            }

                        }

                    }
                    else
                    {

                        if (dado12 == dado24 && dado12.ToString() != fila.Filwin)
                        {
                            hex1234();
                            alp -= 2;

                            listaDeJogadas.Add(new Jogadas(dado12S));
                            listaDeJogadas.Add(new Jogadas(dado34S));
                            return ("1234," + dado12S + dado34S);

                        }

                        if (dado12.ToString() == fila.Filwin)
                        {
                            hex1234();

                            alp -= 1;

                            listaDeJogadas.Add(new Jogadas(dado34S));
                           

                            return ("3412," + dado34S + "0");
                        }

                        if (dado34.ToString() == fila.Filwin)
                        {
                            hex1234();

                            alp -= 1;

                            listaDeJogadas.Add(new Jogadas(dado34S));
                            return ("1234," + dado12S + "0");
                        }

                        
                    }
                }

                if (dado12 == dado34)
                {

                    hex1234();

                    alp -= 1;
                    listaDeJogadas.Add(new Jogadas(dado12S));
                    listaDeJogadas.Add(new Jogadas(dado34S));
                    return ("1234," + dado12S + dado34S);

                }
                else
                {
                    hex1234();

                    alp -= 2;
                    listaDeJogadas.Add(new Jogadas(dado12S));
                    listaDeJogadas.Add(new Jogadas(dado34S));
                    return ("1234," + dado12S + dado34S);

                }
            }
            if (alp == 2)
            {
                foreach (FilWin fila in ListadeFileiras) 
                {

                    if (dado12.ToString() == fila.Filwin && dado34.ToString() == fila.Filwin)
                    {

                        if (dado14.ToString() == fila.Filwin && dado23.ToString() == fila.Filwin)
                        {

                            if (dado24 == dado13 && dado24.ToString() != fila.Filwin)
                            {
                                hex1324();
                                alp -= 2;

                                listaDeJogadas.Add(new Jogadas(dado13S));
                                listaDeJogadas.Add(new Jogadas(dado24S));
                                return ("1324," + dado13S + dado24S);

                            }

                            if (dado24.ToString() == fila.Filwin)
                            {
                                hex1324();
                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado13S));

                                return ("1324," + dado13S + "0");
                            }

                            if (dado13.ToString() == fila.Filwin)
                            {
                                hex1324();

                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado24S));
                                return ("2413," + dado24S + "0");
                            }
                        }
                        else
                        {

                            if (dado14 == dado23 && dado14.ToString() != fila.Filwin)
                            {
                                hex1423();
                                alp -= 2;
                                listaDeJogadas.Add(new Jogadas(dado14S));
                                listaDeJogadas.Add(new Jogadas(dado23S));

                                return ("1423," + dado14S + dado23S);

                            }

                            if (dado14.ToString() == fila.Filwin)
                            {
                                hex1423();
                                alp -= 1;
                                listaDeJogadas.Add(new Jogadas(dado23S));

                                return ("2314," + dado23S + "0");
                            }

                            if (dado23.ToString() == fila.Filwin)
                            {
                                hex1423();

                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado14S));

                                return ("1423," + dado14S + "0");
                            }

                        }

                    }
                    else
                    {

                        if (dado12 == dado24 && dado12.ToString() != fila.Filwin)
                        {
                            hex1234();
                            alp -= 2;

                            listaDeJogadas.Add(new Jogadas(dado12S));
                            listaDeJogadas.Add(new Jogadas(dado34S));
                            return ("1234," + dado12S + dado34S);

                        }

                        if (dado12.ToString() == fila.Filwin)
                        {
                            hex1234();

                            alp -= 1;

                            listaDeJogadas.Add(new Jogadas(dado34S));


                            return ("3412," + dado34S + "0");
                        }

                        if (dado34.ToString() == fila.Filwin)
                        {
                            hex1234();

                            alp -= 1;

                            listaDeJogadas.Add(new Jogadas(dado34S));
                            return ("1234," + dado12S + "0");
                        }


                    }
                }


                if (dado12 == dado34)
                    {
                        hex1234();

                            listaDeJogadas.Add(new Jogadas(dado12S));
                            listaDeJogadas.Add(new Jogadas(dado34S));
                    alp -= 1;
                        return ("1234," + dado12S + dado34S);
                    }
                    else
                    {
                        hex1234();


                        listaDeJogadas.Add(new Jogadas(dado12S));
                        listaDeJogadas.Add(new Jogadas(dado34S));

                        alp -= 2;
                        return ("1234," + dado12S + dado34S);
                    }
            }


            if (alp == 1)
            {
                //ABAIXO VAI DAR MERDA
                foreach (FilWin fila in ListadeFileiras)
                {

                    if (dado12.ToString() == fila.Filwin && dado34.ToString() == fila.Filwin)
                    {

                        if (dado14.ToString() == fila.Filwin && dado23.ToString() == fila.Filwin)
                        {

                            if (dado24 == dado13 && dado24.ToString() != fila.Filwin)
                            {
                                hex1324();
                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado13S));
                                listaDeJogadas.Add(new Jogadas(dado24S));
                                return ("1324," + dado13S + dado24S);

                            }

                            if (dado24.ToString() == fila.Filwin)
                            {
                                hex1324();
                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado13S));

                                return ("1324," + dado13S + "0");
                            }

                            if (dado13.ToString() == fila.Filwin)
                            {
                                hex1324();

                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado24S));
                                return ("2413," + dado24S + "0");
                            }
                        }
                        else
                        {

                            if (dado14 == dado23 && dado14.ToString() != fila.Filwin)
                            {
                                hex1423();
                                alp -= 2;
                                listaDeJogadas.Add(new Jogadas(dado14S));
                                listaDeJogadas.Add(new Jogadas(dado23S));

                                return ("1423," + dado14S + dado23S);

                            }

                            if (dado14.ToString() == fila.Filwin)
                            {
                                hex1423();
                                alp -= 1;
                                listaDeJogadas.Add(new Jogadas(dado23S));

                                return ("2314," + dado23S + "0");
                            }

                            if (dado23.ToString() == fila.Filwin)
                            {
                                hex1423();

                                alp -= 1;

                                listaDeJogadas.Add(new Jogadas(dado14S));

                                return ("1423," + dado14S + "0");
                            }

                        }

                    }
                    else
                    {

                        if (dado12 == dado24 && dado12.ToString() != fila.Filwin)
                        {
                            hex1234();
                            alp -= 2;

                            listaDeJogadas.Add(new Jogadas(dado12S));
                            listaDeJogadas.Add(new Jogadas(dado34S));
                            return ("1234," + dado12S + dado34S);

                        }

                        if (dado12.ToString() == fila.Filwin)
                        {
                            hex1234();

                            alp -= 1;

                            listaDeJogadas.Add(new Jogadas(dado34S));


                            return ("3412," + dado34S + "0");
                        }

                        if (dado34.ToString() == fila.Filwin)
                        {
                            hex1234();

                            alp -= 1;

                            listaDeJogadas.Add(new Jogadas(dado34S));
                            return ("1234," + dado12S + "0");
                        }


                    }
                }
                //ACIMA VAI DAR MERDA


                if (dado12 == dado34)
                    {
                        hex1234();

                        alp -= 1;
                        return ("1234," + dado12S + dado34S);

                    }
                    else
                    {
                        hex1234();
                        foreach (Jogadas jogada in listaDeJogadas)
                        {
                            if(dado12.ToString() == jogada.Poze)
                            {
                                if(dado34.ToString() == jogada.Poze)
                                {
                                    return ("1234," + dado12S + dado34S);
                                }

                                alp -= 1;
                                return ("1234," + dado12S + dado34S);

                             }

                            if (dado34.ToString() == jogada.Poze)
                            {
                                if (dado12.ToString() == jogada.Poze)
                                {
                                    return ("1234," + dado12S + dado34S);
                                }

                                alp -= 1;
                                return ("1234," + dado12S + dado34S);

                            }


                        }

                        alp -= 1;
                        return ("1234," + dado12S + "0");
                    }

                
                /* foreach (Jogadas jogada in listaDeJogadas)
                 {

                     if (dado12.ToString() == jogada.Poze)
                         pode1 = true;

                     if (dado34.ToString() == jogada.Poze)
                         pode2 = true;

                     if (pode1 && pode2 )
                     {
                         hex1234();
                         return ("1234," + dado12S + dado34S);
                     }


                     if (jogada.Poze == dado12S || jogada.Poze == dado34S)
                     {
                         hex1234();
                         alp -= 1;
                         return ("1234," + dado12S + dado34S);
                     }


                     if (dado12 == dado34 && dado12.ToString() == jogada.Poze)
                     {
                         hex1234();
                         return ("1234," + dado12S + dado34S);

                     }

                     if (dado12 == dado34 && dado12.ToString() != jogada.Poze)
                     {
                         hex1234();
                         alp -= 1;
                         return ("1234," + dado12S + "0");
                     }

                  }


                 hex1234();
                 alp -= 1;
                 return ("1234," + dado12S + "0");
             }*/

                
            }
            return null;
        }
        



        public void parar()
        {
            string erroParar;

            erroParar = Jogo.Parar(idJuqui, form1.Senha);

            if (erroParar.StartsWith("ERRO"))
            {
                MessageBox.Show(erroParar);
            }
            else
            {
                atualizaTabu();
                listaDeJogadas.Clear();
                alp = 3;
            }
        }
        


        private void btnMover_Click(object sender, EventArgs e)
        {
            mover();
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            parar();
        }


        /*public string somaDado()
        {
            int dado12 = listaDeDados[0].Numero + listaDeDados[1].Numero;
            int dado13 = listaDeDados[0].Numero + listaDeDados[2].Numero;
            int dado14 = listaDeDados[0].Numero + listaDeDados[3].Numero;
            int dado24 = listaDeDados[1].Numero + listaDeDados[3].Numero;
            int dado23 = listaDeDados[1].Numero + listaDeDados[2].Numero;
            int dado34 = listaDeDados[2].Numero + listaDeDados[3].Numero;

            string D1234 = dado12.ToString() + dado34.ToString();
            string D1324 = dado13.ToString() + dado24.ToString();
            string D1423 = dado14.ToString() + dado23.ToString();

            string combinacao = D1234 
            return;
        }*/

        private void btn_statusTabu_Click(object sender, EventArgs e)
        {
            atualizaTabu();
        }

        public void atualizaTabu()
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
                    StatusTabu Status = new StatusTabu(Convert.ToInt32(dados[0]), Convert.ToInt32(dados[1]), Convert.ToInt32(dados[2]), Convert.ToChar(dados[3]), listaDeJogadores);
                    Status.position += mais1;


                    switch (Status.Jogador.Posicao)
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
                                                pboxAJ1T2.Visible = false;
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
                                                pboxAJ1T2.Visible = false;
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
                                                pboxJ1T2.BackColor = Color.Red;
                                                pboxAJ1T2.Visible = false;
                                                pboxJ1T2.Location = new Point(112, (296 - 28) - 28);
                                                pboxJ1T2.Visible = false;
                                                pboxJ2T2.Visible = false;
                                                pboxJ3T2.Visible = false;
                                                pboxJ4T2.Visible = false;
                                                C2.BackColor = Color.Red;
                                                C22.BackColor = Color.Red;
                                                C23.BackColor = Color.Red;
                                                C2.Visible = true;
                                                C22.Visible = true;
                                                C23.Visible = true;
                                                ListadeFileiras.Add(new FilWin("2"));


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
                                                pboxAJ1T3.Visible = false;
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
                                                pboxAJ1T3.Visible = false;
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
                                                pboxAJ1T3.Visible = false;
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
                                                pboxAJ1T3.Visible = false;
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
                                                
                                                pboxJ1T3.BackColor = Color.Red;
                                                pboxAJ1T3.Visible = false;
                                                pboxJ1T3.Location = new Point(163, 325 - (28 * 4));
                                                pboxJ1T3.Visible = false;
                                                pboxJ2T3.Visible = false;
                                                pboxJ3T3.Visible = false;
                                                pboxJ4T3.Visible = false;
                                                C3.BackColor = Color.Red;
                                                C32.BackColor = Color.Red;
                                                C33.BackColor = Color.Red;
                                                C34.BackColor = Color.Red;
                                                C35.BackColor = Color.Red;
                                                C3.Visible = true;
                                                C32.Visible = true;
                                                C33.Visible = true;
                                                C34.Visible = true;
                                                C35.Visible = true;
                                                ListadeFileiras.Add(new FilWin("3"));
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
                                                pboxAJ1T4.Visible = false;
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
                                                pboxAJ1T4.Visible = false;
                                                pboxJ1T4.Location = new Point(217, 354 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T4.Visible = true;
                                                pboxAJ1T4.BackColor = Color.Black;
                                                pboxAJ1T4.Location = new Point(217, 354 - 28);
                                            }



                                            break;
                                        case 3:
                                            //CHECA COR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T4.Visible = true;
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxAJ1T4.Visible = false;
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
                                                pboxAJ1T4.Visible = false;
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
                                                pboxAJ1T4.Visible = false;
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
                                                pboxAJ1T4.Visible = false;
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
                                                pboxJ1T4.BackColor = Color.Red;
                                                pboxAJ1T4.Visible = false;
                                                pboxJ1T4.Location = new Point(217, 354 - (28 * 6));
                                                pboxJ1T4.Visible = false;
                                                pboxJ2T4.Visible = false;
                                                pboxJ3T4.Visible = false;
                                                pboxJ4T4.Visible = false;
                                                C4.BackColor = Color.Red;
                                                C42.BackColor = Color.Red;
                                                C43.BackColor = Color.Red;
                                                C44.BackColor = Color.Red;
                                                C45.BackColor = Color.Red;
                                                C46.BackColor = Color.Red;
                                                C47.BackColor = Color.Red;
                                                C4.Visible = true;
                                                C42.Visible = true;
                                                C43.Visible = true;
                                                C44.Visible = true;
                                                C45.Visible = true;
                                                C46.Visible = true;
                                                C47.Visible = true;
                                                ListadeFileiras.Add(new FilWin("4"));
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
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
                                                pboxAJ1T5.Visible = false;
                                                pboxJ1T5.BackColor = Color.Red;
                                                pboxJ1T5.Location = new Point(270, 381 - (28 * 8));
                                                pboxJ1T5.Visible = false;
                                                pboxJ2T5.Visible = false;
                                                pboxJ3T5.Visible = false;
                                                pboxJ4T5.Visible = false;
                                                C5.BackColor = Color.Red;
                                                C52.BackColor = Color.Red;
                                                C53.BackColor = Color.Red;
                                                C54.BackColor = Color.Red;
                                                C55.BackColor = Color.Red;
                                                C56.BackColor = Color.Red;
                                                C57.BackColor = Color.Red;
                                                C58.BackColor = Color.Red;
                                                C59.BackColor = Color.Red;
                                                C5.Visible = true;
                                                C52.Visible = true;
                                                C53.Visible = true;
                                                C54.Visible = true;
                                                C55.Visible = true;
                                                C56.Visible = true;
                                                C57.Visible = true;
                                                C58.Visible = true;
                                                C59.Visible = true;
                                                ListadeFileiras.Add(new FilWin("5"));
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
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
                                                pboxAJ1T6.Visible = false;
                                                pboxJ1T6.BackColor = Color.Red;
                                                pboxJ1T6.Visible = false;
                                                pboxJ2T6.Visible = false;
                                                pboxJ3T6.Visible = false;
                                                pboxJ4T6.Visible = false;
                                                C6.BackColor = Color.Red;
                                                C62.BackColor = Color.Red;
                                                C63.BackColor = Color.Red;
                                                C64.BackColor = Color.Red;
                                                C65.BackColor = Color.Red;
                                                C66.BackColor = Color.Red;
                                                C67.BackColor = Color.Red;
                                                C68.BackColor = Color.Red;
                                                C69.BackColor = Color.Red;
                                                C610.BackColor = Color.Red;
                                                C611.BackColor = Color.Red;
                                                C610.BackColor = Color.Red;
                                                C6.Visible = true;
                                                C62.Visible = true;
                                                C63.Visible = true;
                                                C64.Visible = true;
                                                C65.Visible = true;
                                                C66.Visible = true;
                                                C67.Visible = true;
                                                C68.Visible = true;
                                                C69.Visible = true;
                                                C610.Visible = true;
                                                C611.Visible = true;
                                                ListadeFileiras.Add(new FilWin("6"));
                                            }
                                            else
                                            {
                                                pboxJ1T6.Visible = true;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 2));
                                            }
                                            else
                                            {
                                                pboxAJ1T7.Visible = true;
                                                pboxAJ1T7.BackColor = Color.Black;
                                                pboxAJ1T7.Location = new Point(376, 438 - (28 * 2));
                                            }

                                            break;
                                        case 4:
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T7.Visible = true;
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
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
                                                pboxAJ1T7.Visible = false;
                                                pboxJ1T7.BackColor = Color.Red;
                                                pboxJ1T7.Location = new Point(376, 438 - (28 * 12));
                                                pboxJ1T7.Visible = false;
                                                pboxJ2T7.Visible = false;
                                                pboxJ3T7.Visible = false;
                                                pboxJ4T7.Visible = false;
                                                C7.BackColor = Color.Red;
                                                C72.BackColor = Color.Red;
                                                C73.BackColor = Color.Red;
                                                C74.BackColor = Color.Red;
                                                C75.BackColor = Color.Red;
                                                C76.BackColor = Color.Red;
                                                C77.BackColor = Color.Red;
                                                C78.BackColor = Color.Red;
                                                C79.BackColor = Color.Red;
                                                C710.BackColor = Color.Red;
                                                C711.BackColor = Color.Red;
                                                C712.BackColor = Color.Red;
                                                C713.BackColor = Color.Red;
                                                C7.Visible = true;
                                                C72.Visible = true;
                                                C73.Visible = true;
                                                C74.Visible = true;
                                                C75.Visible = true;
                                                C76.Visible = true;
                                                C77.Visible = true;
                                                C78.Visible = true;
                                                C79.Visible = true;
                                                C710.Visible = true;
                                                C711.Visible = true;
                                                C712.Visible = true;
                                                C713.Visible = true;
                                                ListadeFileiras.Add(new FilWin("7"));
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
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
                                                pboxAJ1T8.Visible = false;
                                                pboxJ1T8.BackColor = Color.Red;
                                                pboxJ1T8.Location = new Point(429, 410 - (28 * 8));
                                                pboxJ1T8.Visible = false;
                                                pboxJ2T8.Visible = false;
                                                pboxJ3T8.Visible = false;
                                                pboxJ4T8.Visible = false;
                                                C8.BackColor = Color.Red;
                                                C82.BackColor = Color.Red;
                                                C83.BackColor = Color.Red;
                                                C84.BackColor = Color.Red;
                                                C85.BackColor = Color.Red;
                                                C86.BackColor = Color.Red;
                                                C87.BackColor = Color.Red;
                                                C88.BackColor = Color.Red;
                                                C89.BackColor = Color.Red;
                                                C810.BackColor = Color.Red;
                                                C811.BackColor = Color.Red;
                                                C8.Visible = true;
                                                C82.Visible = true;
                                                C83.Visible = true;
                                                C84.Visible = true;
                                                C85.Visible = true;
                                                C86.Visible = true;
                                                C87.Visible = true;
                                                C88.Visible = true;
                                                C89.Visible = true;
                                                C810.Visible = true;
                                                C811.Visible = true;
                                                ListadeFileiras.Add(new FilWin("8"));
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
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
                                                pboxAJ1T9.Visible = false;
                                                pboxJ1T9.BackColor = Color.Red;
                                                pboxJ1T9.Location = new Point(482, 381 - (28 * 8));
                                                pboxJ1T9.Visible = false;
                                                pboxJ2T9.Visible = false;
                                                pboxJ3T9.Visible = false;
                                                pboxJ4T9.Visible = false;
                                                C9.BackColor = Color.Red;
                                                C92.BackColor = Color.Red;
                                                C93.BackColor = Color.Red;
                                                C94.BackColor = Color.Red;
                                                C95.BackColor = Color.Red;
                                                C96.BackColor = Color.Red;
                                                C97.BackColor = Color.Red;
                                                C98.BackColor = Color.Red;
                                                C99.BackColor = Color.Red;
                                                C9.Visible = true;
                                                C92.Visible = true;
                                                C93.Visible = true;
                                                C94.Visible = true;
                                                C95.Visible = true;
                                                C96.Visible = true;
                                                C97.Visible = true;
                                                C98.Visible = true;
                                                C99.Visible = true;
                                                ListadeFileiras.Add(new FilWin("9"));
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
                                                pboxAJ1T10.Visible = false;
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
                                                pboxAJ1T10.Visible = false;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 354 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ1T10.Visible = true;
                                                pboxAJ1T10.BackColor = Color.Black;
                                                pboxAJ1T10.Location = new Point(536, 354 - 28);
                                            }




                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ1T10.Visible = true;
                                                pboxAJ1T10.Visible = false;
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
                                                pboxAJ1T10.Visible = false;
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
                                                pboxAJ1T10.Visible = false;
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
                                                pboxAJ1T10.Visible = false;
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
                                                pboxAJ1T10.Visible = false;
                                                pboxJ1T10.BackColor = Color.Red;
                                                pboxJ1T10.Location = new Point(536, 354 - (28 * 6));
                                                pboxJ1T10.Visible = false;
                                                pboxJ2T10.Visible = false;
                                                pboxJ3T10.Visible = false;
                                                pboxJ4T10.Visible = false;
                                                C10.BackColor = Color.Red;
                                                C102.BackColor = Color.Red;
                                                C103.BackColor = Color.Red;
                                                C104.BackColor = Color.Red;
                                                C105.BackColor = Color.Red;
                                                C106.BackColor = Color.Red;
                                                C107.BackColor = Color.Red;
                                               
                                                C10.Visible = true;
                                                C102.Visible = true;
                                                C103.Visible = true;
                                                C104.Visible = true;
                                                C105.Visible = true;
                                                C106.Visible = true;
                                                C107.Visible = true;
                                                ListadeFileiras.Add(new FilWin("10"));

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
                                                pboxAJ1T11.Visible = false;
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
                                                pboxAJ1T11.Visible = false;
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
                                                pboxAJ1T11.Visible = false;
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
                                                pboxAJ1T11.Visible = false;
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
                                                pboxAJ1T11.Visible = false;
                                                pboxJ1T11.BackColor = Color.Red;
                                                pboxJ1T11.Location = new Point(589, 325 - (28 * 4));
                                                pboxJ1T11.Visible = false;
                                                pboxJ2T11.Visible = false;
                                                pboxJ3T11.Visible = false;
                                                pboxJ4T11.Visible = false;
                                                C11.BackColor = Color.Red;
                                                C112.BackColor = Color.Red;
                                                C113.BackColor = Color.Red;
                                                C114.BackColor = Color.Red;
                                                C115.BackColor = Color.Red;
                                                C11.Visible = true;
                                                C112.Visible = true;
                                                C113.Visible = true;
                                                C114.Visible = true;
                                                C115.Visible = true;
                                                ListadeFileiras.Add(new FilWin("11"));
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
                                                pboxAJ1T12.Visible = false;
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
                                                pboxAJ1T12.Visible = false;
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
                                                
                                                pboxAJ1T12.Visible = false;
                                                pboxJ1T12.BackColor = Color.Red;
                                                pboxJ1T12.Location = new Point(642, (296 - 28) - 28);
                                                pboxJ1T11.Visible = false;
                                                pboxJ2T12.Visible = false;
                                                pboxJ3T12.Visible = false;
                                                pboxJ4T12.Visible = false;
                                                C12.BackColor = Color.Red;
                                                C122.BackColor = Color.Red;
                                                C123.BackColor = Color.Red;
                                                C12.Visible = true;
                                                C122.Visible = true;
                                                C123.Visible = true;
                                                ListadeFileiras.Add(new FilWin("12"));
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
                                                pboxAJ2T2.Visible = false;
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
                                                pboxAJ2T2.Visible = false;
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
                                                
                                                pboxAJ2T2.Visible = false;
                                                pboxJ2T2.BackColor = Color.Blue;
                                                pboxJ2T2.Location = new Point(129, (296 - 28) - 28);
                                                pboxJ1T2.Visible = false;
                                                pboxJ2T2.Visible = false;
                                                pboxJ3T2.Visible = false;
                                                pboxJ4T2.Visible = false;
                                                C2.BackColor = Color.Blue;
                                                C22.BackColor = Color.Blue;
                                                C23.BackColor = Color.Blue;
                                                C2.Visible = true;
                                                C22.Visible = true;
                                                C23.Visible = true;
                                                
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
                                                pboxAJ2T3.Visible = false;
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
                                                pboxAJ2T3.Visible = false;
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
                                                pboxAJ2T3.Visible = false;
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
                                                pboxAJ2T3.Visible = false;
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
                                                pboxAJ2T3.Visible = false;
                                                pboxJ2T3.BackColor = Color.Blue;
                                                pboxJ2T3.Location = new Point(181, 325 - (28 * 4));
                                                pboxJ1T3.Visible = false;
                                                pboxJ2T3.Visible = false;
                                                pboxJ3T3.Visible = false;
                                                pboxJ4T3.Visible = false;
                                                C3.BackColor = Color.Blue;
                                                C32.BackColor = Color.Blue;
                                                C33.BackColor = Color.Blue;
                                                C34.BackColor = Color.Blue;
                                                C35.BackColor = Color.Blue;
                                                C3.Visible = true;
                                                C32.Visible = true;
                                                C33.Visible = true;
                                                C34.Visible = true;
                                                C35.Visible = true;
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
                                                pboxAJ2T4.Visible = false;
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
                                                pboxAJ2T4.Visible = false;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 354 - 28);
                                            }
                                            else
                                            {
                                                pboxAJ2T4.Visible = true;
                                                pboxAJ2T4.BackColor = Color.Black;
                                                pboxAJ2T4.Location = new Point(235, 354 - 28);
                                            }

                                            break;
                                        case 3:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxJ2T4.Visible = true;
                                                pboxAJ2T4.Visible = false;
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
                                                pboxAJ2T4.Visible = false;
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
                                                pboxAJ2T4.Visible = false;
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
                                                pboxAJ2T4.Visible = false;
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
                                               
                                                pboxAJ2T4.Visible = false;
                                                pboxJ2T4.BackColor = Color.Blue;
                                                pboxJ2T4.Location = new Point(235, 354 - (28 * 6));
                                                pboxJ1T4.Visible = false;
                                                pboxJ2T4.Visible = false;
                                                pboxJ3T4.Visible = false;
                                                pboxJ4T4.Visible = false;
                                                C4.BackColor = Color.Blue;
                                                C42.BackColor = Color.Blue;
                                                C43.BackColor = Color.Blue;
                                                C44.BackColor = Color.Blue;
                                                C45.BackColor = Color.Blue;
                                                C46.BackColor = Color.Blue;
                                                C47.BackColor = Color.Blue;
                                                C4.Visible = true;
                                                C42.Visible = true;
                                                C43.Visible = true;
                                                C44.Visible = true;
                                                C45.Visible = true;
                                                C46.Visible = true;
                                                C47.Visible = true;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                pboxAJ2T5.Visible = false;
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
                                                
                                                pboxAJ2T5.Visible = false;
                                                pboxJ2T5.BackColor = Color.Blue;
                                                pboxJ2T5.Location = new Point(287, 381 - (28 * 8));
                                                pboxJ1T5.Visible = false;
                                                pboxJ2T5.Visible = false;
                                                pboxJ3T5.Visible = false;
                                                pboxJ4T5.Visible = false;
                                                C5.BackColor = Color.Blue;
                                                C52.BackColor = Color.Blue;
                                                C53.BackColor = Color.Blue;
                                                C54.BackColor = Color.Blue;
                                                C55.BackColor = Color.Blue;
                                                C56.BackColor = Color.Blue;
                                                C57.BackColor = Color.Blue;
                                                C58.BackColor = Color.Blue;
                                                C59.BackColor = Color.Blue;

                                                C5.Visible = true;
                                                C52.Visible = true;
                                                C53.Visible = true;
                                                C54.Visible = true;
                                                C55.Visible = true;
                                                C56.Visible = true;
                                                C57.Visible = true;
                                                C58.Visible = true;
                                                C59.Visible = true;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
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
                                                pboxAJ2T6.Visible = false;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 9));
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 9));
                                            }

                                            break;
                                        case 11:
                                            //CHECA CORRRRR
                                            if (Status.tipo == 'B')
                                            {
                                                pboxAJ2T6.Visible = false;
                                                pboxJ2T6.BackColor = Color.Blue;
                                                pboxJ2T6.Location = new Point(341, 410 - (28 * 10));
                                                pboxJ1T6.Visible = false;
                                                pboxJ2T6.Visible = false;
                                                pboxJ3T6.Visible = false;
                                                pboxJ4T6.Visible = false;
                                                C6.BackColor = Color.Blue;
                                                C62.BackColor = Color.Blue;
                                                C63.BackColor = Color.Blue;
                                                C64.BackColor = Color.Blue;
                                                C65.BackColor = Color.Blue;
                                                C66.BackColor = Color.Blue;
                                                C67.BackColor = Color.Blue;
                                                C68.BackColor = Color.Blue;
                                                C69.BackColor = Color.Blue;
                                                C610.BackColor = Color.Blue;
                                                C611.BackColor = Color.Blue;

                                                C6.Visible = true;
                                                C62.Visible = true;
                                                C63.Visible = true;
                                                C64.Visible = true;
                                                C65.Visible = true;
                                                C66.Visible = true;
                                                C67.Visible = true;
                                                C68.Visible = true;
                                                C69.Visible = true;
                                                C610.Visible = true;
                                                C611.Visible = true;
                                            }
                                            else
                                            {
                                                pboxAJ2T6.Visible = true;
                                                pboxAJ2T6.BackColor = Color.Black;
                                                pboxAJ2T6.Location = new Point(341, 410 - (28 * 10));
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                                pboxAJ2T7.Visible = false;
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
                                               
                                                pboxAJ2T7.Visible = false;
                                                pboxJ2T7.BackColor = Color.Blue;
                                                pboxJ2T7.Location = new Point(395, 438 - (28 * 12));
                                                pboxJ1T7.Visible = false;
                                                pboxJ2T7.Visible = false;
                                                pboxJ3T7.Visible = false;
                                                pboxJ4T7.Visible = false;
                                                C7.BackColor = Color.Blue;
                                                C72.BackColor = Color.Blue;
                                                C73.BackColor = Color.Blue;
                                                C74.BackColor = Color.Blue;
                                                C75.BackColor = Color.Blue;
                                                C76.BackColor = Color.Blue;
                                                C77.BackColor = Color.Blue;
                                                C78.BackColor = Color.Blue;
                                                C79.BackColor = Color.Blue;
                                                C710.BackColor = Color.Blue;
                                                C711.BackColor = Color.Blue;
                                                C712.BackColor = Color.Blue;
                                                C713.BackColor = Color.Blue;
                                                C7.Visible = true;
                                                C72.Visible = true;
                                                C73.Visible = true;
                                                C74.Visible = true;
                                                C75.Visible = true;
                                                C76.Visible = true;
                                                C77.Visible = true;
                                                C78.Visible = true;
                                                C79.Visible = true;
                                                C710.Visible = true;
                                                C711.Visible = true;
                                                C712.Visible = true;
                                                C713.Visible = true;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                pboxAJ2T8.Visible = false;
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
                                                
                                                pboxAJ2T8.Visible = false;
                                                pboxJ2T8.BackColor = Color.Blue;
                                                pboxJ2T8.Location = new Point(447, 410 - (28 * 8));
                                                pboxJ1T8.Visible = false;
                                                pboxJ2T8.Visible = false;
                                                pboxJ3T8.Visible = false;
                                                pboxJ4T8.Visible = false;
                                                C8.BackColor = Color.Blue;
                                                C82.BackColor = Color.Blue;
                                                C83.BackColor = Color.Blue;
                                                C84.BackColor = Color.Blue;
                                                C85.BackColor = Color.Blue;
                                                C86.BackColor = Color.Blue;
                                                C87.BackColor = Color.Blue;
                                                C88.BackColor = Color.Blue;
                                                C89.BackColor = Color.Blue;
                                                C810.BackColor = Color.Blue;
                                                C811.BackColor = Color.Blue;
                                                C8.Visible = true;
                                                C82.Visible = true;
                                                C83.Visible = true;
                                                C84.Visible = true;
                                                C85.Visible = true;
                                                C86.Visible = true;
                                                C87.Visible = true;
                                                C88.Visible = true;
                                                C89.Visible = true;
                                                C810.Visible = true;
                                                C811.Visible = true;
                                                
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                pboxAJ2T9.Visible = false;
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
                                                
                                                pboxAJ2T9.Visible = false;
                                                pboxJ2T9.BackColor = Color.Blue;
                                                pboxJ2T9.Location = new Point(500, 381 - (28 * 8));
                                                pboxJ1T9.Visible = false;
                                                pboxJ2T9.Visible = false;
                                                pboxJ3T9.Visible = false;
                                                pboxJ4T9.Visible = false;
                                                C9.BackColor = Color.Blue;
                                                C92.BackColor = Color.Blue;
                                                C93.BackColor = Color.Blue;
                                                C94.BackColor = Color.Blue;
                                                C95.BackColor = Color.Blue;
                                                C96.BackColor = Color.Blue;
                                                C97.BackColor = Color.Blue;
                                                C98.BackColor = Color.Blue;
                                                C99.BackColor = Color.Blue;
                                              
                                                C9.Visible = true;
                                                C92.Visible = true;
                                                C93.Visible = true;
                                                C94.Visible = true;
                                                C95.Visible = true;
                                                C96.Visible = true;
                                                C97.Visible = true;
                                                C98.Visible = true;
                                                C99.Visible = true;

                                            }
                                            else
                                            {
                                                pboxAJ2T9.Visible = true;
                                                pboxAJ2T9.BackColor = Color.Black;
                                                pboxAJ2T9.Location = new Point(500, 381 - (28 * 8));
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
                                                pboxAJ2T10.Visible = false;
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
                                                pboxAJ2T10.Visible = false;
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
                                                pboxAJ2T10.Visible = false;
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
                                                pboxAJ2T10.Visible = false;
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
                                                pboxAJ2T10.Visible = false;
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
                                                pboxAJ2T10.Visible = false;
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
                                                
                                                pboxAJ2T10.Visible = false;
                                                pboxJ2T10.BackColor = Color.Blue;
                                                pboxJ2T10.Location = new Point(553, 354 - (28 * 6));
                                                pboxJ1T10.Visible = false;
                                                pboxJ2T10.Visible = false;
                                                pboxJ3T10.Visible = false;
                                                pboxJ4T10.Visible = false;
                                                C10.BackColor = Color.Blue;
                                                C102.BackColor = Color.Blue;
                                                C103.BackColor = Color.Blue;
                                                C104.BackColor = Color.Blue;
                                                C105.BackColor = Color.Blue;
                                                C106.BackColor = Color.Blue;
                                                C107.BackColor = Color.Blue;
                                               
                                                C10.Visible = true;
                                                C102.Visible = true;
                                                C103.Visible = true;
                                                C104.Visible = true;
                                                C105.Visible = true;
                                                C106.Visible = true;
                                                C107.Visible = true;
                                                
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
                                                pboxAJ2T11.Visible = false;
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
                                                pboxAJ2T11.Visible = false;
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
                                                pboxAJ2T11.Visible = false;
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
                                                pboxAJ2T11.Visible = false;
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
                                               
                                                pboxAJ2T11.Visible = false;
                                                pboxJ2T11.BackColor = Color.Blue;
                                                pboxJ2T11.Location = new Point(607, 325 - (28 * 4));
                                                pboxJ1T11.Visible = false;
                                                pboxJ2T11.Visible = false;
                                                pboxJ3T11.Visible = false;
                                                pboxJ4T11.Visible = false;
                                                C11.BackColor = Color.Blue;
                                                C112.BackColor = Color.Blue;
                                                C113.BackColor = Color.Blue;
                                                C114.BackColor = Color.Blue;
                                                C115.BackColor = Color.Blue;
                                                
                                                C11.Visible = true;
                                                C112.Visible = true;
                                                C113.Visible = true;
                                                C114.Visible = true;
                                                C115.Visible = true;
                                                
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
                                                pboxAJ2T12.Visible = false;
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
                                                pboxAJ2T12.Visible = false;
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
                                                pboxAJ2T12.Visible = false;
                                                pboxJ2T12.BackColor = Color.Blue;
                                                pboxJ2T12.Location = new Point(660, (296 - 28) - 28);
                                                pboxJ1T12.Visible = false;
                                                pboxJ2T12.Visible = false;
                                                pboxJ3T12.Visible = false;
                                                pboxJ4T12.Visible = false;
                                                C12.BackColor = Color.Blue;
                                                C122.BackColor = Color.Blue;
                                                C123.BackColor = Color.Blue;
                                                C12.Visible = true;
                                                C122.Visible = true;
                                                C123.Visible = true;  
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
                                                pboxAJ3T2.Visible = false;
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
                                                pboxAJ3T2.Visible = false;
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
                                               
                                                pboxAJ3T2.Visible = false;
                                                pboxJ3T2.BackColor = Color.Green;
                                                pboxJ3T2.Location = new Point(112, (306 - 28) - 28);
                                                pboxJ1T2.Visible = false;
                                                pboxJ2T2.Visible = false;
                                                pboxJ3T2.Visible = false;
                                                pboxJ4T2.Visible = false;
                                                C2.BackColor = Color.Green;
                                                C22.BackColor = Color.Green;
                                                C23.BackColor = Color.Green;
                                                C2.Visible = true;
                                                C22.Visible = true;
                                                C23.Visible = true;
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
                                                pboxAJ3T3.Visible = false;
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
                                                pboxAJ3T3.Visible = false;
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
                                                pboxAJ3T3.Visible = false;
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
                                                pboxAJ3T3.Visible = false;
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
                                                
                                                pboxAJ3T3.Visible = false;
                                                pboxJ3T3.BackColor = Color.Green;
                                                pboxJ3T3.Location = new Point(163, 334 - (28 * 4));
                                                pboxJ1T3.Visible = false;
                                                pboxJ2T3.Visible = false;
                                                pboxJ3T3.Visible = false;
                                                pboxJ4T3.Visible = false;
                                                C3.BackColor = Color.Green;
                                                C32.BackColor = Color.Green;
                                                C33.BackColor = Color.Green;
                                                C34.BackColor = Color.Green;
                                                C35.BackColor = Color.Green;
                                                C3.Visible = true;
                                                C32.Visible = true;
                                                C33.Visible = true;
                                                C34.Visible = true;
                                                C35.Visible = true;
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
                                                pboxAJ3T4.Visible = false;
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
                                                pboxAJ3T4.Visible = false;
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
                                                pboxAJ3T4.Visible = false;
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
                                                pboxAJ3T4.Visible = false;
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
                                                pboxAJ3T4.Visible = false;
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
                                                pboxAJ3T4.Visible = false;
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
                                                pboxAJ3T4.Visible = false;
                                                pboxJ3T4.BackColor = Color.Green;
                                                pboxJ3T4.Location = new Point(217, 363 - (28 * 6));
                                                pboxJ1T4.Visible = false;
                                                pboxJ2T4.Visible = false;
                                                pboxJ3T4.Visible = false;
                                                pboxJ4T4.Visible = false;
                                                C4.BackColor = Color.Green;
                                                C42.BackColor = Color.Green;
                                                C43.BackColor = Color.Green;
                                                C44.BackColor = Color.Green;
                                                C45.BackColor = Color.Green;
                                                C46.BackColor = Color.Green;
                                                C47.BackColor = Color.Green;
                                                C4.Visible = true;
                                                C42.Visible = true;
                                                C43.Visible = true;
                                                C44.Visible = true;
                                                C45.Visible = true;
                                                C46.Visible = true;
                                                C47.Visible = true;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
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
                                                pboxAJ3T5.Visible = false;
                                                pboxJ3T5.BackColor = Color.Green;
                                                pboxJ3T5.Location = new Point(270, 391 - (28 * 8));
                                                pboxJ1T5.Visible = false;
                                                pboxJ2T5.Visible = false;
                                                pboxJ3T5.Visible = false;
                                                pboxJ4T5.Visible = false;
                                                C5.BackColor = Color.Green;
                                                C52.BackColor = Color.Green;
                                                C53.BackColor = Color.Green;
                                                C54.BackColor = Color.Green;
                                                C55.BackColor = Color.Green;
                                                C56.BackColor = Color.Green;
                                                C57.BackColor = Color.Green;
                                                C58.BackColor = Color.Green;
                                                C59.BackColor = Color.Green;
                                                C5.Visible = true;
                                                C52.Visible = true;
                                                C53.Visible = true;
                                                C54.Visible = true;
                                                C55.Visible = true;
                                                C56.Visible = true;
                                                C57.Visible = true;
                                                C58.Visible = true;
                                                C59.Visible = true;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
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
                                                pboxAJ3T6.Visible = false;
                                                pboxJ3T6.BackColor = Color.Green;
                                                pboxJ3T6.Location = new Point(323, 420 - (28 * 10));
                                                pboxJ1T6.Visible = false;
                                                pboxJ2T6.Visible = false;
                                                pboxJ3T6.Visible = false;
                                                pboxJ4T6.Visible = false;
                                                C6.BackColor = Color.Green;
                                                C62.BackColor = Color.Green;
                                                C63.BackColor = Color.Green;
                                                C64.BackColor = Color.Green;
                                                C65.BackColor = Color.Green;
                                                C66.BackColor = Color.Green;
                                                C67.BackColor = Color.Green;
                                                C68.BackColor = Color.Green;
                                                C69.BackColor = Color.Green;
                                                C610.BackColor = Color.Green;
                                                C611.BackColor = Color.Green;
                                                C6.Visible = true;
                                                C62.Visible = true;
                                                C63.Visible = true;
                                                C64.Visible = true;
                                                C65.Visible = true;
                                                C66.Visible = true;
                                                C67.Visible = true;
                                                C68.Visible = true;
                                                C69.Visible = true;
                                                C610.Visible = true;
                                                C611.Visible = true;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
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
                                                pboxAJ3T7.Visible = false;
                                                pboxJ3T7.BackColor = Color.Green;
                                                pboxJ3T7.Location = new Point(376, 447 - (28 * 12));
                                                pboxJ1T7.Visible = false;
                                                pboxJ2T7.Visible = false;
                                                pboxJ3T7.Visible = false;
                                                pboxJ4T7.Visible = false;
                                                C7.BackColor = Color.Green;
                                                C72.BackColor = Color.Green;
                                                C73.BackColor = Color.Green;
                                                C74.BackColor = Color.Green;
                                                C75.BackColor = Color.Green;
                                                C76.BackColor = Color.Green;
                                                C77.BackColor = Color.Green;
                                                C78.BackColor = Color.Green;
                                                C79.BackColor = Color.Green;
                                                C710.BackColor = Color.Green;
                                                C711.BackColor = Color.Green;
                                                C712.BackColor = Color.Green;
                                                C713.BackColor = Color.Green;
                                                C7.Visible = true;
                                                C72.Visible = true;
                                                C73.Visible = true;
                                                C74.Visible = true;
                                                C75.Visible = true;
                                                C76.Visible = true;
                                                C77.Visible = true;
                                                C78.Visible = true;
                                                C79.Visible = true;
                                                C710.Visible = true;
                                                C711.Visible = true;
                                                C712.Visible = true;
                                                C713.Visible = true;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
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
                                                pboxAJ3T8.Visible = false;
                                                pboxJ3T8.BackColor = Color.Green;
                                                pboxJ3T8.Location = new Point(429, 420 - (28 * 8));
                                                pboxJ1T8.Visible = false;
                                                pboxJ2T8.Visible = false;
                                                pboxJ3T8.Visible = false;
                                                pboxJ4T8.Visible = false;
                                                C8.BackColor = Color.Green;
                                                C82.BackColor = Color.Green;
                                                C83.BackColor = Color.Green;
                                                C84.BackColor = Color.Green;
                                                C85.BackColor = Color.Green;
                                                C86.BackColor = Color.Green;
                                                C87.BackColor = Color.Green;
                                                C88.BackColor = Color.Green;
                                                C89.BackColor = Color.Green;
                                                C810.BackColor = Color.Green;
                                                C811.BackColor = Color.Green;
                                                C8.Visible = true;
                                                C82.Visible = true;
                                                C83.Visible = true;
                                                C84.Visible = true;
                                                C85.Visible = true;
                                                C86.Visible = true;
                                                C87.Visible = true;
                                                C88.Visible = true;
                                                C89.Visible = true;
                                                C810.Visible = true;
                                                C811.Visible = true;
                                               
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                pboxAJ3T9.Visible = false;
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
                                                
                                                pboxAJ3T9.Visible = false;
                                                pboxJ3T9.BackColor = Color.Green;
                                                pboxJ3T9.Location = new Point(482, 391 - (28 * 8));
                                                pboxJ1T9.Visible = false;
                                                pboxJ2T9.Visible = false;
                                                pboxJ3T9.Visible = false;
                                                pboxJ4T9.Visible = false;
                                                C9.BackColor = Color.Green;
                                                C92.BackColor = Color.Green;
                                                C93.BackColor = Color.Green;
                                                C94.BackColor = Color.Green;
                                                C95.BackColor = Color.Green;
                                                C96.BackColor = Color.Green;
                                                C97.BackColor = Color.Green;
                                                C98.BackColor = Color.Green;
                                                C99.BackColor = Color.Green;
                                                
                                                C9.Visible = true;
                                                C92.Visible = true;
                                                C93.Visible = true;
                                                C94.Visible = true;
                                                C95.Visible = true;
                                                C96.Visible = true;
                                                C97.Visible = true;
                                                C98.Visible = true;
                                                C99.Visible = true;
                                                
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
                                                pboxAJ3T10.Visible = false;
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
                                                pboxAJ3T10.Visible = false;
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
                                                pboxAJ3T10.Visible = false;
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
                                                pboxAJ3T10.Visible = false;
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
                                                pboxAJ3T10.Visible = false;
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
                                                pboxAJ3T10.Visible = false;
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
                                                pboxAJ3T10.Visible = false;
                                                pboxJ3T10.BackColor = Color.Green;
                                                pboxJ3T10.Location = new Point(536, 363 - (28 * 6));
                                                pboxJ1T10.Visible = false;
                                                pboxJ2T10.Visible = false;
                                                pboxJ3T10.Visible = false;
                                                pboxJ4T10.Visible = false;
                                                C10.BackColor = Color.Green;
                                                C102.BackColor = Color.Green;
                                                C103.BackColor = Color.Green;
                                                C104.BackColor = Color.Green;
                                                C105.BackColor = Color.Green;
                                                C106.BackColor = Color.Green;
                                                C107.BackColor = Color.Green;
                                                C10.Visible = true;
                                                C102.Visible = true;
                                                C103.Visible = true;
                                                C104.Visible = true;
                                                C105.Visible = true;
                                                C106.Visible = true;
                                                C107.Visible = true;
                                               
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
                                                pboxAJ3T11.Visible = false;
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
                                                pboxAJ3T11.Visible = false;
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
                                                pboxAJ3T11.Visible = false;
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
                                                pboxAJ3T11.Visible = false;
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
                                                
                                                pboxAJ3T11.Visible = false;
                                                pboxJ3T11.BackColor = Color.Green;
                                                pboxJ3T11.Location = new Point(589, 334 - (28 * 4));
                                                pboxJ1T11.Visible = false;
                                                pboxJ2T11.Visible = false;
                                                pboxJ3T11.Visible = false;
                                                pboxJ4T11.Visible = false;
                                                C11.BackColor = Color.Green;
                                                C112.BackColor = Color.Green;
                                                C113.BackColor = Color.Green;
                                                C114.BackColor = Color.Green;
                                                C115.BackColor = Color.Green;
                                                C11.Visible = true;
                                                C112.Visible = true;
                                                C113.Visible = true;
                                                C114.Visible = true;
                                                C115.Visible = true;
                                           
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
                                                pboxAJ3T12.Visible = false;
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
                                                pboxAJ3T12.Visible = false;
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
                                              
                                                pboxAJ3T12.Visible = false;
                                                pboxJ3T12.BackColor = Color.Green;
                                                pboxJ3T12.Location = new Point(642, (306 - 28) - 28);
                                                pboxJ1T12.Visible = false;
                                                pboxJ2T12.Visible = false;
                                                pboxJ3T12.Visible = false;
                                                pboxJ4T12.Visible = false;
                                                C12.BackColor = Color.Green;
                                                C122.BackColor = Color.Green;
                                                C123.BackColor = Color.Green;
                                                C12.Visible = true;
                                                C122.Visible = true;
                                                C123.Visible = true;
                                               
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
                                                pboxAJ4T2.Visible = false;
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
                                                pboxAJ4T2.Visible = false;
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
                                                pboxAJ4T2.Visible = false;
                                                pboxJ4T2.BackColor = Color.Yellow;
                                                pboxJ4T2.Location = new Point(129, (306 - 28) - 28);
                                                pboxJ1T2.Visible = false;
                                                pboxJ2T2.Visible = false;
                                                pboxJ3T2.Visible = false;
                                                pboxJ4T2.Visible = false;
                                                C2.BackColor = Color.Yellow;
                                                C22.BackColor = Color.Yellow;
                                                C23.BackColor = Color.Yellow;
                                                C2.Visible = true;
                                                C22.Visible = true;
                                                C23.Visible = true;
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
                                                pboxAJ4T3.Visible = false;
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
                                                pboxAJ4T3.Visible = false;
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
                                                pboxAJ4T3.Visible = false;
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
                                                pboxAJ4T3.Visible = false;
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
                                                pboxAJ4T3.Visible = false;
                                                pboxJ4T3.BackColor = Color.Yellow;
                                                pboxJ4T3.Location = new Point(181, 334 - (28 * 4));
                                                pboxJ1T3.Visible = false;
                                                pboxJ2T3.Visible = false;
                                                pboxJ3T3.Visible = false;
                                                pboxJ4T3.Visible = false;
                                                C3.BackColor = Color.Yellow;
                                                C32.BackColor = Color.Yellow;
                                                C33.BackColor = Color.Yellow;
                                                C34.BackColor = Color.Yellow;
                                                C35.BackColor = Color.Yellow;
                                                C3.Visible = true;
                                                C32.Visible = true;
                                                C33.Visible = true;
                                                C34.Visible = true;
                                                C35.Visible = true;
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
                                                pboxAJ4T4.Visible = false;
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
                                                pboxAJ4T4.Visible = false;
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
                                                pboxAJ4T4.Visible = false;
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
                                                pboxAJ4T4.Visible = false;
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
                                                pboxAJ4T4.Visible = false;
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
                                                pboxAJ4T4.Visible = false;
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
                                                
                                                pboxAJ4T4.Visible = false;
                                                pboxJ4T4.BackColor = Color.Yellow;
                                                pboxJ4T4.Location = new Point(235, 363 - (28 * 6));
                                                pboxJ1T4.Visible = false;
                                                pboxJ2T4.Visible = false;
                                                pboxJ3T4.Visible = false;
                                                pboxJ4T4.Visible = false;
                                                C4.BackColor = Color.Yellow;
                                                C42.BackColor = Color.Yellow;
                                                C43.BackColor = Color.Yellow;
                                                C44.BackColor = Color.Yellow;
                                                C45.BackColor = Color.Yellow;
                                                C46.BackColor = Color.Yellow;
                                                C47.BackColor = Color.Yellow;
                                                C4.Visible = true;
                                                C42.Visible = true;
                                                C43.Visible = true;
                                                C44.Visible = true;
                                                C45.Visible = true;
                                                C46.Visible = true;
                                                C47.Visible = true;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
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
                                                pboxAJ4T5.Visible = false;
                                                pboxJ4T5.BackColor = Color.Yellow;
                                                pboxJ4T5.Location = new Point(287, 391 - (28 * 8));
                                                pboxJ1T5.Visible = false;
                                                pboxJ2T5.Visible = false;
                                                pboxJ3T5.Visible = false;
                                                pboxJ4T5.Visible = false;
                                                C5.BackColor = Color.Yellow;
                                                C52.BackColor = Color.Yellow;
                                                C53.BackColor = Color.Yellow;
                                                C54.BackColor = Color.Yellow;
                                                C55.BackColor = Color.Yellow;
                                                C56.BackColor = Color.Yellow;
                                                C57.BackColor = Color.Yellow;
                                                C58.BackColor = Color.Yellow;
                                                C59.BackColor = Color.Yellow;
                                                C5.Visible = true;
                                                C52.Visible = true;
                                                C53.Visible = true;
                                                C54.Visible = true;
                                                C55.Visible = true;
                                                C56.Visible = true;
                                                C57.Visible = true;
                                                C58.Visible = true;
                                                C59.Visible = true;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                pboxAJ4T6.Visible = false;
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
                                                
                                                pboxAJ4T6.Visible = false;
                                                pboxJ4T6.BackColor = Color.Yellow;
                                                pboxJ4T6.Location = new Point(341, 420 - (28 * 10));
                                                pboxJ1T6.Visible = false;
                                                pboxJ2T6.Visible = false;
                                                pboxJ3T6.Visible = false;
                                                pboxJ4T6.Visible = false;
                                                C6.BackColor = Color.Yellow;
                                                C62.BackColor = Color.Yellow;
                                                C63.BackColor = Color.Yellow;
                                                C64.BackColor = Color.Yellow;
                                                C65.BackColor = Color.Yellow;
                                                C66.BackColor = Color.Yellow;
                                                C67.BackColor = Color.Yellow;
                                                C68.BackColor = Color.Yellow;
                                                C69.BackColor = Color.Yellow;
                                                C610.BackColor = Color.Yellow;
                                                C611.BackColor = Color.Yellow;
                                                C6.Visible = true;
                                                C62.Visible = true;
                                                C63.Visible = true;
                                                C64.Visible = true;
                                                C65.Visible = true;
                                                C66.Visible = true;
                                                C67.Visible = true;
                                                C68.Visible = true;
                                                C69.Visible = true;
                                                C610.Visible = true;
                                                C611.Visible = true;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
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
                                                pboxAJ4T7.Visible = false;
                                                pboxJ4T7.BackColor = Color.Yellow;
                                                pboxJ4T7.Location = new Point(395, 447 - (28 * 12));
                                                pboxJ1T7.Visible = false;
                                                pboxJ2T7.Visible = false;
                                                pboxJ3T7.Visible = false;
                                                pboxJ4T7.Visible = false;
                                                C7.BackColor = Color.Yellow;
                                                C72.BackColor = Color.Yellow;
                                                C73.BackColor = Color.Yellow;
                                                C74.BackColor = Color.Yellow;
                                                C75.BackColor = Color.Yellow;
                                                C76.BackColor = Color.Yellow;
                                                C77.BackColor = Color.Yellow;
                                                C78.BackColor = Color.Yellow;
                                                C79.BackColor = Color.Yellow;
                                                C710.BackColor = Color.Yellow;
                                                C711.BackColor = Color.Yellow;
                                                C712.BackColor = Color.Yellow;
                                                C713.BackColor = Color.Yellow;
                                                C7.Visible = true;
                                                C72.Visible = true;
                                                C73.Visible = true;
                                                C74.Visible = true;
                                                C75.Visible = true;
                                                C76.Visible = true;
                                                C77.Visible = true;
                                                C78.Visible = true;
                                                C79.Visible = true;
                                                C710.Visible = true;
                                                C711.Visible = true;
                                                C712.Visible = true;
                                                C713.Visible = true;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                pboxAJ4T8.Visible = false;
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
                                                
                                                pboxAJ4T8.Visible = false;
                                                pboxJ4T8.BackColor = Color.Yellow;
                                                pboxJ4T8.Location = new Point(447, 420 - (28 * 8));
                                                pboxJ1T8.Visible = false;
                                                pboxJ2T8.Visible = false;
                                                pboxJ3T8.Visible = false;
                                                pboxJ4T8.Visible = false;
                                                C8.BackColor = Color.Yellow;
                                                C82.BackColor = Color.Yellow;
                                                C83.BackColor = Color.Yellow;
                                                C84.BackColor = Color.Yellow;
                                                C85.BackColor = Color.Yellow;
                                                C86.BackColor = Color.Yellow;
                                                C87.BackColor = Color.Yellow;
                                                C88.BackColor = Color.Yellow;
                                                C89.BackColor = Color.Yellow;
                                                C810.BackColor = Color.Yellow;
                                                C811.BackColor = Color.Yellow;
                                                C8.Visible = true;
                                                C82.Visible = true;
                                                C83.Visible = true;
                                                C84.Visible = true;
                                                C85.Visible = true;
                                                C86.Visible = true;
                                                C87.Visible = true;
                                                C88.Visible = true;
                                                C89.Visible = true;
                                                C810.Visible = true;
                                                C811.Visible = true;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                pboxAJ4T9.Visible = false;
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
                                                
                                                pboxAJ4T9.Visible = false;
                                                pboxJ4T9.BackColor = Color.Yellow;
                                                pboxJ4T9.Location = new Point(500, 391 - (28 * 8));
                                                pboxJ1T9.Visible = false;
                                                pboxJ2T9.Visible = false;
                                                pboxJ3T9.Visible = false;
                                                pboxJ4T9.Visible = false;
                                                C9.BackColor = Color.Yellow;
                                                C92.BackColor = Color.Yellow;
                                                C93.BackColor = Color.Yellow;
                                                C94.BackColor = Color.Yellow;
                                                C95.BackColor = Color.Yellow;
                                                C96.BackColor = Color.Yellow;
                                                C97.BackColor = Color.Yellow;
                                                C98.BackColor = Color.Yellow;
                                                C99.BackColor = Color.Yellow;
                                                C9.Visible = true;
                                                C92.Visible = true;
                                                C93.Visible = true;
                                                C94.Visible = true;
                                                C95.Visible = true;
                                                C96.Visible = true;
                                                C97.Visible = true;
                                                C98.Visible = true;
                                                C99.Visible = true;
                                                
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
                                                pboxAJ4T10.Visible = false;
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
                                                pboxAJ4T10.Visible = false;
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
                                                pboxAJ4T10.Visible = false;
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
                                                pboxAJ4T10.Visible = false;
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
                                                pboxAJ4T10.Visible = false;
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
                                                pboxAJ4T10.Visible = false;
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
                                                
                                                pboxAJ4T10.Visible = false;
                                                pboxJ4T10.BackColor = Color.Yellow;
                                                pboxJ4T10.Location = new Point(553, 363 - (28 * 6));
                                                pboxJ1T10.Visible = false;
                                                pboxJ2T10.Visible = false;
                                                pboxJ3T10.Visible = false;
                                                pboxJ4T10.Visible = false;
                                                C10.BackColor = Color.Yellow;
                                                C102.BackColor = Color.Yellow;
                                                C103.BackColor = Color.Yellow;
                                                C104.BackColor = Color.Yellow;
                                                C105.BackColor = Color.Yellow;
                                                C106.BackColor = Color.Yellow;
                                                C107.BackColor = Color.Yellow;
                                               
                                                C10.Visible = true;
                                                C102.Visible = true;
                                                C103.Visible = true;
                                                C104.Visible = true;
                                                C105.Visible = true;
                                                C106.Visible = true;
                                                C107.Visible = true;
                                                
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
                                                pboxAJ4T11.Visible = false;
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
                                                pboxAJ4T11.Visible = false;
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
                                                pboxAJ4T11.Visible = false;
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
                                                pboxAJ4T11.Visible = false;
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
                                             
                                                pboxAJ4T11.Visible = false;
                                                pboxJ4T11.BackColor = Color.Yellow;
                                                pboxJ4T11.Location = new Point(607, 334 - (28 * 4));
                                                pboxJ1T11.Visible = false;
                                                pboxJ2T11.Visible = false;
                                                pboxJ3T11.Visible = false;
                                                pboxJ4T11.Visible = false;
                                                C11.BackColor = Color.Yellow;
                                                C112.BackColor = Color.Yellow;
                                                C113.BackColor = Color.Yellow;
                                                C114.BackColor = Color.Yellow;
                                                C115.BackColor = Color.Yellow;                                             
                                                C11.Visible = true;
                                                C112.Visible = true;
                                                C113.Visible = true;
                                                C114.Visible = true;
                                                C115.Visible = true;
                                                
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
                                                pboxAJ4T12.Visible = false;
                                                pboxJ4T12.BackColor = Color.Yellow;
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
                                                pboxAJ4T12.Visible = false;
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
                                                pboxAJ4T12.Visible = false;
                                                pboxJ4T12.BackColor = Color.Yellow;
                                                pboxJ4T12.Location = new Point(660, (306 - 28) - 28);
                                                pboxJ1T12.Visible = false;
                                                pboxJ2T12.Visible = false;
                                                pboxJ3T12.Visible = false;
                                                pboxJ4T12.Visible = false;
                                                C12.BackColor = Color.Yellow;
                                                C122.BackColor = Color.Yellow;
                                                C123.BackColor = Color.Yellow;
                                                C12.Visible = true;
                                                C122.Visible = true;
                                                C123.Visible = true;
                                                
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

               
            }
        }

       

      
    }
}