namespace ClassLibrarySample.Models.Subfolder
{
    public class ComplexType
    {
        public string AnotherProperty { get; set; }
        public Model2 Model2 { get; set; } = new Model2();
    }
}
