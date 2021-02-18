using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Ship
    {
        int size = 0;
        int hits = 0;
        public Ship() { }

        public Ship(int insize)
        {
            this.size = insize;
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
    }
}
