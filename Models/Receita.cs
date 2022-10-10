using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class Receita
    {
        public int Id { get; set; }
        
        // imprimi o $
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        public string Tipo { get; set; }   

        
    }
}