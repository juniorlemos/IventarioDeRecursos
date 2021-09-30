using System;
using System.ComponentModel.DataAnnotations;

namespace IventarioDeRecursos.Models
{
    public class Movimentacao
    {
        
        public int MovimentacaoID { get; set; }
        
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        [Display(Name = "Responsável pela entrada ")]
        [Required]
        public string NomeEntradaRecurso { get; set; }
        [Display(Name = "Responsável pela saida ")]
        [Required]
        public string NomeSaidaRecurso { get; set; }
        [Display(Name = "Data de Entrada ")]
        [Required]
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        [Display(Name = "Data de Saida")]
        [Required]
        public DateTime DataSaida { get; set; }


        
      
        
       


    }
}
