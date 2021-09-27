using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Models
{
    public class Recurso
    {
       [Key]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Display(Name = "Resposável pelo recurso")]
        public string NomeResponsavel { get; set; }

  



}
}
