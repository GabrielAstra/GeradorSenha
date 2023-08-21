using System;
using System.IO;

namespace GeradorSenhaComArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            int comprimento = 12; 
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()"; 
            Random random = new Random();

            char[] password = new char[comprimento];
            for (int i = 0; i < comprimento; i++)
            {
                int index = random.Next(caracteres.Length);
                password[i] = caracteres[index];
            }

            string senhaAleatoria = new string(password);

            Console.Write("Informe onde a senha será usada: ");
            string usoSenha = Console.ReadLine();

            string conteudoArquivo = $"Senha para uso em: {usoSenha}\nSenha: {senhaAleatoria}";

            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string nomeArquivo = $"senha_{DateTime.Now:yyyyMMddHHmmss}.txt";

            string caminhoCompleto = Path.Combine(documentosPath, nomeArquivo);

            File.WriteAllText(caminhoCompleto, conteudoArquivo);

            Console.WriteLine($"Senha gerada e salva no arquivo: {caminhoCompleto}");
        }
    }
}
