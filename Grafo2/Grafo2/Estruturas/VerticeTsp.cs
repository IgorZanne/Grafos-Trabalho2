using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Estruturas
{
    public class VerticeTsp
    {
        public Vertice Pai { get; set; }
        public int Id { get; set; }
        public Ponto Ponto { get; set; }
        public bool Auxiliar { get; set; }

        public VerticeTsp(int id, Ponto ponto)
        {
            this.Id = id;
            this.Ponto = ponto;
            this.Auxiliar = true;
        }
    }
}
