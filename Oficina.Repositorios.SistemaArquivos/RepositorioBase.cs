using System;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class RepositorioBase
    {
        public RepositorioBase(string chave)//atalho para gerar método construtor 'ctor'
        {
            CaminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                ConfigurationManager.AppSettings[chave]);

        }

        public string CaminhoArquivo { get; }///somente leitura

    }
}