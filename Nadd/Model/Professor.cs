using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadd.Model
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }

        [Required]
        public string Endereco { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}
