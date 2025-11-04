using System.ComponentModel.DataAnnotations;

namespace CrudMVC.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage ="O nome não pode term mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 100000, ErrorMessage = "O preço deve estar entre 0.01 e 100000")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(1, 100000, ErrorMessage = "O estoque deve estar entre 1 e 100000")]
        public int Estoque { get; set; }
    }
}
