using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Capitulo03.Portfolio.Models {
    public class PortfolioViewModel 
    {
        public PortfolioViewModel()//método construtor
        {
            //CaminhoImagens = new List<string>();
        }
        //iniciando a lista porque toda a string inicia com nulo
        public List<string> CaminhoImagens { get; set; } = new List<string>();

    }
}