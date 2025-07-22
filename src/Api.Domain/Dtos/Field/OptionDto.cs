using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Field
{
    public class OptionDto
    {
        public string Label { get; set; }
        public Guid Value { get; set; }
    }
}