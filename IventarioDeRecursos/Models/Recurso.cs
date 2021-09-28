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
        [StringLength(50, MinimumLength = 4, ErrorMessage =
            "A Descrição deve ter no mínimo 4 e no máximo 50 caracteres.")]
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        [Display(Name = "Observação")]
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        public string Observacao { get; set; }
        [Display(Name = "Responsável pelo recurso")]
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        public string NomeResponsavel { get; set; }

  



}
}
