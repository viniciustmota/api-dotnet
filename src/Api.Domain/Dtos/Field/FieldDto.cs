namespace Api.Domain.Dtos.Field
{

    public class FieldDto
    {
        public string Property { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public List<OptionDto> Options { get; set; }
        public bool Editable { get; set; }
        public bool Visible { get; set; }
        public bool Key { get; set; }

    }
}