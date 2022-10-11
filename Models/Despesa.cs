using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }  
       
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        
    }
}