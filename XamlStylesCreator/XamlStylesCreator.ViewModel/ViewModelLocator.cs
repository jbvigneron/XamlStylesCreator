using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using XamlStylesCreator.ViewModel.Interfaces;

namespace XamlStylesCreator.ViewModel
{
    public class ViewModelLocator
    {
        #region Constructor

        /// <summary>
        /// Static constructor
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        #endregion

        #region ViewModels

        /// <summary>
        /// Get the main view-model
        /// </summary>
        public static IMainViewModel MainVM
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<IMainViewModel>())
                {
                    SimpleIoc.Default.Register<IMainViewModel, MainViewModel>();
                }

                return ServiceLocator.Current.GetInstance<IMainViewModel>();
            }
        }

        #endregion

        #region Clean methods

        /// <summary>
        /// Clean a referenced view-model
        /// </summary>
        /// <typeparam name="TInterface">Referenced view-model</typeparam>
        private static void ClearViewModel<TInterface>()
        {
            if (SimpleIoc.Default.IsRegistered<TInterface>())
            {
                IMyViewModelBase viewModel = (IMyViewModelBase)SimpleIoc.Default.GetInstance<TInterface>();
                viewModel.Cleanup();
                SimpleIoc.Default.Unregister(viewModel);
            }
        }

        /// <summary>
        /// Clean the main view-model
        /// </summary>
        public static void CleanMain()
        {
            ClearViewModel<IMainViewModel>();
        }

        #endregion
    }
}