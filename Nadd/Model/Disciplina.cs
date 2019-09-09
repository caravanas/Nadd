using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadd.Model
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da Disciplina é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Display(Name = "Carga Horária")]
        public int CargaHoraria { get; set; }

        public int Periodo { get; set; }

        public int Ano { get; set; }

        [Display(Name = "Nome do Curso")]
        public int CursoID { get; set; }
        public Curso Curso { get; set; }

        [Display(Name = "Nome do(a) Professor(a)")]
        public int ProfessorID { get; set; }
        public Professor Professor { get; set; }

        public ICollection<Avaliacao> Avaliacaos { get; set; }

    }
}
