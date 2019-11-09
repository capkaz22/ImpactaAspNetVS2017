using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio.Tests
{
    [TestClass()]
    public class FreteTests
    {
        [TestMethod()]
        public void CalcularTest()
        {
            var frete = new Frete(UF.MG, 20.2m);
            frete.Cliente = new Cliente { Nome = "Vitor" };//property do tipo frete.cliente
            //frete.UF = UF.MG;
            //frete.ValorFrete = 200;//não posso fazer input do valor do frete por que ele é privado
            //frete.ValorProduto = 21.19m;///sempre inserir o 'm' para validar o decimal

            //frete.Calcular();//chamando o método calcular

            Assert.AreEqual(frete.ValorFrete, 0.35m);
            Assert.AreEqual(frete.ValorTotal, 27.27m);




        }
    }
}