using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Ship
    {
        int shipID = 0;
        int size = 0;
        int hits = 0;
        int row, column;
        bool isVertical;
        public Ship() { }

        public Ship(int insize, int inid)
        {
            this.size = insize;
            this.shipID = inid;
        }

        public void SetSail(int ROW, int COLUMN, bool ISVERTICAL)
        {
            this.row = ROW;
            this.column = COLUMN;
            this.isVertical = ISVERTICAL;
        }

        public bool IsThatYou(int ID)
        {
            if (ID == shipID) return true;
            else return false;
        }
        public void GotHit(int ID)
        {
            hits++;
        }
        public bool IsSunk()
        {
            if (hits >= size) return true;
            else return false;
        }
    }
}
