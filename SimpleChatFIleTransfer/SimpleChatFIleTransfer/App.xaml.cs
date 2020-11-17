using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClientChat;
using ServerChat;

namespace SimpleChatFIleTransfer
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        #region Private Member Variables

        private ServerChat.Server _serverManager;
        

        private MainViewModel _viewModelMain;
        private ServerViewModel _viewModelServer;
        private Dictionary<ClientChat.Client, ClientViewModel> _clientViewModelManager;

        private MainWindow _mainView;
        private ServerWindow _serverView;
        private Dictionary<ClientChat.Client, Window> _clientViewManager;

        #endregion Private Member Variables

        #region Private Methods

        private void ApplicationStartup( object sender, StartupEventArgs e )
        {
            if (_mainView == null)
            {
                OnExit( null );
            }
            else
            {
                MainView.Show();
            }
        }

        #endregion Private Methods

        #region Constructors

        public App()
        {
            ServerManager = new Server();

            ViewModelMain = new MainViewModel();
            ViewModelServer = new ServerViewModel();
            ClientViewModelManager = new Dictionary<Client, ClientViewModel>();

            MainView = new MainWindow();
            MainView.ViewModel = ViewModelMain;
            MainView.Hide();

            ServerView = new ServerWindow();
            ServerView.ViewModel = ViewModelServer;
            ServerView.Hide();

            ClientViewManager = new Dictionary<Client, Window>();
        }

        #endregion Constructors

        #region Public Properties


        public Server ServerManager
        {
            get => _serverManager;
            set => _serverManager = value;
        }

        public MainViewModel ViewModelMain
        {
            get => _viewModelMain;
            set => _viewModelMain = value;
        }

        public ServerViewModel ViewModelServer
        {
            get => _viewModelServer;
            set => _viewModelServer = value;
        }

        public Dictionary<Client, ClientViewModel> ClientViewModelManager
        {
            get => _clientViewModelManager;
            set => _clientViewModelManager = value;
        }

        public MainWindow MainView
        {
            get => _mainView;
            set => _mainView = value;
        }

        public ServerWindow ServerView
        {
            get => _serverView;
            set => _serverView = value;
        }

        public Dictionary<ClientChat.Client, Window> ClientViewManager
        {
            get => _clientViewManager;
            set => _clientViewManager = value;
        }

        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods
    }
}
