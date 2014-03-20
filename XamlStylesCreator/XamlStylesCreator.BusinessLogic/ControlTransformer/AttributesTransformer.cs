using System.Collections.Generic;
using System.Xml;
using XamlStylesCreator.Model.Factories;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.BusinessLogic.ControlTransformer
{
    class AttributesTransformer : IControlTransformer
    {
        private readonly IControlTransformer _next = new StyleTransformer();

        public IXamlStyle Serialize(XmlNode control)
        {
            IXamlStyle style = _next.Serialize(control);
            style.Setters = new List<IXamlSetter>();

            if (control.Attributes != null)
            {
                foreach (XmlAttribute attribute in control.Attributes)
                {
                    if (attribute.Name.ToLowerInvariant() != "name" && attribute.Name.ToLowerInvariant() != "x:name")
                    {
                        IXamlSetter setter = ModelFactory.CreateSetterSimple();
                        setter.Property = attribute.Name;
                        setter.Value = attribute.Value;

                        style.Setters.Add(setter);
                    }
                    else
                    {
                        style.Key = attribute.Value;
                    }
                }
            }

            return style;
        }
    }
}