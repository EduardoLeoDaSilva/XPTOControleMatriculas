using System;
using System.Collections.Generic;
using System.Text;
using XPTO.ControleMatricula.Extencoes;

namespace XPTO.ControleMatricula.Matricula
{
    public class GeradorDigitoVerificador
    {

        //Gera o digito verificador para uma matricula, retornando apenas o digito
        public string Gerar(string matricula)
        {
            var numerosMatriculasCharArray = matricula.ToCharArray();
            var numerosMatriculasIntLista = numerosMatriculasCharArray.ParaListaDeInteiros();
            numerosMatriculasIntLista[0] *=  5;
            numerosMatriculasIntLista[1] *=  4;
            numerosMatriculasIntLista[2] *=  3;
            numerosMatriculasIntLista[3] *=  2;
            var total = SomarNumerosInteirosMatricula(numerosMatriculasIntLista);

            var restoDivisao = total % 16;

            return restoDivisao.ToString("X");

        }

        //Retorna a matricula completa com o digito verificador
        public string ObterMatriculaComDigitoVerificador(string matricula)
        {
             var digitoHexaDecimal =  this.Gerar(matricula);

            string matriculaComDigitoVerificador = $"{matricula}-{digitoHexaDecimal}";

            return matriculaComDigitoVerificador;

        }

        //Realiza a soma para obter total da multiplicações feita em cada numero de uma matricula
        private int SomarNumerosInteirosMatricula(List<int> numerosMatriculasIntLista)
        {
            int total = 0;
            foreach (var item in numerosMatriculasIntLista)
            {
                total += item;
            }
            return total;
        }
    }
}
