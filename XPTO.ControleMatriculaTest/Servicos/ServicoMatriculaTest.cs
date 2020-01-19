using System;
using System.Collections.Generic;
using System.IO;
using XPTO.ControleMatricula.Servicos;
using Xunit;

namespace XPTO.ControleMatriculaTest.Servicos
{
    public class ServicoMatriculaTest
    {
        private readonly ServicoMatricula _servicoMatricula;
        public ServicoMatriculaTest()
        {
            _servicoMatricula = new ServicoMatricula();
        }

        [Fact]
        public void NaoDeveTerArquivoComConteudoInvalidoAoTentarGerarDigito()
        {
            string caminhoValido = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            caminhoValido += @"\matriculasConteudoInvalido.txt";

            Assert.Throws<IOException>(() => _servicoMatricula.GerarDigitoParaMatriculas(caminhoValido));
        }

        [Fact]
        public void NaoDeveTerArquivoComConteudoInvalidoAoTentarVerificarDigito()
        {
            string caminhoValido = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            caminhoValido += @"\matriculasConteudoInvalido.txt";

            Assert.Throws<IOException>(() => _servicoMatricula.VerificarMatriculas(caminhoValido));

        }

        [Fact]
        public void DeveTerArquivoUmConteudoValido()
        {
            var listaInvalida = new List<string> { "3431,", "5462" };

           var resultado = _servicoMatricula.ValidarArquivoInserido(listaInvalida);

            Assert.False(resultado);
        }

    }
}
