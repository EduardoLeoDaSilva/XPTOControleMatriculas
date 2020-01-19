using System;
using System.Collections.Generic;
using System.Text;
using XPTO.ControleMatricula.Utils;
using XPTO.ControleMatricula.Matricula;
using System.Text.RegularExpressions;
using System.IO;

namespace XPTO.ControleMatricula.Servicos
{
    //Realiza a comunicação com a UI(console), usando os métodos já criados
    public class ServicoMatricula
    {
        private readonly GeradorDigitoVerificador _geradorDigitoVerificador;
        private readonly VerificadorDeMatriculas _verificadorDeMatriculas;
        public ServicoMatricula()
        {
            _geradorDigitoVerificador = new GeradorDigitoVerificador();
            _verificadorDeMatriculas = new VerificadorDeMatriculas();
        }

        //Método que usa de fato os métodos necessários para geração do digito verificador de cada matricula e para criação do arquivo
        public void GerarDigitoParaMatriculas(string caminhoArq)
        {
            List<string> listaMatriculasJaComDigitoVerificador = new List<string>();
            var listaDeMatriculasString = FileUtil.LerArquivo(caminhoArq);

            bool isValido = ValidarArquivoInserido(listaDeMatriculasString);

            if (!isValido)
                throw new IOException("Arquivo inserido é inválido");

            foreach (var matricula in listaDeMatriculasString)
            {
               var matriculaComDigito = _geradorDigitoVerificador.ObterMatriculaComDigitoVerificador(matricula);
                listaMatriculasJaComDigitoVerificador.Add(matriculaComDigito);
            }
            string destinoArquivoCriado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            destinoArquivoCriado += @"\arquivosXPTOGerados";
            FileUtil.CriarArquivo("matriculasComDV.txt", destinoArquivoCriado, listaMatriculasJaComDigitoVerificador);

        }

        //Método que usa de fato os métodos necessários para verificação de matricula e para criação do arquivo

        public void VerificarMatriculas(string caminhoArq)
        {

            List<string> listaMatriculasVerificadas = new List<string>();
            var listaDeMatriculasParaVerificarString = FileUtil.LerArquivo(caminhoArq);

            bool isValido = ValidarArquivoInserido(listaDeMatriculasParaVerificarString);

            if (!isValido)
                throw new IOException("Arquivo inserido é inválido");

            foreach (var matricula in listaDeMatriculasParaVerificarString)
            {
                bool isVerdadeiro = _verificadorDeMatriculas.Verificar(matricula);
                string verdadeiroOuFalso = isVerdadeiro == true ? "verdadeiro" : "falso";
                listaMatriculasVerificadas.Add($"{matricula} {verdadeiroOuFalso}");
            }

            string destinoArquivoCriado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            destinoArquivoCriado += @"\arquivosXPTOGerados";

            FileUtil.CriarArquivo("matriculasVerificadas.txt", destinoArquivoCriado, listaMatriculasVerificadas);

        }


        //Verifica se arquivo para  realizar a leitura inserido no programa tem o conteúdo inválido;
        public bool ValidarArquivoInserido(List<string> listaDeLinhasLidaDoArquivo)
        {
            Regex regex = new Regex("[0-9]{4,4}-[0-9A-F]");
            int numeroAux = 0;
            foreach (var linha in listaDeLinhasLidaDoArquivo)
            {
                if (!regex.IsMatch(linha) && linha.Length ==6)
                    return false;
                if (linha.Length > 6 || linha.Length == 5)
                    return false;
                if (linha.Length == 4 && int.TryParse(linha, out numeroAux) == false)
                    return false;
            }
            return true;
        }


    }
}
