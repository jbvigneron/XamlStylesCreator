using ICSharpCode.AvalonEdit.Document;
using System.Windows.Input;

namespace XamlStylesCreator.ViewModel.Interfaces
{
    /// <summary>
    /// Interface for the Main view-model
    /// </summary>
    public interface IMainViewModel : IMyViewModelBase
    {
        TextDocument Input { get; set; }
        TextDocument Output { get; }

        ICommand ParseCommand { get; }
    }
}