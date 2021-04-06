using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo1
{
    class StatusTabu
    {

        public char tipo;

        public int jogador;

        public int trilha;

        public int position;


        public StatusTabu(int trilha, int posicao, int jogador, char tipo)
        {
            this.trilha = trilha;
            this.position = posicao;
            this.jogador = jogador;
            this.tipo = tipo;

        }






    }
}
