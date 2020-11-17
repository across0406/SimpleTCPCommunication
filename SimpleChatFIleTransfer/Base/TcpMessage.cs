using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class TcpMessage
    {
        #region Private Member Variables

        private TcpMessageHeader _header;

        #endregion Private Member Variables

        #region Private Methods

        private void InnerInitialize()
        {
            
        }

        private void InnerInitialize(byte[] byteMessage)
        {
            if ( byteMessage == null )
            {
                throw new Exception( "The input bytes are null." );
            }
            else
            {
                
            }
        }

        #endregion Private Methods

        #region Constructors

        public TcpMessage()
        {
            InnerInitialize();
        }

        public TcpMessage( byte[] byteMessage )
        {
            if ( byteMessage == null )
            {
                InnerInitialize();
            }
            else
            {
                InnerInitialize( byteMessage );
            }
        }

        #endregion Constructors

        #region Public Properties

        public TcpMessageHeader Header
        {
            get => _header;
            set => _header = value;
        }

        #endregion Public Properties

        #region Public Methods

        public byte[] GetBytes()
        {
            byte[] byteHeader = Header.GetBytes();
            byte[] byteBody = new byte[ 1 ];
            byte[] byteMessage = new byte[ byteHeader.Length + byteBody.Length ];

            Array.Copy( byteHeader, 0, byteMessage, 0, byteHeader.Length );
            Array.Copy( byteBody, 0, byteMessage, byteHeader.Length, byteBody.Length );

            return byteMessage;
        }

        #endregion Public Methods
    }
}
