using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Veiculo
{
    public class VeiculoDtoCreate
    {
        [Required(ErrorMessage = "Placa é campo obrigatório")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Modelo é campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Modelo deve ter no máximo {1} caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Marca é campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Marca deve ter no máximo {1} caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Ano é campo obrigatório.")]
        [StringLength(4, ErrorMessage = "Ano deve ter no máximo {1} caracteres.")]
        public int Ano { get; set; }
        
        [Required(ErrorMessage = "Cor é campo obrigatório.")]
        [StringLength(20, ErrorMessage = "Cor deve ter no máximo {1} caracteres.")]
        public string Cor { get; set; }
    }
}