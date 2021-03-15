using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsClassLib
{
    public class Message
    {
        public MessageType mesType { get; set; }
        public int column { get; set; }
        public int row { get; set; }
        public int shipSize { get; set; }
        public bool isVertical { get; set; }
        public Message() { }

        public void setValues(MessageType MESTYPE, int ROW, int COLUMN, int SHIPSIZE, bool ISVERTICAL)
        {
            this.mesType = MESTYPE;
            this.row = ROW;
            this.column = COLUMN;
            this.shipSize = SHIPSIZE;
            this.isVertical = ISVERTICAL;
        }
    }
}
