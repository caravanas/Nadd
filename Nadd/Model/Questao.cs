using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadd.Model
{
    [Display(Name = "Questão")]
    public class Questao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Numero/Letra da Questão é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Numero/Letra da Questão")]
        public string questao { get; set; }

        [Required(ErrorMessage = "O Contexto da Questão é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Contexto da Questão")]
        public int contexto { get; set; }

        [Required(ErrorMessage = "A Clareza da Questão é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Clareza da Questão")]
        public int clareza { get; set; }

        [Required(ErrorMessage = "A Complixidade da Questão é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Complixidade da Questão")]
        public int complexidade { get; set; }

        public int AvaliacaoId { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }

    }
}
