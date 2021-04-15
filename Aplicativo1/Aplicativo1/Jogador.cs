using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo1
{
    class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }

        static int qtdJogadores = 0;
        public int Posicao { get; set; }

        public Jogador(int id, string nome, string cor)
        {
            this.Id = id;
            this.Cor = cor;
            this.Nome = nome;
            Jogador.qtdJogadores++;
            this.Posicao = Jogador.qtdJogadores;
        }
    }
}
