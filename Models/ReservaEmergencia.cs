using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class ReservaEmergencia
    {
        public int Id { get; set; }

        DateTime dataEntrada {get; set;}

        public decimal Valor {get; set;}

        public string Tipo {get; set;}

    }
}