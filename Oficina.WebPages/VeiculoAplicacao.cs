using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        private readonly CorRepositorio corRepositorio = new CorRepositorio();
        private readonly MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        private readonly ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        private readonly VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();

        public VeiculoAplicacao()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; set; }
        public string MarcaSelecionada { get; set; }
        public List<Cor> Cores { get; set; }
        public List<Modelo> Modelos { get; set; } = new List<Modelo>();
        public List<Combustivel> Combustiveis { get; set; }
        public List<Cambio> Cambios { get; set; }
        public string MensagemErro { get; private set; }//properties

        private void PopularControles()
        {
            Marcas = marcaRepositorio.Obter();//método obter

            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = modeloRepositorio.ObterPorMarca(Convert.ToInt32(MarcaSelecionada));
            }


            Cores = corRepositorio.Obter();

            Combustiveis = Enum
                .GetValues(typeof(Combustivel))
                .Cast<Combustivel>()
                .ToList();

            Cambios = Enum
                .GetValues(typeof(Cambio))
                .Cast<Cambio>()
                .ToList();
        }

        public void Gravar()
        {
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;
                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);///convertendo para um formato enumerador
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);///convertendo para um formato enumerador
                veiculo.Modelo = modeloRepositorio.Obter(Convert.ToInt32(formulario["modelo"]));
                veiculo.Cor = corRepositorio.Obter(Convert.ToInt32(formulario["cor"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"];
                veiculo.TipoCarroceria = TipoCarroceria.Hatch;

                veiculoRepositorio.Gravar(veiculo);

            }
            catch(FileNotFoundException ex)
            {
                MensagemErro = $"Arquivo {ex.FileName} não encontrado!";
            }
            catch (DirectoryNotFoundException ex)
            {
                MensagemErro = "Caminho não encontrado!";
            }
            catch (Exception)
            {
                MensagemErro = "Eita, algo deu errado!";
            }
            finally
            {
                //não é obrigatório e roda sempre, com sucesso ou erro.
                //se tiver um return, o finally também é executado!!!
            }
        }
    }
}