﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Estruturas
{
    public class Aresta
    {
        public Aresta(Vertice origem, Vertice destino)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Peso = 0;
            this.Visitado = false;
        }

        public Aresta(Vertice origem, Vertice destino, int peso)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.Peso = peso;
            this.Visitado = false;
        }

        public int Peso { get; set; }
        public Vertice Origem { get; set; }
        public Vertice Destino { get; set; }
        public bool Visitado { get; set; }
    }
}
