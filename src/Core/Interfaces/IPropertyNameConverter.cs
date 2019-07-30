using System.Reflection;

namespace CSharpToJs.Core.Interfaces
{
    /// <summary>
    /// Convert a property name into a string
    /// </summary>
    public interface IPropertyNameConverter
    {
        /// <summary>
        /// Takes <see cref="PropertyInfo"/> and converts into a string property name
        /// </summary>
        /// <param name="propertyInfo">Reflected <see cref="PropertyInfo"/></param>
        /// <returns>Property name as a string</returns>
        string GetPropertyName(PropertyInfo propertyInfo);
    }
}