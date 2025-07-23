using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Dtos.Cep
{
    public class CepDto
    {
        [Required]
        [Key]
        [JsonPropertyName("id")]
        [Display(Name = "Id")]
        [Visible(false)]
        public Guid Id { get; set; }

        [Required]
        [JsonPropertyName("cep")]
        [Display(Name = "CEP")]
        [Visible(true)]
        public string Cep { get; set; }

        [Required]
        [JsonPropertyName("logradouro")]
        [Display(Name = "Logradouro")]
        [Visible(true)]
        public string Logradouro { get; set; }

        [Required]
        [JsonPropertyName("numero")]
        [Display(Name = "Número")]
        [Visible(true)]
        public string Numero { get; set; }

        [Required]
        [JsonPropertyName("municipioId")]
        [Display(Name = "Município")]
        [Combo]
        [Visible(true)]
        [Options("municipios")]
        public Guid MunicipioId { get; set; }
        
        [Required]
        [JsonPropertyName("municipio")]
        [Display(Name = "Município")]
        [Visible(true)]
        public MunicipioDtoCompleto Municipio { get; set; }

    }
}