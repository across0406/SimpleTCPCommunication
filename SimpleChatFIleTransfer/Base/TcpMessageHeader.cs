using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class TcpMessageHeader
    {
        #region Constants

        private const uint _HEADER_LENGTH = 9;

        #endregion Constants

        #region Private Member Variables

        private ETcpMessageID _id;
        private uint _length;

        #endregion Private Member Variables

        #region Private Methods



        #endregion Private Methods

        #region Constructors



        #endregion Constructors

        #region Public Properties

        public ETcpMessageID ID
        {
            get => _id;
            set => _id = value;
        }

        public uint Length
        {
            get => _length;
            set => _length = value;
        }

        #endregion Public Properties

        #region Public Methods

        public byte[] GetBytes()
        {
            byte[] byteHeader = new byte[ _HEADER_LENGTH ];

            return byteHeader;
        }

        #endregion Public Methods
    }
}
