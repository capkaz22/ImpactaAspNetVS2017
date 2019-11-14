using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ViagensOnline.Mvc.Models
{
    public class DestinoViewModel
    {
        //[Required]//toda a vez que coloco essa instrução gera uma validação no formulário
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string CaminhoImagem { get; set; }

        [Display(Name = "Foto")]
        [DisplayName("Foto")]//outra forma de fazer

        public HttpPostedFileBase ArquivoFoto { get; set; }
    }
}