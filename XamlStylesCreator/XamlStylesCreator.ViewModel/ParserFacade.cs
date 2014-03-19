using System.Xml;
using XamlStylesCreator.Model.Interfaces;
using XamlStylesCreator.ViewModel.ControlTransformer;
using XamlStylesCreator.ViewModel.Serializer;

namespace XamlStylesCreator.ViewModel
{
    /// <summary>
    /// Facade which analyse all controls and transform them into XAML styles
    /// </summary>
    class ParserFacade
    {
        public string Parse(string originalXaml)
        {
            // Initialize a XML document
            string definitiveXaml = string.Format("<Document xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">{0}</Document>", originalXaml);

            // Create the XML document
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(definitiveXaml);

            // Result string
            string output = string.Empty;

            // For each control, transform it into a XAML style
            foreach (XmlNode control in xmlDocument.ChildNodes[0].ChildNodes)
            {
                IControlTransformer deserializer = new NodesTransformer();
                IXamlStyle style = deserializer.Serialize(control);

                StyleSerializer serializer = new StyleSerializer();
                output += serializer.Serialize(style);
            }

            return output;
        }
    }
}