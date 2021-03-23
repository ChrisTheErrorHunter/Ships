using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsClassLib
{
    public class Ship
    {
        public int size = 0;
        public int hits = 0;
        public int row, column;
        public bool isVertical;
        public Ship() 
        {
            size = 0;
            hits = 0;
            row = -1;
            column = -1;
            isVertical = false;
        }

        public Ship(int insize)
        {
            this.size = insize;
        }

        public void SetSail(int ROW, int COLUMN, int SIZE, bool ISVERTICAL)
        {
            this.row = ROW;
            this.column = COLUMN;
            this.size = SIZE;
            this.isVertical = ISVERTICAL;
        }
        public void GotHit()
        {
            hits++;
        }
        public bool IsSunk()
        {
            if (hits >= size) return true;
            else return false;
        }

        public bool isHit(int inrow, int incolumn)
        {
            for(int i = 0; i < size; i++)
            {
                if (isVertical)
                {
                    if (row + i == inrow) return true;
                }
                else
                {
                    if (column + i == incolumn) return true;
                }
            }
            return false;
        }
    }
}
