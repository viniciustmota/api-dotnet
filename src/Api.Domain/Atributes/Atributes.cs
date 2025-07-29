using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Atributes
{
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
}