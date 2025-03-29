using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CpDotnet.Models
{
    [Table("TDS_TB_Brinquedos")]
    public class Brinquedo
    {
        [Key]
        public int Id_brinquedo { get; set; }

        [Required(ErrorMessage = "O campo Nome do Brinquedo é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome do Brinquedo deve ter no máximo 100 caractere")]
        public string Nome_brinquedo { get; set; }

        [Required(ErrorMessage = "O campo Tipo do Brinquedo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Tipo do Brinquedo deve ter no máximo 50 caracteres")]
        public string Tipo_brinquedo { get; set; }

        [MaxLength(50, ErrorMessage = "A Classificação deve ter no máximo 50 caracteres")]
        public string Classificacao { get; set; }

        [MaxLength(50, ErrorMessage = "O Tamanho deve ter no máximo 50 caracteres")]
        public string Tamanho { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero")]
        public decimal Preco { get; set; }
    }
}
