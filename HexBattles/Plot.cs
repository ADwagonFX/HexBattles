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
        public int Player_Count { get; set; } // Number Of Soldiers a plot contains

        // builds a plot with the values of hex and player
        public Plot(int hex, int Player, int Player_Count)
        {
            this.Hex = hex;
            this.Player = Player;
            this.Player_Count = Player_Count;
        }
    }
}
