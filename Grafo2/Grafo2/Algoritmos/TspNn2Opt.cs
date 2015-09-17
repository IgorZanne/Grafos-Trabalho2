using Grafo2.Estruturas;
using Grafo2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Algoritmos
{
    public class TspNn2Opt : Algoritmo
    {
        public override IEnumerable<string> Executar(string arquivo)
        {
            try
            {
                var grafo = GrafoHelper.LerTsp(arquivo);
                grafo.PreencherMatriz();

                var tspnn = new TspNn();
                var retTspnn = tspnn.ExecutarTspNn(grafo);
                var caminho = opt2(retTspnn, grafo);

                return MontaRetorno.GerarRetornoTsp(caminho, grafo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VerticeTsp> opt2(List<VerticeTsp> caminho, GrafoTsp grafo)
        {
            int tamanho = caminho.Count - 1;
            while (true)
            {
                int max = 0;
                Tuple<VerticeTsp, VerticeTsp, VerticeTsp, VerticeTsp> best = null;

                var n = caminho.Count;
                for (var i = 0; i < n - 3; i++)
                {
                    var a = caminho[i];
                    var b = caminho[i + 1];
                    for (var j = i + 2; j < n - 1; j++)
                    {
                        var c = caminho[j];
                        var d = caminho[j + 1];

                        var difenca = calculaDiferenca(caminho, grafo, a, b, c, d);
                        if (difenca > max)
                        {
                            max = difenca;
                            best = new Tuple<VerticeTsp, VerticeTsp, VerticeTsp, VerticeTsp>(a, b, c, d);
                        }
                    }
                }

                if (max != 0)
                {
                    var bi = caminho.IndexOf(best.Item2);
                    var ci = caminho.IndexOf(best.Item3);

                    caminho.RemoveAt(bi);
                    caminho.Insert(bi, best.Item3);
                    caminho.RemoveAt(ci);
                    caminho.Insert(ci, best.Item2);
                }
                else
                {
                    break;
                }
            }

            return caminho;
        }

        private int calculaDiferenca(List<VerticeTsp> caminho, GrafoTsp grafo, VerticeTsp a, VerticeTsp b, VerticeTsp c, VerticeTsp d)
        {
            int diferenca = (
                grafo.MatrizDistancias[a.Id, b.Id] + grafo.MatrizDistancias[c.Id, d.Id]
              - grafo.MatrizDistancias[a.Id, c.Id] - grafo.MatrizDistancias[b.Id, d.Id]);
            return diferenca;
        }
    }
}
