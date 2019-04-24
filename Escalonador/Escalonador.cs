using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Escalonador
{
    class Escalonador : IDado
    {
        public Fila[] Todos { get; set; }
        int Quantum, tContexto, sleep;

        public Escalonador(int Quantum, int tContexto, int sleep)
        {
            Todos = new Fila[10];

            for (int i = 0; i < Todos.Length; i++)
                Todos[i] = new Fila();

            this.Quantum = Quantum;
            this.tContexto = tContexto;
            this.sleep = sleep;
        }

        public void Run()
        {
            ;
            int pos = 0;
            while (!Vazia() && pos < Todos.Length)
            {
                Console.WriteLine("\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));

                while (!Todos[pos].Vazio())
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nTroca de contexto...");
                    Console.ForegroundColor = ConsoleColor.White;

                    Thread.Sleep(tContexto);

                    Processo processo = (Processo)(Todos[pos].Retirar());

                    Console.WriteLine("Processando: " + processo.ToString());

                    if (CPU(processo) > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Processo Finalizado");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        AdicionarProcesso(processo);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Processo REBAIXADO para prioridade {0}", processo.Prioridade);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("\n\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));
                    Console.WriteLine("\n" + Todos[pos].ToString());
                }
                pos++;
            }
        }
        private int CPU(Processo p)
        {
            int aux = 1;

            while (aux <= Quantum && p.QtdeCiclos > 0)
            {
                p.DiminuirQtdeCiclos();
                Thread.Sleep(sleep);
                aux++;
            }

            if (p.QtdeCiclos == 0)
                return 1;
            else
                p.DiminuirPrioridade();

            return -1;
        }
        public void AdicionarProcesso(Processo p)
        {
            switch (p.Prioridade)
            {
                case 1: Todos[0].Inserir(p); break;
                case 2: Todos[1].Inserir(p); break;
                case 3: Todos[2].Inserir(p); break;
                case 4: Todos[3].Inserir(p); break;
                case 5: Todos[4].Inserir(p); break;
                case 6: Todos[5].Inserir(p); break;
                case 7: Todos[6].Inserir(p); break;
                case 8: Todos[7].Inserir(p); break;
                case 9: Todos[8].Inserir(p); break;
                case 10: Todos[9].Inserir(p); break;
                default: break;
            }
        }
        public bool Vazia()
        {
            return Todos[0].Vazio() && Todos[1].Vazio() && Todos[2].Vazio() && Todos[3].Vazio() && Todos[4].Vazio() && Todos[5].Vazio() && Todos[6].Vazio() && Todos[7].Vazio() && Todos[8].Vazio() && Todos[9].Vazio();
        }
        public override string ToString()
        {
            StringBuilder auxImpressao = new StringBuilder();

            for (int pos = 0; pos < Todos.Length; pos++)
            {
                auxImpressao.AppendLine("\tPrioridade " + (pos + 1));
                auxImpressao.AppendLine(Todos[pos].ToString());
            }

            return auxImpressao.ToString();
        }
    }
}
