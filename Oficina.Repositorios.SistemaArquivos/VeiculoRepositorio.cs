using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio : RepositorioBase
    {
        private XDocument arquivoXml;///esse cara é um field

        public VeiculoRepositorio() : base("caminhoArquivoVeiculo")
        {
            //arquivoXml = XDocument.Load(CaminhoArquivo);
        }

        //static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //    ConfigurationManager.AppSettings["caminhoArquivoVeiculo"]);


        public void Gravar<T>(T veiculo)///Método Genérico
        {
            var registro = new StringWriter();
            var serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(registro, veiculo);

            arquivoXml = XDocument.Load(CaminhoArquivo);

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            arquivoXml.Save(CaminhoArquivo);
        }
    }
}
