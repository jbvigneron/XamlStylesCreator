using System.Collections.Generic;

namespace XamlStylesCreator.Model.Interfaces
{
    public interface IXamlStyle
    {
        string Key { get; set; }

        string TargetType { get; set; }

        IList<IXamlSetter> Setters { get; set; }
    }
}