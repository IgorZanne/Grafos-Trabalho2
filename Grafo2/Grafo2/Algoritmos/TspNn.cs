using Grafo2.Estruturas;
using Grafo2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Algoritmos
{
    public class TspNn : Algoritmo
    {
        public override IEnumerable<string> Executar(string arquivo)
        {
            try
            {
                var grafo = GrafoHelper.LerTsp(arquivo);
                grafo.PreencherMatriz();
                var caminho = ExecutarTspNn(ref grafo);

                return MontaRetorno.GerarRetornoTsp(caminho, grafo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VerticeTsp> ExecutarTspNn(ref GrafoTsp grafo)
        {
            VerticeTsp proximo = null;
            int chave = 0;
            int tamanho = grafo.Vertices.Count;
            List<VerticeTsp> caminho = new List<VerticeTsp>();
            VerticeTsp inicial = grafo.Vertices.First().Value;
            inicial.Auxiliar = false;
            int linha = inicial.Id;
            caminho.Add(inicial);
            while (caminho.Count < tamanho)
            {
                int menorDistancia = grafo.MatrizDistancias[linha, linha];
                for (int coluna = 1; coluna <= tamanho; coluna++)
                {
                    int distancia = grafo.MatrizDistancias[linha, coluna];
                    if ((distancia < menorDistancia) && (grafo.Vertices[coluna].Auxiliar))
                    {
                        menorDistancia = distancia;
                        chave = coluna;
                    }
                }
                proximo = grafo.Vertices[chave];
                proximo.Auxiliar = false;
                caminho.Add(proximo);
                linha = proximo.Id;
            }
            caminho.Add(inicial);
            return caminho;
        }
    }
}
