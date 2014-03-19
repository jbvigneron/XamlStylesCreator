using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.Model.Classes
{
    /// <summary>
    /// Represents a simple generated XAML setter (One value only)
    /// </summary>
    class XamlSetterSimple : XamlSetter, IXamlSetterSimple
    {
        public override string ToString()
        {
            return string.Format("{0} = {1}", Property, Value);
        }
    }
}