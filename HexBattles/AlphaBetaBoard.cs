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


            //for (int i = 0; i < 9; i++)
            //{
            //    if (i < 5)
            //    {
            //        for (int j = 0; j <= 4 + this.push; j++)
            //        {
            //            var parentPlot = this.Parent.GetHexBoard()[i, j];
            //            this.Hex_Board[i, j] = new Plot(parentPlot.Hex, parentPlot.Player, parentPlot.Player_Count);
            //        }
            //        this.push++;
            //    }
            //    else
            //    {
            //        for (int j = 8; j > 1 + pull; j--)
            //        {
            //            this.Hex_Board[i, j] = new Plot(this.Parent.GetHexBoard()[i, j].Hex, this.Parent.GetHexBoard()[i, j].Player, this.Parent.GetHexBoard()[i, j].Player_Count);
            //        }
            //        this.pull++;
            //    }
            //}
        }
        //public AlphaBetaBoard(AlphaBetaBoard alphaBoard)
        //{
        //    this.Parent = alphaBoard;
        //    this.Hex_Board = new Plot[9, 9];
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (i < 5)
        //        {
        //            for (int j = 0; j <= 4 + this.push; j++)
        //            {
        //                this.Hex_Board[i, j] = new Plot(this.Parent.GetHexBoard()[i, j].Hex, this.Parent.GetHexBoard()[i, j].Player, this.Parent.GetHexBoard()[i, j].Player_Count);
        //            }
        //            this.push++;
        //        }
        //        else
        //        {
        //            for (int j = 8; j > 1 + pull; j--)
        //            {
        //                this.Hex_Board[i, j] = new Plot(this.Parent.GetHexBoard()[i, j].Hex, this.Parent.GetHexBoard()[i, j].Player, this.Parent.GetHexBoard()[i, j].Player_Count);
        //            }
        //            this.pull++;
        //        }
        //    }
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
       // }
    }
}
