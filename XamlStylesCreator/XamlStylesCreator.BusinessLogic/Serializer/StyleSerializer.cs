using System;
using XamlStylesCreator.Model.Interfaces;
using XamlStylesCreator.ViewModel.Serializer;

namespace XamlStylesCreator.BusinessLogic.Serializer
{
    public class StyleSerializer
    {
        public string Serialize(IXamlStyle style)
        {
            string output = "<Style ";

            if (!string.IsNullOrWhiteSpace(style.Key))
            {
                output += string.Format("x:Key=\"{0}Style\" ", style.Key);
            }

            output += string.Format("TargetType=\"{0}\">", style.TargetType);

            foreach (IXamlSetter setter in style.Setters)
            {
                output += string.Format("{0}\t<Setter Property=\"{1}\"", Environment.NewLine, setter.Property);

                SetterSerializer setterSerializer = null;

                if (setter is IXamlSetterSimple)
                {
                    setterSerializer = new SetterSimpleSerializer();
                }
                else if (setter is IXamlSetterComplex)
                {
                    setterSerializer = new SetterComplexSerializer();
                }

                if (setterSerializer != null)
                {
                    output += setterSerializer.SerializeSetter(setter);
                }
            }

            output += string.Format("{0}</Style>{0}{0}", Environment.NewLine);

            return output;
        }
    }
}