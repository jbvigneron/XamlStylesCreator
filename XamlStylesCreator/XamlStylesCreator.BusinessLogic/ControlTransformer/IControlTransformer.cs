using System.Xml;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.BusinessLogic.ControlTransformer
{
    interface IControlTransformer
    {
        IXamlStyle Serialize(XmlNode control);
    }
}