using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class AlphaBetaBoard : HexBoard
    {
        public HexBoard ABB { get; set; }
        public int Depth { get; set; }
        public int Points { get; set; }
        public Move Location { get; set; }
        public List<AlphaBetaBoard> Children;
        public AlphaBetaBoard Parent { get; set; }

        public AlphaBetaBoard(HexBoard board ) : base()
        {
            this.ABB = board;
            this.Points = 0;
            this.Depth = 1;
        }
        public AlphaBetaBoard(AlphaBetaBoard alphaBoard)
        {
            this.ABB = alphaBoard;
            this.Depth = alphaBoard.Depth + 1;
        }
    }
}
