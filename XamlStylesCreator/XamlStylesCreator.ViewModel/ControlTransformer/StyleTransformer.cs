using System.Xml;
using XamlStylesCreator.Model.Factories;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.ViewModel.ControlTransformer
{
    class StyleTransformer : IControlTransformer
    {
        public IXamlStyle Serialize(XmlNode control)
        {
            IXamlStyle style = ModelFactory.CreateStyle();
            style.TargetType = control.Name;

            return style;
        }
    }
}