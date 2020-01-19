using System;
using System.Collections.Generic;
using System.Text;
using XPTO.ControleMatricula.Matricula;
using Xunit;

namespace XPTO.ControleMatriculaTest.Matricula
{
    public class GeradorDigitoVerificadorTest
    {

        private readonly GeradorDigitoVerificador _geradorDigitoVericiador;

        public GeradorDigitoVerificadorTest()
        {
            _geradorDigitoVericiador = new GeradorDigitoVerificador();
        }

        [Fact]
        public void DeveGerarUmDigitoVerificadorVerdadeiro()
        {
            string digitoVerificadorEsperado = "A";
            string matriculaSemODigito = "0047";

            var digitoVerificadorGerado = _geradorDigitoVericiador.Gerar(matriculaSemODigito);

            Assert.Equal(digitoVerificadorEsperado, digitoVerificadorGerado);
        }

        [Fact]
        public void DeveGerarUmaMatriculaCompletaComDigitoVerdadeiro()
        {
            string matriculaSemODigito = "0047";
            string matriculaEsperada = "0047-A";

            var matriculaGerada = _geradorDigitoVericiador.ObterMatriculaComDigitoVerificador(matriculaSemODigito);

            Assert.Equal(matriculaEsperada, matriculaGerada);

        }

    }
}
