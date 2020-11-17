using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerChat;

namespace SimpleChatFIleTransfer
{
    public class ServerViewModel : Base.BasePropertyChanged
    {
        #region Private Member Variables

        private ServerChat.Server _model;

        #endregion Private Member Variables

        #region Private Methods



        #endregion Private Methods

        #region Constructors



        #endregion Constructors

        #region Public Properties

        public Server Model
        {
            get => _model;
            set => _model = value;
        }

        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods
    }
}
