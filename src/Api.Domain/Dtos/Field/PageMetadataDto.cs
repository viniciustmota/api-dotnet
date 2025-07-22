using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Field;

namespace Api.Domain.Dtos.Metadata
{
    public class MetadataDto
    {
        public int Version { get; set; }
        public string Title { get; set; }
        public IEnumerable<FieldDto> Fields { get; set; }
        public bool KeepFilters { get; set; }
    }
}