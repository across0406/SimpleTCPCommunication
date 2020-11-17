using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public enum ETcpMessageID
    {
        JOIN = 0x01,
        SEND_CHAT_ALL = 0x02,
        WHISPER_CHAT = 0x03,
        SEND_TEXT = 0x03,
        SEND_IMAGE = 0x04,
    }
}
