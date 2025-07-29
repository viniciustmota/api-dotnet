using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api.Domain.Atributes;

namespace Api.Domain.Dtos.Municipio;

public class MunicipioDto
{
    [Required]
    [Key]
    [JsonPropertyName("id")]
    [Display(Name = "Id")]
    [Visible(false)]
    public Guid Id { get; set; }

    [Required]
    [JsonPropertyName("nome")]
    [Display(Name = "Município")]
    [Visible(true)]
    public string Nome { get; set; }

    [Required]
    [JsonPropertyName("codIBGE")]
    [Display(Name = "Código IBGE")]
    [Visible(true)]
    public int CodIBGE { get; set; }

    [Required]
    [JsonPropertyName("ufId")]
    [Display(Name = "UF")]
    [Combo]
    [Visible(true)]
    [Options("ufs")]
    public Guid UfId { get; set; }

    [JsonPropertyName("ufSigla")]
    [Display(Name = "UF")]
    [Visible(true)]
    public string UfSigla { get; set; }
}
