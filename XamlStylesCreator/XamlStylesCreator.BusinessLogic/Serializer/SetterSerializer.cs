using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.ViewModel.Serializer
{
    abstract class SetterSerializer
    {
        public abstract string SerializeSetter(IXamlSetter setter);
    }
}