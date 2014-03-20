using System;
using System.Xml;
using XamlStylesCreator.Model.Factories;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.BusinessLogic.ControlTransformer
{
    class NodesTransformer : IControlTransformer
    {
        private readonly IControlTransformer _next = new AttributesTransformer();

        public IXamlStyle Serialize(XmlNode control)
        {
            IXamlStyle style = _next.Serialize(control);

            foreach (XmlNode node in control.ChildNodes)
            {
                if (!node.Name.ToLowerInvariant().Contains(".name".ToLowerInvariant()))
                {
                    // Property
                    string property = node.Name.Substring(node.Name.IndexOf('.') + 1);

                    string value = null;

                    // Value
                    if (node.FirstChild != null)
                    {
                        string startSearchPattern = string.Format("<{0}", node.FirstChild.Name);
                        int indexStart = node.InnerXml.IndexOf(startSearchPattern, StringComparison.Ordinal);

                        value = node.InnerXml.Substring(indexStart);

                        string endSearchPattern = "xmlns";
                        int indexEnd = value.IndexOf(endSearchPattern, StringComparison.Ordinal);

                        if (indexEnd < 0)
                        {
                            endSearchPattern = "/>";
                            indexEnd = value.IndexOf(endSearchPattern, StringComparison.Ordinal);
                        }

                        value = value.Substring(0, (indexEnd - 1)) + " />";
                    }

                    IXamlSetter setter = ModelFactory.CreateSetterComplex();
                    setter.Property = property;
                    setter.Value = value;

                    style.Setters.Add(setter);
                }
                else
                {
                    int indexName = node.InnerXml.IndexOf('.') + 1;
                    string key = node.InnerXml.Substring(indexName);
                    style.Key = key;
                }
            }

            return style;
        }
    }
}