using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Estruturas
{
    public class GrafoTsp
    {
        public Dictionary<int, VerticeTsp> Vertices;
        public int[,] MatrizDistancias;

        public GrafoTsp(int tamanho)
        {
            this.Vertices = new Dictionary<int, VerticeTsp>();
            this.MatrizDistancias = new int[tamanho+1, tamanho+1];
        }

        public void PreencherMatriz()
        {
            foreach (var vertice1 in Vertices)
            {
                VerticeTsp vOrigem = vertice1.Value;
                foreach (var vertice2 in Vertices)
                {
                    VerticeTsp vDestino = vertice2.Value;
                    int distancia = CalcularDistancia(vOrigem, vDestino);
                    this.MatrizDistancias[vOrigem.Id, vDestino.Id] = distancia;
                }
            }
        }

        private int CalcularDistancia(VerticeTsp origem, VerticeTsp destino)
        {
            if (origem.Id != destino.Id)
            {
                double dx = origem.Ponto.x - destino.Ponto.x;
                double dy = origem.Ponto.y - destino.Ponto.y;
                double distanciaReal = Math.Sqrt((dx * dx) + (dy * dy));
                return (int)(distanciaReal + 0.5);
            }
            else
            {
                return Int32.MaxValue;
            }
        }
    }
}
