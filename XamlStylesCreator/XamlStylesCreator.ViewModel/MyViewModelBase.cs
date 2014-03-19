using GalaSoft.MvvmLight;
using System.Runtime.CompilerServices;
using XamlStylesCreator.ViewModel.Interfaces;

namespace XamlStylesCreator.ViewModel
{
    /// <summary>
    /// Base class for all application's view-models
    /// </summary>
    class MyViewModelBase : ViewModelBase, IMyViewModelBase
    {
        protected new void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}