using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador
{
    class Program
    {
        static void Main(string[] args)
        {
            int q, tC, slp; // Quantum, Troca de Contexto, Thread.Sleep;
            string nomeArquivo = "teste.txt";

            Console.Write("Valor do Quantum: ");
            q = Convert.ToInt32(Console.ReadLine());
            Console.Write("Valor da troca de contexto em ms: ");
            tC = Convert.ToInt32(Console.ReadLine());
            Console.Write("Valor do Thread.Sleep() em ms: ");
            slp = Convert.ToInt32(Console.ReadLine());

            Escalonador escalonador = Arquivo.LeituraArquivo(nomeArquivo, q, tC, slp);

            if (escalonador == null)
                Console.WriteLine("O arquivo {0} não existe.", nomeArquivo);
            else
            {
                Console.WriteLine(escalonador.ToString());
                escalonador.Run();
            }

            Console.WriteLine(escalonador.ToString());

            Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
