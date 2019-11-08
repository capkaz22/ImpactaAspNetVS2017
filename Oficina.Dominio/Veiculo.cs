using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - Classe ou abstração.

    public abstract class Veiculo
    {
        private string placa;

        //ToDo: OO - Encapsulamento.
        public string Placa 
        {

            get///todo o get tem um return
            {
                return Placa.ToUpper();
            }
            set 
            {
                placa = value.ToUpper();
            }
        }// método get pegar, metódo set atribuir


        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        public int Ano { get; set; }
        public string Observacao { get; set; }

        public List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (!Enum.IsDefined(typeof(Cambio),Cambio))//typeof é o tipo do enumerador, traz o resultado da property
            {
                erros.Add($"O Cambio {Cambio} não é valido,");
            }

            return erros;
        }

        public abstract List<string> Validar();

    }
}