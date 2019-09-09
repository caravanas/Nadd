using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nadd.Model
{
    [Display(Name = "Avaliação")]
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        [Required(ErrorMessage = "A Data de Inicio da Avaição é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Data de Inicio da Avaliação")]
        [DataType(DataType.Date)]
        public DateTime DataInicioAvaliacao { get; set; }

        [Display(Name = "Data de Conclusão da Avaliação")]
        [DataType(DataType.Date)]
        public DateTime DataConclusaoAvaliacao { get; set; }

        [Display(Name = "Pontuação do Valor Explicito da Prova")]
        public int ValorProvaExplicito { get; set; }

        [Display(Name = "Pontuação do Valor por Questão")]
        public int ValorQuestaoExplicito { get; set; }

        [Display(Name = "Pontuação do Valor Total das Questões")]
        public int SomatorioValoresQuestoes { get; set; }

        [Display(Name = "Pontuação das Referencias Bibliograficas")]
        public int ReferenciasBibliograficas { get; set; }

        [Display(Name = "Pontuação da variedade entre questões Multipla Escolha e Discusirvas")]
        public int MultiplaEscolhaDiscursiva { get; set; }

        [Display(Name = "Pontuação do Valor Total da Prova")]
        public int ValorTotalProva { get; set; }

        [Display(Name = "Pontuação da Quantidade de Questões")]
        public int NumeroQuestoes { get; set; }

        [Display(Name = "Pontuação do Equilibiro entre Valor/Questão")]
        public int EquilibrioDistruibacaoValorQuestao { get; set; }

        [Display(Name = "Pontuação da Diversificação das Questões")]
        public int Diversificacao { get; set; }

        [Display(Name = "Pontuação da Contextualização das Questões")]
        public int QuestaoContextualizada { get; set; }

        [Display(Name = "Observações sobre a Avaliação")]
        public string Observacoes { get; set; }

        public virtual ICollection<Questao> Questoes { get; set; }
    }
}
