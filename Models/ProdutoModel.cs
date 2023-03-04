using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAPI.Models
{
    public class ProdutoModel
    {
        [Key]
        public decimal Id { get; set; }
        
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Nome do produto não pode ultrapassar 250 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get; set; } = 0;

        [Display(Name = "Situação")]
        [Required(ErrorMessage = "Situação é obrigatório (Ativo - True, Inativo - False)")]
        public bool Situacao { get; set; }
        //Categoria
        [Display(Name = "Categoria Id")]
        [Required(ErrorMessage = "Código da categoria é obrigatório - Ver lista de categorias")]
        public decimal CategoriaId { get; set; }
    }
}
