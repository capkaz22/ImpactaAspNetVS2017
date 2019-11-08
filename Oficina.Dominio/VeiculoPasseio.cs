using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //ToDo: OO - Herança
    public class VeiculoPasseio : Veiculo
    {
        public TipoCarroceria TipoCarroceria { get; set; }

        //ToDo: OO - Polimorfismo por sobrescrita.
        public override List<string> Validar()
        {
            var erros = base.ValidarBase();

            if (!Enum.IsDefined(typeof(TipoCarroceria), TipoCarroceria))//typeof é o tipo do enumerador, traz o resultado da property
            {
                erros.Add($"O Tipo da carroceria {TipoCarroceria } não é valido,");
            }


            return erros;
        }


        
    }
}
