using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Estruturas
{
    public class Aresta
    {
        public Aresta(string origem, string destino)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Peso = 0;
            this.Visitado = false;
        }

        public Aresta(string origem, string destino, int peso)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Peso = peso;
            this.Visitado = false;
        }

        public int Peso { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public bool Visitado { get; set; }
    }
}
