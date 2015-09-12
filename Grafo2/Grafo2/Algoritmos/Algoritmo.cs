using Grafo2.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Algoritmos
{
    public abstract class Algoritmo
    {
        public abstract IEnumerable<string> Executar(string arquivo);
    }
}
