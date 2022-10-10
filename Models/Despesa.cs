using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descrição { get; set; }
        public decimal Valor { get; set; }  
    }
}