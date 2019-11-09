using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class Frete
    {
        public Frete(UF uf, decimal valorProdutor)///método construtor//objeto parâmetro inicia com letra minuscula
        {
            UF = uf;
            ValorProduto = valorProdutor;
            Calcular();//método calcular

        }

        public Cliente Cliente { get; set; }
        public decimal ValorProduto { get; set; }
        public UF UF { get; set; }
        public decimal ValorFrete { get; private set; }///se remover o set você transforma a property em ready only
            ///Quando ocorre um private somente dentro da própria classe Frete poderá manipular o valor
        public decimal ValorTotal { get; private set; }

        private void Calcular()
        {
            switch (UF.ToString().ToUpper())
            {
                case "SP":
                    ValorFrete = 0.2m;
                    break;

                case "RJ":
                case "ES":
                    ValorFrete = 0.3m;
                    break;

                case "MG":
                    ValorFrete = 0.35m;
                    break;

                case "AM":
                    ValorFrete = 0.6m;
                    break;

                default:
                    ValorFrete = 0.7m;
                    break;
            }

            //ValorTotal += (ValorProduto * ValorFrete);
            ValorTotal = (1 + ValorFrete) * ValorProduto;
        }
    }
}
