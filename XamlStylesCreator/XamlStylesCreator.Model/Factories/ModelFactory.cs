using XamlStylesCreator.Model.Classes;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.Model.Factories
{
    /// <summary>
    /// Model factory
    /// </summary>
    public static class ModelFactory
    {
        /// <summary>
        /// Create a new XAML style
        /// </summary>
        public static IXamlStyle CreateStyle()
        {
            return new XamlStyle();
        }

        /// <summary>
        /// Create a new XAML simple setter
        /// </summary>
        public static IXamlSetterSimple CreateSetterSimple()
        {
            return new XamlSetterSimple();
        }

        /// <summary>
        /// Create a new XAML complex setter
        /// </summary>
        /// <returns></returns>
        public static IXamlSetterComplex CreateSetterComplex()
        {
            return new XamlSetterComplex();
        }
    }
}