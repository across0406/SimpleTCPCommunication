using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleChatFIleTransfer
{
    public class MainViewModel : Base.BasePropertyChanged
    {
        #region Private Member Variables



        #endregion Private Member Variables

        #region Private Methods

        private void InnerOpenServerWindow()
        {
            var app = ( Application.Current as App );
            app.ServerView.Show();
        }

        private void InnerOpenClientWindow()
        {

        }

        #endregion Private Methods

        #region Constructors



        #endregion Constructors

        #region Public Properties



        #endregion Public Properties

        #region Public Methods

        public Action OpenServerWindow;
        public Action OpenClientWindow;

        #endregion Public Methods
    }
}
