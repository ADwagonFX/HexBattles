using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HexBattles
{
    class AlphaBetaBoard : HexBoard
    {
        public HexBoard Parent { get; set; }

        public AlphaBetaBoard(HexBoard board) : base()
        {
            this.Parent = board;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var parentPlot = this.Parent.GetHexBoard()[i, j];
                    this.Hex_Board[i, j] = new Plot(parentPlot.Hex, parentPlot.Player, parentPlot.Player_Count);
                }
            }
        }
    }
}
