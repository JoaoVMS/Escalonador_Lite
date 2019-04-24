using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Escalonador
{
    class Arquivo
    {
        public static Escalonador LeituraArquivo(string nomeArquivo, int q, int tC, int sleep)
        {
            // Formatação do arquivo
            // id;nome;prioridade;quantidade_ciclos 

            if (!File.Exists(nomeArquivo)) return null;

            string[] info;
            Escalonador auxiliar = new Escalonador(q, tC, sleep);

            //Fazer a leitura do arquivo e organizar entre as 10 listas Circulares
            using (StreamReader entrada = new StreamReader(nomeArquivo))
            {
                while (!entrada.EndOfStream)
                {
                    info = entrada.ReadLine().Split(';');
                    auxiliar.AdicionarProcesso(new Processo(Convert.ToInt32(info[0]), info[1], Convert.ToInt32(info[2]), Convert.ToInt32(info[3])));
                }
            }                      

            return auxiliar;
        }
    }
}
