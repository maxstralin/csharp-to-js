using ClassLibrarySample.Models.Subfolder;

namespace ClassLibrarySample.Models
{
    public class Model
    {
        public bool BoolProp { get; set; } = true;
        public string NullString { get; set; } = null;
        public ComplexType NulledComplexType { get; set; }
        public ComplexType ComplexType { get; } = new ComplexType();
    }
}
