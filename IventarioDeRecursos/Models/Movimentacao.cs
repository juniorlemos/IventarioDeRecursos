using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Models
{
    public class Movimentacao
    {
        [Key]
        public string Descricao { get; set; }
        public string NomeEntradaRecurso { get; set; }
        public string NomeSaidaRecurso { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        public DateTime DataSaida { get; set; }


        
      
        
       


    }
}
