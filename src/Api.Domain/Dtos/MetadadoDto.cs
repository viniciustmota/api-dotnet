using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Field;

namespace Api.Domain.Dtos
{
    public class MetadadoDto
    {
        public IEnumerable<FieldDto> Fields { get; set; }
    }
}