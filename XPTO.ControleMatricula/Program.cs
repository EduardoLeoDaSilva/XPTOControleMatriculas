using System;
using System.IO;
using XPTO.ControleMatricula.Servicos;

namespace XPTO.ControleMatricula
{
    class Program
    {
        

        static void Main(string[] args)
        {
            IniciarPrograma();
        }

        public static void IniciarPrograma()
        {
            Console.Clear();
            Console.WriteLine("Digite um número para escolher.");
            Console.WriteLine("1 - Gerar digito verificador ");
            Console.WriteLine("2 - Verificar matriculas apontando o erro e a acerto do digito verificador");
            var teclaDigitada = Console.ReadLine();
            if (teclaDigitada == "1")
                GerarDigitoVerificador();
            if (teclaDigitada == "2")
                VerificarMatriculas();
            if(teclaDigitada != "1" && teclaDigitada != "2")
            {
                Console.WriteLine("Opção inválida, aperte qualquer tecla para continuar");
                Console.ReadKey();
                IniciarPrograma();
            }
        }

        public static void VerificarMatriculas()
        {
            Console.WriteLine("Digite o caminho do arquivo com as matriculas que deseja realizar verificação");
            var caminhoArq = Console.ReadLine();

            try
            {
                var servicoMatricula = new ServicoMatricula();
                servicoMatricula.VerificarMatriculas(caminhoArq);

                string destinoArquivoCriado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                destinoArquivoCriado += @"\arquivosXPTOGerados";

                Console.WriteLine("Arquivo com matriculas verificadas gerado");
                Console.WriteLine($"O arquivo criado está em: {destinoArquivoCriado}");
                Console.ReadKey();
                IniciarPrograma();

            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer o processo: {ex.Message}");
                Console.WriteLine($"Tente novamente");
                Console.ReadKey();
                IniciarPrograma();
            }

        }

        public static void GerarDigitoVerificador()
        {
            Console.WriteLine("Digite o caminho do arquivo com as matriculas que deseja realizar a geração dos código verificadores");
            var caminhoArq = Console.ReadLine();
            try
            {
                var servicoMatricula = new ServicoMatricula();
                servicoMatricula.GerarDigitoParaMatriculas(caminhoArq);

                string destinoArquivoCriado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                destinoArquivoCriado += @"\arquivosXPTOGerados";

                Console.WriteLine("Arquivo com digitos gerado");
                Console.WriteLine($"Arquivo criado está em: {destinoArquivoCriado}");
                Console.ReadKey();
                IniciarPrograma();

            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ocorreu um erro ao fazer o processo: {ex.Message}");
                Console.WriteLine($"Tente novamente");
                Console.ReadKey();
                IniciarPrograma();
            }

        }
    }
}
