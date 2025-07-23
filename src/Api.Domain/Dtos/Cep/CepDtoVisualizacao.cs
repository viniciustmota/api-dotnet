using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoVisualizacao
    {
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Município")]
        public string Municipio { get; set; }
        
        [Display(Name = "UF")]
        public string UfSigla { get; set; }
    }
}