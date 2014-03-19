using System;
using XamlStylesCreator.ViewModel.Resources;

namespace XamlStylesCreator.ViewModel.Exceptions
{
    /// <summary>
    /// An exception which is raised when the user wants to parse a empty string
    /// </summary>
    class StringEmptyException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StringEmptyException()
            : base(AppRessources.StringEmpty)
        {
            
        }
    }
}