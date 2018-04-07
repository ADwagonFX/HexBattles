using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class AlphaBeta
    {
        public Stack<Location> GetBestPath(
            HexBoard board,
            Location startLocation)
        {
            AlphaBetaBoard Clone = new AlphaBetaBoard(board);
            var bestPath = GetBestPath(Clone, startLocation, 0);
            return bestPath.Path;
        }

        private PossiblePath GetBestPath(AlphaBetaBoard board,
            Location startLocation,
            int depth)
        {
            Plot plot = board[startLocation];
            if (depth > 3 || plot.Player_Count == 1)
            {
                var path = new Stack<Location>();
                path.Push(startLocation);
                return new PossiblePath(plot.Hex, path);
            }

           // PossiblePath bestPath = null;
            var possibleMoves = PossibleMoves(startLocation.x, startLocation.y, board);
            if(possibleMoves.Count() != 0)
            {
                PossiblePath bestPath = null;
                foreach (var location in possibleMoves)
                {
                    AlphaBetaBoard cloneBoard = new AlphaBetaBoard(board);
                    if(cloneBoard.GetHexBoard()[location.x, location.y].Player != -1)
                    {
                        cloneBoard.GetHexBoard()[location.x, location.y].Player = -2;
                        cloneBoard.GetHexBoard()[location.x, location.y].Player_Count = cloneBoard.GetHexBoard()[startLocation.x, startLocation.y].Player_Count - 1;

                        PossiblePath tempPath = GetBestPath(cloneBoard, location, depth + 1);
                        tempPath.Value = board.GetHexBoard()[location.x, location.y].Hex;
                        bestPath = BestPossiblePath(tempPath, bestPath);
                    }
                    else
                    {
                        if (IsItWorthIt(startLocation, location, cloneBoard))
                        {
                            cloneBoard.GetHexBoard()[location.x, location.y].Player = -2;
                            cloneBoard.GetHexBoard()[location.x, location.y].Player_Count = cloneBoard.GetHexBoard()[startLocation.x, startLocation.y].Player_Count - 1; // in assamption that AI wins

                            PossiblePath tempPath = GetBestPath(cloneBoard, location, depth + 1);
                            tempPath.Value = board.GetHexBoard()[location.x, location.y].Hex;
                            bestPath = tempPath; // need to add new bestpossiblepath that calculates with its wirth to attack
                        }
                        else
                        {
                            var path = new Stack<Location>();
                            path.Push(startLocation);
                            return new PossiblePath(plot.Hex, path);
                        }
                    }
                }
                 
                bestPath.Path.Push(startLocation);
                bestPath.Value += plot.Hex;

                return bestPath;
            }
            else
            {
                var path = new Stack<Location>();
                path.Push(startLocation);
                return new PossiblePath(plot.Hex, path);
            }
        }

        private bool IsItWorthIt(Location from, Location to, HexBoard board)
        {
            int Player1 = board.GetHexBoard()[from.x, from.y].Player_Count;
            int player2 = board.GetHexBoard()[to.x, to.y].Player_Count;

            if (Player1 > player2)
                return true;
            else
                return false;
        }




        private PossiblePath BestPossiblePath(PossiblePath a, PossiblePath b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;
            if (a.Value > b.Value)
                return a;
            return b;
        }



        private class PossiblePath
        {
            public int Value { get; set; }
            public Stack<Location> Path { get; set; }

            public PossiblePath(int value, Stack<Location> path)
            {
                this.Value = value;
                this.Path = path;
            }
        }

        //    // Returns a list that contains all the moves that can be done from the npoint given
        public List<Location> PossibleMoves(int x, int y, AlphaBetaBoard Board)
        {
            List<Location> Peripherals = new List<Location>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(Board.LegalMove(x,y, i, j))
                    {
                        Peripherals.Add(new Location(i, j));
                    }

                }
            }
            return Peripherals;
        }
    }
}
