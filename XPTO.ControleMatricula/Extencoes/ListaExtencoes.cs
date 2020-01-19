using System;
using System.Collections.Generic;
using System.Text;

namespace XPTO.ControleMatricula.Extencoes
{
    public static class ListaExtencoes
    {
        //Método de extencao para tranformar uma array de char em uma lista de int
        public static List<int> ParaListaDeInteiros (this char[] charArray)
        {
            var listaDeInteiros = new List<int>();
            foreach (var item in charArray)
            {
                listaDeInteiros.Add(Int32.Parse(item.ToString()));
            }
            return listaDeInteiros;
        }
    }
}
