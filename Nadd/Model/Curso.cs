using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadd.Model
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do Curso é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Display(Name = "Nome da Área")]
        public int AreaID { get; set; }
        public Area Area { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}
