using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XPTO.ControleMatricula.Utils
{
    public class FileUtil
    {

        //Ler o conteudo de um arquivo de texto e retorna suas linhas em uma lista de string
        public static List<string> LerArquivo(string caminhoArquivo)
        {
            var listaDeLinhas = new List<string>();
            string linha = string.Empty;
            try
            {
                if (!File.Exists(caminhoArquivo))
                {
                    throw new FileNotFoundException("Arquivo não encontrado!");
                }

                using (var texto = new StreamReader(caminhoArquivo))
                {
                    while ((linha = texto.ReadLine()) != null)
                    {
                        listaDeLinhas.Add(linha);
                    }
                }
                return listaDeLinhas;
            }
            catch (IOException)
            {
                throw;
            }
        }

        //Cria um arquivo de texto e grava o conteúdo(matriculas) linha por linha;
        public static bool CriarArquivo(string nomeArquivo, string caminhoArquivo, List<string> matriculas)
        {
            try
            {

                if (!Directory.Exists(caminhoArquivo))
                    Directory.CreateDirectory(caminhoArquivo);

                var caminhoArquivoCompleto = $@"{caminhoArquivo}\{nomeArquivo}";
                    
                var stream = File.Create(caminhoArquivoCompleto);
                using (var streamCriadorDeArq = new StreamWriter(stream))
                {
                    foreach (var item in matriculas)
                    {
                        streamCriadorDeArq.WriteLine(item);
                    }

                }
                return true;
            }
            catch (IOException)
            {

                throw;
            }
        }
    }
}



