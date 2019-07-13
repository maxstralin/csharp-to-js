using ClassLibrarySample.Models.ExcludeMe;

namespace ClassLibrarySample.Models
{
    public class Model2
    {
        public Excluded IReferenceExcludedModel { get; set; } = new Excluded();
        public Excluded IReferenceExcludedModelButAmNull { get; set; } = null;
    }
}
