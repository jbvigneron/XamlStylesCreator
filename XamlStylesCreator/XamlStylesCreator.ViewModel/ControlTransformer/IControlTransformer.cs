using System.Xml;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.ViewModel.ControlTransformer
{
    interface IControlTransformer
    {
        IXamlStyle Serialize(XmlNode control);
    }
}