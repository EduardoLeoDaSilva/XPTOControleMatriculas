using System;
using System.Collections.Generic;
using System.Text;
using XPTO.ControleMatricula.Matricula;

namespace XPTO.ControleMatricula.Matricula
{
    public class VerificadorDeMatriculas
    {

        //Faz a verificação do digito de uma matricula apontando se é verdadeiro ou falso retornando um bool
        public bool Verificar(string matriculaParaVerificar)
        {
            var geradorDeDigitoVerificador = new GeradorDigitoVerificador();


            var matriculaSemODigito = matriculaParaVerificar.Split('-');

            var matriculaComDigitoVerificadoCerto = geradorDeDigitoVerificador.ObterMatriculaComDigitoVerificador(matriculaSemODigito[0]);

            bool isVerdadeiro = matriculaParaVerificar.Equals(matriculaComDigitoVerificadoCerto);

            return isVerdadeiro;

        }
    }
}
