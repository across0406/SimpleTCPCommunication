using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleChatFIleTransfer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Member Variables

        private MainViewModel _viewModel;

        #endregion Private Member Variables

        #region Private Methods

        private void MainWindowClosed( object sender, EventArgs e )
        {
            var app = ( Application.Current as App );

            if (app.ClientViewManager != null)
            {
                foreach(var element in app.ClientViewManager)
                {
                    element.Value.Close();
                }
            }

            if ( app.ClientViewModelManager != null )
            {
                foreach ( var element in app.ClientViewModelManager )
                {
                    // element.Key.Close();
                }
            }
        }

        private void OpenServerButtonClick( object sender, RoutedEventArgs e )
        {
            if(_viewModel == null)
            {
                
            }
            else
            {
                _viewModel.
            }
        }

        private void OpenClientButtonClick( object sender, RoutedEventArgs e )
        {

        }

        #endregion Private Methods

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }


        #endregion Constructors

        #region  Public Properties

        public MainViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;

                if (_viewModel != null)
                {
                    this.DataContext = _viewModel;
                }
            }
        }

        #endregion Public Properties

        
    }
}
