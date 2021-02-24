using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsClassLib
{
    public class MessageEncryptor
    {
        public MessageType mesType;
        public int row, column;
        public int shipSize;
        public bool isVertical;
        public MessageEncryptor() { }

        public void setValues(MessageType MESTYPE, int ROW, int COLUMN, int SHIPSIZE, bool ISVERTICAL)
        {
            this.mesType = MESTYPE;
            this.row = ROW;
            this.column = COLUMN;
            this.shipSize = SHIPSIZE;
            this.isVertical = ISVERTICAL;
        }

        public void Decrypt(byte[] cryptogram)
        {
            int tmp, message;
            message = BitConverter.ToInt32(cryptogram, 0);
            tmp = message % 10;
            message /= 10;
            if (tmp == 0) this.mesType = MessageType.nulll;
            else if (tmp == 1) this.mesType = MessageType.connected;
            else if (tmp == 2) this.mesType = MessageType.disconnected;
            else if (tmp == 3) this.mesType = MessageType.hitrequest;
            else if (tmp == 4) this.mesType = MessageType.response;
            else if (tmp == 5) this.mesType = MessageType.missedresponse;
            tmp = message % 10;
            message /= 10;
            this.column = tmp;
            tmp = message % 10;
            message /= 10;
            this.row = tmp;
            tmp = message % 10;
            message /= 10;
            if (message == 1) this.isVertical = true;
            else this.isVertical = false;
            tmp = message % 10;
            message /= 10;
            this.shipSize = tmp;
        }

        public byte[] Encrypt()
        {
            byte[] message = new byte[4];
            int wynik = 0;
            wynik += shipSize;
            wynik *= 10;
            if (isVertical) wynik++;
            wynik *= 10;
            wynik += row;
            wynik *= 10;
            wynik += column;
            if (mesType == MessageType.connected) wynik++;
            if (mesType == MessageType.disconnected) wynik += 2;
            if (mesType == MessageType.hitrequest) wynik += 3;
            if (mesType == MessageType.response) wynik += 4;
            if (mesType == MessageType.missedresponse) wynik += 5;
            message = BitConverter.GetBytes(wynik);
            return message;
        }

    }
}
