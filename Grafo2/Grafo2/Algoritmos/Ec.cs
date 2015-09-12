using Grafo2.Estruturas;
using Grafo2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Algoritmos
{
    public class Ec : Algoritmo
    {
        public override IEnumerable<string> Executar(string arquivo)
        {
            var grafo = GrafoHelper.Ler(arquivo);
            var ciclo = ExecutarEc(grafo);

            return MontaRetorno.GerarRetornoHierholzer(ciclo);
        }

        private List<Vertice> ExecutarEc(Grafo grafo)
        {
            //var v = grafo.Vertices.First();
            //var s = new Stack<Vertice>();
            //s.Push(v.Value);
            //var C = new List<Vertice>();
            //while (s.Any())
            //{
            //    var u = s.Pop();
            //    C.Insert(0, u);
            //    //
            //    while (u.Adjacentes.Any())
            //    {
            //        s.Push(u);
            //        u.Adjacentes
            //    }
            //}

            throw new NotImplementedException();
        }
    }
}
