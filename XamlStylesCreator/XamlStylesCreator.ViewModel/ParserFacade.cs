using System.Text;
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
            StringBuilder builder = new StringBuilder();
            builder.Append("<Document xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" ");
            builder.Append("xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\" ");
            builder.Append("xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" ");
            builder.Append("mc:Ignorable=\"d\">");
            builder.Append(originalXaml);
            builder.Append("</Document>");

            string definitiveXaml = builder.ToString();

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