using Grafo2.Algoritmos;
using Grafo2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2
{
    public class Factory
    {
        private readonly Algoritmo algoritmo;

        public Factory(string nome)
        {
            switch (nome.ToUpper())
            {
                case "EC":    algoritmo = new Ec();    break;
                case "TSP-NN": algoritmo = new TspNn(); break;
                case "TSP-MST":   algoritmo = new TspMst();   break;
                case "TSP-NN-2OPT":    algoritmo = new TspNn2Opt();    break;
                case "TSP-MST-2OPT": algoritmo = new TspMst2Opt(); break;
                default:
                    throw new Exception(String.Format("Algoritmo '{0}' não identificado", nome.ToUpper()));
            }
        }

        public IEnumerable<string> Executar(string arquivo)
        {
            var result = algoritmo.Executar(arquivo);
            return result;
        }
    }
}
