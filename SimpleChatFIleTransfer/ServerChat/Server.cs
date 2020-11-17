using Base;
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

namespace ServerChat
{
    public class Server
    {
        #region Private Member Variables

        private TcpListener _listener;
        private Dictionary<ClientChat.Client, string> _clients;

        private object _lockObject;

        #endregion Private Member Variables

        #region Private Methods

        private Action<string> InnerDisplayText;

        private void InnerInitSocket()
        {
            MethodBase methodBase = MethodBase.GetCurrentMethod();
            _listener = new TcpListener( IPAddress.Any, 9999 );
            _clients = new Dictionary<ClientChat.Client, string>();
            _listener.Start();

            while(true)
            {
                try
                {
                    TcpClient clientSocket = _listener.AcceptTcpClient();

                    if (_clients == null)
                    {
                        break;
                    }
                    else
                    {
                        ClientChat.Client client = new ClientChat.Client( clientSocket );
                        byte[] connectData = Receive( clientSocket.GetStream() );

                        // connectData로부터 유저네임 받아야함.
                        string userName = string.Empty;

                        _clients.Add( client, userName );

                        // User 입장 메시지 정의 및 송신
                        TcpMessage joinMessage = new TcpMessage();
                        SendChatAll( joinMessage );

                        // User List Refresh용 메시지 정의 및 송신
                        TcpMessage listRefreshMessage = new TcpMessage();
                        SendChatAll( listRefreshMessage );

                        client.Start();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(
                        methodBase.ReflectedType + "." + methodBase.Name + " -> " +
                        "System Exception: " + ex.Message );
                }
            }
        }

        private void ReceiveThread( TcpClient socket )
        {
            while ( true )
            {
                byte[] packet = Receive( socket.GetStream() );
            }
        }

        private byte[] Receive( Stream reader )
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

                    if ( recv == 0 )
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

                    if ( !isDoneBodyParsing )
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

                receiveResult = null;
            }

            return receiveResult;
        }

        private void SendChatAll( TcpMessage message ) // 전체 메세지
        {
            try
            {
                foreach ( var pair in _clients )
                {
                    NetworkStream stream = pair.Key.Socket.GetStream();
                    byte[] messageBytes = message.GetBytes();
                    stream.Write( messageBytes, 0, messageBytes.Length );
                    stream.Flush();
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.ToString() );
            }
        }

        #endregion Private Methods

        #region Constructors

        public Server()
        {
            _clients = new Dictionary<ClientChat.Client, string>();

            Thread initThread = new Thread( new ThreadStart( InnerInitSocket ) );
            initThread.IsBackground = true;
            initThread.Start();
        }

        #endregion Constructors

        #region Public Properties



        #endregion Public Properties

        #region Public Methods

        public Action<string> DisplayText
        {
            get => InnerDisplayText;
            set => InnerDisplayText = value;
        }

        #endregion Public Methods
    }
}
