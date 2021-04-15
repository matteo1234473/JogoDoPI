using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo1
{
    class StatusTabu
    {

        public char tipo { get; set; }

        public Jogador Jogador { get; set; }

        public int trilha { get; set; }

        public int position { get; set; }



        public StatusTabu(int trilha, int posicao, int j_id, char tipo, List<Jogador> listaDeJogadores)
        {
            this.trilha = trilha;
            this.position = posicao;
            this.tipo = tipo;
            foreach(Jogador jogador in listaDeJogadores)
            {
                if (jogador.Id == j_id)
                {
                    this.Jogador = jogador;
                    break;
                }
                
            }
        }






    }
}
