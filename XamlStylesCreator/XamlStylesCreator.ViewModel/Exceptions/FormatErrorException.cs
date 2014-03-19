using System;
using XamlStylesCreator.ViewModel.Resources;

namespace XamlStylesCreator.ViewModel.Exceptions
{
    /// <summary>
    /// An exception which is raised when the user has written an incorrect XAML code
    /// </summary>
    class FormatErrorException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormatErrorException()
            : base(AppRessources.FormatError)
        {
            
        }
    }
}