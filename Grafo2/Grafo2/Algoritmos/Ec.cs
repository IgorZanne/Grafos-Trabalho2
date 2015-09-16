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
            var pilha = new Stack<Vertice>();
            var retorno = new List<Vertice>();
            var inicial = grafo.Vertices.First().Value;
            pilha.Push(inicial);

            while (pilha.Any())
            {
                var u = pilha.Pop();
                retorno.Insert(0, u);
                while (grafo.GetAdj(u.Id).Any())
                {
                    pilha.Push(u);
                    var v = grafo.GetAdj(u.Id).First();

                    var tupla = new Tuple<Vertice, Vertice>(u, v);
                    var arestas = grafo.ArestasDoVertice[tupla];
                    grafo.RemoveAresta(arestas);

                    u = v;
                }
            }

            return retorno;
        }
    }
}
