using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientChat;

namespace SimpleChatFIleTransfer
{
    public class ClientViewModel : Base.BasePropertyChanged
    {
        #region Private Member Variables

        private Client _model;

        #endregion Private Member Variables

        #region Private Methods



        #endregion Private Methods

        #region Constructors



        #endregion Constructors

        #region Public Properties

        public Client Model
        {
            get => _model;
            set => _model = value;
        }

        #endregion Public Properties

        #region Public Methods

        public void CloseModel()
        {
            if(_model == null)
            {

            }
            else
            {
                _model.Close();
            }
        }

        #endregion Public Methods
    }
}
