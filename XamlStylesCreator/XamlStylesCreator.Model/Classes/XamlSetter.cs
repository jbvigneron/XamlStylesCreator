using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.Model.Classes
{
    /// <summary>
    /// Represents a generated XAML setter
    /// </summary>
    abstract class XamlSetter : IXamlSetter
    {
        public string Property { get; set; }

        public string Value { get; set; }
    }
}