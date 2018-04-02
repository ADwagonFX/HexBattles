using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    // class is used to move the player and save the indexes
    class Location
    {
        public int x;
        public int y;

        public Location(int i, int j)
        {
            this.x = j;
            this.y = i;
        }

    }
}
