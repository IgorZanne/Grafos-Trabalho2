﻿using Grafo2.Estruturas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo2.Helpers
{
    public static class GrafoHelper
    {
        public static Grafo Ler(string caminhoArquivo)
        {
            var arquivo = File.ReadAllLines(caminhoArquivo);
            var retorno = new Grafo();

            var primeiraParte = true;
            foreach (var linha in arquivo)
            {
                if (linha.Equals("#"))
                {
                    primeiraParte = false;
                    continue;
                }
                if (primeiraParte) 
                {
                    var vertice = new Vertice(linha);
                    retorno.AdicionaVertice(vertice);
                }
                else
                {
                    var carac = linha.Split(' ');
                    var tamanho = carac.Length;
                    if (tamanho <= 0 || tamanho > 3)
                        throw new Exception("Não foi possível identificar especificações da aresta no arquivo de entrada");

                    if (tamanho >= 2) 
                    {
                        var origem = retorno.Vertices[carac[0]];
                        var destino = retorno.Vertices[carac[1]];
                        retorno.Adjacentes[origem.Id].Add(destino);
                        retorno.Adjacentes[destino.Id].Add(origem);
                        var aresta = new Aresta(origem, destino);
                        if (tamanho > 2)
                            aresta.Peso = Convert.ToInt16(carac[2]);
                        retorno.AdicionaAresta(aresta);
                    }
                }
            }

            return retorno;
        }

        public static GrafoTsp LerTsp(string caminhoArquivo)
        {
            var arquivo = File.ReadAllLines(caminhoArquivo);
            var retorno = new GrafoTsp(arquivo.Length);

            foreach (var linha in arquivo)
            {
                try
                {
                    var split = linha.Trim().Split(' ');
                    var ponto = new Ponto(Convert.ToDouble(split[1]), Convert.ToDouble(split[2]));
                    var vertice = new VerticeTsp(Convert.ToInt32(split[0]), ponto);
                    retorno.Vertices.Add(Convert.ToInt32(split[0]), vertice);
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("Erro ao tratar linha: '{0}' . Mensagem de erro: {1}", linha, e.Message));
                }
            }


            return retorno;
        }
    }
}
