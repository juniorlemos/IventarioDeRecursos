using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Models
{
    public class Recurso
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }


    }
}
