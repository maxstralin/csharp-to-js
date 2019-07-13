namespace CSharpToJs.Core.Models
{
    public class JsProperty
    {
        public JsPropertyType Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"this.{Name} = {Value}";
        }
    }
}
