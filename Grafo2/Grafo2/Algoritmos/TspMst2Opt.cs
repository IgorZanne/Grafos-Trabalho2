using Grafo2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Algoritmos
{
    public class TspMst2Opt : Algoritmo
    {
        public override IEnumerable<string> Executar(string arquivo)
        {
            var grafo = GrafoHelper.LerTsp(arquivo);
            throw new NotImplementedException();
        }
    }
}
