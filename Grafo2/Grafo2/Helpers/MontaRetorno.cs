using Grafo2.Estruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Helpers
{
    public static class MontaRetorno
    {
        public static IEnumerable<string> GerarRetornoTsp(List<VerticeTsp> caminho, GrafoTsp grafo)
        {
            var retorno = new List<string>();

            int distancia = 0;
            int tamanho = (caminho.Count - 1);

            for (int i = 0; i < tamanho; i++)
                distancia += grafo.MatrizDistancias[caminho[i].Id, caminho[i + 1].Id];

            retorno.Add(distancia.ToString());

            foreach (var item in caminho)
                retorno.Add(item.Id.ToString());

            return retorno;
        }

        public static IEnumerable<string> GerarRetornoHierholzer(List<Vertice> ciclo)
        {
            var retorno = new List<string>();
            foreach (var item in ciclo)
                retorno.Add(item.Id);

            return retorno;
        }
    }
}
