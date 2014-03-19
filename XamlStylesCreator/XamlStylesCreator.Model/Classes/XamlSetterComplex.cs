using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.Model.Classes
{
    /// <summary>
    /// Represents a generated complex XAML setter (Re
    /// </summary>
    class XamlSetterComplex : XamlSetter, IXamlSetterComplex
    {
        public override string ToString()
        {
            return Property + " = {ComplexValue}";
        }
    }
}