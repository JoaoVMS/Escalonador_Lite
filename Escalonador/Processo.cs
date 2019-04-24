using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador
{
    class Processo : IDado
    {
        public int PID { get; private set; }
        public string Nome { get; private set; }
        public int Prioridade { get; private set; }
        public int QtdeCiclos { get; set; }

        public Processo(int PID, string Nome, int Prioridade, int QtdeCiclos)
        {
            this.PID = PID;
            this.Nome = Nome;
            this.Prioridade = Prioridade;
            this.QtdeCiclos = QtdeCiclos;
        }

        public void DiminuirQtdeCiclos()
        {
            if (QtdeCiclos > 0)
            QtdeCiclos--;
        }
        public void DiminuirPrioridade()
        {
            if (Prioridade < 10)
                Prioridade++;
        }
        public void AumentarPrioridade()
        {
            if (Prioridade > 1)
                Prioridade--;
        }
        public override string ToString()
        {
            return string.Format(" PID: {0} Nome: {1} Prioridade: {2} Quantidade de Ciclos: {3}.", PID, Nome, Prioridade, QtdeCiclos);
        }
    }
}
