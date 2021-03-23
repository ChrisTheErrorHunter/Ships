using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsClassLib
{
        public enum MessageType
        {
            nulll,
            connected,
            disconnected,
            hitrequest,
            response,
            missedresponse,
            ready,
            responsesunk
        }
}
