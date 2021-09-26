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
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public string NomeResponsavel { get; set; }

  



}
}
