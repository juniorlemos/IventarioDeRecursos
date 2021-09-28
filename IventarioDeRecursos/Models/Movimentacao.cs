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
        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }
        [Display(Name = "Responsável pela entrada do Recurso")]
        [Required]
        public string NomeEntradaRecurso { get; set; }
        [Display(Name = "Responsável pela saida do Recurso")]
        [Required]
        public string NomeSaidaRecurso { get; set; }
        [Display(Name = "Data de Entrada do recurso")]
        [Required]
        public DateTime DataEntrada { get; set; } = DateTime.Now;
        [Display(Name = "Data de Saida do recurso")]
        [Required]
        public DateTime DataSaida { get; set; }


        
      
        
       


    }
}
