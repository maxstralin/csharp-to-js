using System.Reflection;

namespace CSharpToJs.Core.Interfaces
{
    public interface IPropertyNameConverter
    {
        string GetPropertyName(PropertyInfo propertyInfo);
    }
}