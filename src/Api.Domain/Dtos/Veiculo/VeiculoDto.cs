using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api.Domain.Atributes;

namespace Api.Domain.Dtos.Veiculo
{
    public class VeiculoDto
    {
        [Required]
        [Key]
        [JsonPropertyName("id")]
        [Display(Name = "Id")]
        [Visible(false)]
        public Guid Id { get; set; }

        [Required]
        [JsonPropertyName("placa")]
        [Display(Name = "Placa")]
        [Visible(true)]
        public string Placa { get; set; }

        [Required]
        [JsonPropertyName("modelo")]
        [Display(Name = "Modelo")]
        [Visible(true)]
        public string Modelo { get; set; }

        [Required]
        [JsonPropertyName("marca")]
        [Display(Name = "Marca")]
        [Visible(true)]
        public string Marca { get; set; }

        [Required]
        [JsonPropertyName("ano")]
        [Display(Name = "Ano")]
        [Visible(true)]
        public int Ano { get; set; }

        [Required]
        [JsonPropertyName("cor")]
        [Display(Name = "Cor")]
        [Visible(true)]
        public string Cor { get; set; }
    }
}