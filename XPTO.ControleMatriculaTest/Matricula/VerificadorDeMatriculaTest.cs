using System;
using System.Collections.Generic;
using System.Text;
using XPTO.ControleMatricula.Matricula;
using Xunit;

namespace XPTO.ControleMatriculaTest.Matricula
{
    public class VerificadorDeMatriculaTest
    {
        private readonly VerificadorDeMatriculas _verificadorDeMatriculas;
        public VerificadorDeMatriculaTest()
        {
            _verificadorDeMatriculas = new VerificadorDeMatriculas();
        }

        [Fact]
        public void DeveIdentificarODigitoVerificadorComoVerdadeiro()
        {
            string matriculaComDigitoVerificadorVerdadeiro = "0047-A";

            bool isDigitoCorreto = _verificadorDeMatriculas.Verificar(matriculaComDigitoVerificadorVerdadeiro);

            Assert.True(isDigitoCorreto);

        }

        [Fact]
        public void DeveIdentificarODigitoVerificadorComoFalso()
        {
            string matriculaComDigitoVerificadorFalso = "0047-E";

            bool isDigitoCorreto = _verificadorDeMatriculas.Verificar(matriculaComDigitoVerificadorFalso);

            Assert.False(isDigitoCorreto);

        }



    }
}
