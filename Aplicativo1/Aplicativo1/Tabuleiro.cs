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
        public Tabuleiro()
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();

            InitializeComponent();

            txtJogadores.Text = Jogo.ListarJogadores(form1.idPartida);

            

        }
    }
}
