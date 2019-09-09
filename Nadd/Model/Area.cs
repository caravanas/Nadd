using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadd.Model
{
    public class Area
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome da Área é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}
