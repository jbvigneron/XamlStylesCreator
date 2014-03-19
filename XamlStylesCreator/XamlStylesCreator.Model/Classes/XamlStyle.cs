using System.Collections.Generic;
using XamlStylesCreator.Model.Interfaces;

namespace XamlStylesCreator.Model.Classes
{
    /// <summary>
    /// Represents a generated XAML style
    /// </summary>
    class XamlStyle : IXamlStyle
    {
        #region Properties

        /// <summary>
        /// Style name (not necessary)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Style target type (eg Button, TextBlock, ListBox...)
        /// </summary>
        public string TargetType { get; set; }

        /// <summary>
        /// List of setters
        /// </summary>
        public IList<IXamlSetter> Setters { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("Key = {0}, TargetType = {1}, Setters.Count = {2}", Key, TargetType, Setters.Count);
        }

        #endregion
    }
}