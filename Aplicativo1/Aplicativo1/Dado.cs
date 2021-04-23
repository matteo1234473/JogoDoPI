using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicativo1
{
    class Dado
    {
        public int Numero { get; set; }
        public int Id { get; set; }

        public Dado(int numero, int id)
        {
            this.Numero = numero;
            this.Id = id;
        }  
    }
}
