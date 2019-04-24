using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador
{
    class Fila : IDado
    {
        public Elemento prim { get; set; }
        public Elemento ult { get; set; }

        public Fila()
        {
            prim = ult = new Elemento(null);
        }

        public bool Vazio()
        {
            return prim == ult;
        }
        public void Inserir(IDado d)
        {
            ult = ult.prox = new Elemento(d);
        }
        public IDado Retirar()
        {
            if (Vazio())
                return null;

            Elemento aux = prim.prox;
            prim.prox = aux.prox;

            if (aux.prox != null)
                aux.prox = null;
            else
                ult = prim;

            return aux.meuDado;
        }
        public override string ToString()
        {
            Elemento aux = prim;
            StringBuilder auxImpre = new StringBuilder();
            
            while(aux.prox != null)
            {
                auxImpre.AppendLine(aux.prox.meuDado.ToString());
                aux = aux.prox;
            }

            return auxImpre.ToString();
        }
    }
}
