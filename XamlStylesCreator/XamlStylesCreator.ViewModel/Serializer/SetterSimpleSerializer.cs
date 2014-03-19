using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.ViewModel.Serializer
{
    class SetterSimpleSerializer : SetterSerializer
    {
        public override string SerializeSetter(IXamlSetter setter)
        {
            return string.Format(" Value=\"{0}\" />", setter.Value);
        }
    }
}