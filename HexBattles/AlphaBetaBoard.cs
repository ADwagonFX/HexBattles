using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class AlphaBetaBoard : HexBoard
    {
        public Plot[,] AlphabetaBoard;
        public HexBoard Parent { get; set; }

        public AlphaBetaBoard(HexBoard board) : base()
        {
            AlphabetaBoard = new Plot[9, 9];
            this.Parent = board;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    AlphabetaBoard[i, j] = new Plot(this.Parent.GetHexBoard()[i, j].Hex, this.Parent.GetHexBoard()[i, j].Player, this.Parent.GetHexBoard()[i, j].Player_Count);
                }
            }
        }
        public AlphaBetaBoard(AlphaBetaBoard alphaBoard)
        {
            this.Parent = alphaBoard;
            AlphabetaBoard = new Plot[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    AlphabetaBoard[i, j] = new Plot(this.Parent.GetHexBoard()[i, j].Hex, this.Parent.GetHexBoard()[i, j].Player, this.Parent.GetHexBoard()[i, j].Player_Count);
                }
            }
        }
        //public void CopyBoardData()
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int j = 0; j < 9; j++)
        //        {
        //            if(this.Parent.GetHexBoard()[i, j].Hex == null)
        //            {

        //            }
        //            this.AlphabetaBoard[i, j].Hex = this.Parent.GetHexBoard()[i, j].Hex;
        //            this.AlphabetaBoard[i, j].Player = this.Parent.GetHexBoard()[i, j].Player;
        //            this.AlphabetaBoard[i, j].Player_Count = this.Parent.GetHexBoard()[i, j].Player_Count;
        //        }
        //    }
        //}
    }
}
