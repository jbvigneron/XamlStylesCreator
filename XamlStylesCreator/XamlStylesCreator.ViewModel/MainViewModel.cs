using GalaSoft.MvvmLight.Command;
using ICSharpCode.AvalonEdit.Document;
using System.Windows.Input;
using XamlStylesCreator.BusinessLogic;
using XamlStylesCreator.ViewModel.Exceptions;
using XamlStylesCreator.ViewModel.Interfaces;

namespace XamlStylesCreator.ViewModel
{
    /// <summary>
    /// View-model for main page
    /// </summary>
    class MainViewModel : MyViewModelBase, IMainViewModel
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            ParseCommand = new RelayCommand(Parse);
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Input string with all controls to parse
        /// </summary>
        private TextDocument _input = new TextDocument();

        /// <summary>
        /// Result string with generated styles
        /// </summary>
        private TextDocument _output = new TextDocument();

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the input string which contains all controls to parse
        /// </summary>
        public TextDocument Input
        {
            get { return _input; }
            set
            {
                _input = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Get or set the result string which contains all generated styles
        /// </summary>
        public TextDocument Output
        {
            get { return _output; }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Parse command
        /// </summary>
        public ICommand ParseCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Parse the input string into styles
        /// </summary>
        public void Parse()
        {
            if (string.IsNullOrWhiteSpace(_input.Text))
            {
                MessengerInstance.Send(new StringEmptyException());
            }
            else
            {
                ParserFacade parser = new ParserFacade();

                try
                {
                    Output.Text = parser.Parse(_input.Text);
                }
                catch
                {
                    MessengerInstance.Send(new FormatErrorException());
                }
            }
        }

        #endregion
    }
}