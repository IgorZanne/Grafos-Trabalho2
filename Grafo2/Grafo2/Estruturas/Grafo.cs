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
        public List<Aresta> ArestasDir { get; set; }

        public Dictionary<string, Vertice> Vertices { get; set; }

        public Dictionary<string, Vertice> GetAdj(string vertice)
        {
            return this.Direcionado 
                ? Vertices[vertice].Adjacentes
                : Vertices[vertice].Adjacentes
                    .Concat(Vertices[vertice].AdjacentesDir)
                    .ToDictionary(e => e.Key, v => v.Value);
        }

        public IEnumerable<Aresta> GetArestas()
        {
            return this.Arestas.Concat(this.ArestasDir);
        }

        public Grafo()
        {
            this.Direcionado = true;
            this.Vertices = new Dictionary<string, Vertice>();
            this.Arestas = new List<Aresta>();
            this.ArestasDir = new List<Aresta>();
        }

        public Grafo(bool direcionado)
        {
            this.Direcionado = direcionado;
            this.Vertices = new Dictionary<string, Vertice>();
            this.Arestas = new List<Aresta>();
            this.ArestasDir = new List<Aresta>();
        }
    }
}
