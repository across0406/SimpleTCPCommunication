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
    /// ServerView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ServerWindow : Window
    {
        #region Private Member Variables

        private ServerViewModel _viewModel;

        #endregion Private Member Variables

        #region Private Methods

        private void ServerWindowClosing( object sender, System.ComponentModel.CancelEventArgs e )
        {
            e.Cancel = true;
            this.Hide();
        }

        #endregion Private Methods

        #region Constructors

        public ServerWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Public Properties

        public ServerViewModel ViewModel
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
