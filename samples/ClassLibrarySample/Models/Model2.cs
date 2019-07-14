using ClassLibrarySample.Models.ExcludeMe;

namespace ClassLibrarySample.Models
{
    public class Model2
    {
        /// <summary>
        /// This type is excluded but instantiated, it'll be serialised
        /// </summary>
        public Excluded IReferenceExcludedModel { get; set; } = new Excluded();
        /// <summary>
        /// This is null so it'll be instantiated as null
        /// </summary>
        public Excluded IReferenceExcludedModelButAmNull { get; set; } = null;

        /// <summary>
        /// Generic classes will be serialised, could possibly be improved with https://github.com/maxstralin/csharp-to-js/issues/1
        /// </summary>
        public GenericType<string> AGenericTypeProperty { get; set; } = new GenericType<string>();

    }
}
