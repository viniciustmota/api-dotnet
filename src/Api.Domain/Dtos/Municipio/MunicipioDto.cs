using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Domain.Dtos.Municipio;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class VisibleAttribute : Attribute
{
    public bool Visible { get; set; } = false;

    public VisibleAttribute(bool visible)
    {
        Visible = visible;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class ComboAttribute : Attribute
{
    public ComboAttribute() { }
}

[AttributeUsage(AttributeTargets.Property)]
public class OptionsAttribute : Attribute
{
    public string Source { get; }
    public OptionsAttribute(string source)
    {
        Source = source;
    }
}

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
