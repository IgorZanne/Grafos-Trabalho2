using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Estruturas
{
    public class Grafo
    {
        public bool Direcionado { get; set; }
        public List<Aresta> Arestas { get; set; }

        public Dictionary<string, Vertice> Vertices { get; set; }
        public Dictionary<string, List<Vertice>> Adjacentes { set; get; }
        public Dictionary<Tuple<Vertice, Vertice>, Aresta> ArestasDoVertice { get; set; }

        public List<Vertice> GetAdj(string vertice)
        {
            return this.Adjacentes[vertice];
        }

        public Grafo()
        {
            this.Direcionado = true;
            this.Vertices = new Dictionary<string, Vertice>();
            this.Arestas = new List<Aresta>();
            this.Adjacentes = new Dictionary<string, List<Vertice>>();
            this.ArestasDoVertice = new Dictionary<Tuple<Vertice, Vertice>, Aresta>();
        }

        public void AdicionaVertice(Vertice vertice)
        {
            this.Vertices.Add(vertice.Id, vertice);
            this.Adjacentes.Add(vertice.Id, new List<Vertice>());
        }

        public void AdicionaAresta(Aresta aresta)
        {
            this.Arestas.Add(aresta);
            this.ArestasDoVertice.Add(new Tuple<Vertice, Vertice>(aresta.Origem, aresta.Destino), aresta);

            var outra = new Aresta(aresta.Destino, aresta.Origem);
            this.Arestas.Add(outra);
            this.ArestasDoVertice.Add(new Tuple<Vertice, Vertice>(outra.Origem, outra.Destino), outra);
        }

        public void RemoveAresta(Aresta aresta)
        {
            this.Arestas.Remove(aresta);
            this.Adjacentes[aresta.Origem.Id].Remove(aresta.Destino);
            this.Adjacentes[aresta.Destino.Id].Remove(aresta.Origem);
        }
    }
}
