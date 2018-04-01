using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class Plot
    {
        public int Hex { get; set; } // The value of the background 
        public int Player { get; set; } // The value of the player

        // builds a plot with 
        public Plot(int hex, int Player)
        {
            this.Hex = hex;
            this.Player = Player;
        }
    }
}
