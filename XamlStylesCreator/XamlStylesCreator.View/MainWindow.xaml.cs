using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using XamlStylesCreator.View.Ressources;

namespace XamlStylesCreator.View
{
    /// <summary>
    /// Page principale
    /// </summary>
    public partial class MainWindow
    {
        #region Constructor

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Track exceptions
            Messenger.Default.Register<Exception>(this, true, ShowExceptionMessage);
        }

        #endregion

        #region MVVM Light Messenger methods

        /// <summary>
        /// Raised when an exception occured. Show the error message to the user
        /// </summary>
        /// <param name="ex">Raised exception</param>
        private void ShowExceptionMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, AppRessources.Error, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}