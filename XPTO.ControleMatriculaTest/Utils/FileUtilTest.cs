using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XPTO.ControleMatricula.Utils;
using Xunit;

namespace XPTO.ControleMatriculaTest.Utils
{
    public class FileUtilTest
    {
        private readonly List<string> listaMatriculasEsperada;
        public FileUtilTest()
        {
            listaMatriculasEsperada = new List<string> { "3598", "3841", "2148", "0480", "7557", "4674", "4534", "9617", "6176", "8789" };
        }

        [Fact]
        public void DeveLerOArquivo()
        {

            var listaMatricula = FileUtil.LerArquivo(@"C:\Users\Dud\Downloads\matriculasSemDV.txt");

            Assert.Equal(listaMatriculasEsperada, listaMatricula);

        }

        [Fact]
        public void NaoDeveTerOCaminhoDoArquivoInválido()
        {
            string caminhoInvalido = @"C:\caminhoInvalidoParaTeste";

            Assert.Throws<FileNotFoundException>(() => FileUtil.LerArquivo(caminhoInvalido));

        }

        [Fact]
        public void DeveCriarOArquivo()
        {
            string caminhoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nomeArquivo = "teste.txt";

            var foiCriado = FileUtil.CriarArquivo(nomeArquivo, caminhoArquivo, listaMatriculasEsperada);

            Assert.True(foiCriado);

        }

    }
}
