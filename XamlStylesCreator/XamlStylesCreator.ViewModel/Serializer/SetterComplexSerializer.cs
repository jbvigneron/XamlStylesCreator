using System;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.ViewModel.Serializer
{
    class SetterComplexSerializer : SetterSerializer
    {
        public override string SerializeSetter(IXamlSetter setter)
        {
            return string.Format(">{0}\t\t<Setter.Value>{0}\t\t\t{1}{0}\t\t</Setter.Value>{0}\t</Setter>", Environment.NewLine, setter.Value);
        }
    }
}