using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador
{
    class Elemento
    {
        public IDado meuDado { get; set; }
        public Elemento prox { get; set; }
        public Elemento(IDado d)
        {
            meuDado = d;
            prox = null;
        }
    }
}
