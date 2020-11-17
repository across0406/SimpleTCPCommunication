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
using System.Windows.Shapes;

namespace SimpleChatFIleTransfer
{
    /// <summary>
    /// ClientView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClientWindow : Window
    {
        #region Private Member Variables

        private ClientViewModel _viewModel;

        #endregion Private Member Variables

        #region Private Methods

        private void ClientWindowClosed( object sender, EventArgs e )
        {
            if (_viewModel == null)
            {

            }
            else
            {
                _viewModel.CloseModel();
            }
        }

        #endregion Private Methods

        #region Constructors

        public ClientWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Public Properties

        public ClientViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;

                if(_viewModel != null)
                {
                    this.DataContext = _viewModel;
                }
            }
        }

        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods
    }
}
