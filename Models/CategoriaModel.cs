using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Models
{
    public class CategoriaModel
    {
        [Key]
        public decimal Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome da categoria, é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome da categoria não pode ultrapassar 150 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Situacao")]
        [Required(ErrorMessage = "Situação é obrigatório (Ativo - True, Inativo - False)")]
        public bool Situacao { get; set; }
    }
}
