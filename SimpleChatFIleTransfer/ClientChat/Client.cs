using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientChat
{
    public class Client
    {
        #region Private Member Variables

        private TcpClient _socket;
        private bool _threadFlag;

        #endregion Private Member Variables

        #region Private Methods

        private Action<byte[]> InnerRefresh;

        private void InnerClientThreading()
        {
            while ( _threadFlag )
            {
                InnerReceive( _socket.GetStream() );
            }
        }

        private void InnerReceive(Stream reader)
        {
            MethodBase methodBase = MethodBase.GetCurrentMethod();
            byte[] receiveResult = null;

            try
            {
                int total = 0;
                // Header 길이 할당 필요 ( 16 자리에 )
                int sizeToRead = 16;
                byte[] headerBuffer = new byte[ sizeToRead ];
                bool isDoneHeaderParsing = true;

                while ( sizeToRead > 0 )
                {
                    byte[] buffer = new byte[ sizeToRead ];
                    int recv = reader.Read( buffer, 0, sizeToRead );

                    if(recv == 0)
                    {
                        receiveResult = null;
                        isDoneHeaderParsing = false;
                        break;
                    }
                    else
                    {
                        buffer.CopyTo( headerBuffer, total );
                        total += recv;
                        sizeToRead -= recv;
                    }
                }

                if ( !isDoneHeaderParsing )
                {
                    receiveResult = null;
                }
                else
                {
                    total = 0;
                    // Body Length 필요 ( 1024 자리에 )
                    byte[] bodyBuffer = new byte[ 1024 ];
                    sizeToRead = (int)1024;
                    bool isDoneBodyParsing = true;

                    while ( sizeToRead > 0 )
                    {
                        byte[] buffer = new byte[ sizeToRead ];
                        int recv = reader.Read( buffer, 0, sizeToRead );

                        if ( recv == 0 )
                        {
                            receiveResult = null;
                            isDoneBodyParsing = false;
                            break;
                        }
                        else
                        {
                            buffer.CopyTo( bodyBuffer, total );
                            total += recv;
                            sizeToRead -= recv;
                        }
                    }

                    if(!isDoneBodyParsing)
                    {
                        receiveResult = null;
                    }
                    else
                    {
                        // header ID에 따른 body 처리
                    }
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine(
                    methodBase.ReflectedType + "." + methodBase.Name + " -> " +
                    "System Exception: " + ex.Message );
            }
        }

        #endregion Private Methods

        #region Constructors

        public Client()
        {
            _threadFlag = false;
        }

        public Client(TcpClient socket) : this()
        {
            if ( socket == null )
            {
                _socket = null;
            }
            else
            {
                _socket = socket;
            }
        }

        #endregion Constructors

        #region Public Properties

        public TcpClient Socket
        {
            get => _socket;
            set => _socket = value;
        }

        #endregion Public Properties

        #region Public Methods

        public bool Start()
        {
            bool startResult = false;

            _threadFlag = true;
            Thread threading = new Thread( new ThreadStart( InnerClientThreading ) );
            threading.IsBackground = true;
            threading.Start();

            return startResult;
        }

        public void Close()
        {
            _threadFlag = false;

            if ( _socket != null )
            {
                _socket.Close();
            }
        }

        #endregion Public Methods
    }
}
