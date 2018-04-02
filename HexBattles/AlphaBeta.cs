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
            var bestPath = GetBestPath(new AlphaBetaBoard(board), startLocation, 0);
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
                return new PossiblePath(plot.Player_Count, path);
            }

            PossiblePath bestPath = null;
            var possibleMoves = PossibleMoves(startLocation.x, startLocation.y, board);
            foreach (var location in possibleMoves)
            {
                AlphaBetaBoard cloneBoard = new AlphaBetaBoard(board);
                //cloneBoard.CopyBoardData();
                cloneBoard.GetHexBoard()[location.x, location.y].Player = -2;
                cloneBoard.GetHexBoard()[location.x, location.y].Player_Count = cloneBoard.GetHexBoard()[startLocation.x, startLocation.y].Player_Count - 1;
                cloneBoard.GetHexBoard()[location.x, location.y].Player_Count = 1;

                PossiblePath tempPath = GetBestPath(cloneBoard, location, depth + 1);
                bestPath = BestPossiblePath(tempPath, bestPath);
            }
            bestPath.Path.Push(startLocation);
            bestPath.Value += plot.Player_Count;

            return bestPath;
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

        //    // Uses the a point and starts to build a move list from that point, gets the point from the do move function
        //    // point = starting point 
        //    public Stack<Location> MovesList(Location point, Stack<Location> moveslist, AlphaBetaBoard parent)
        //    {
        //        int max = 0;
        //        AlphaBetaBoard save;
        //        Stack<Location> DoMoveList = moveslist;
        //        List<Location>Peripherals = PossibleMoves(point.x, point.y, parent);
        //        if (parent.Depth > 3 || parent.ABB.GetHexBoard()[point.x, point.y].Player_Count == 1)
        //            return null;
        //        foreach (Location m in Peripherals) 
        //        {
        //            AlphaBetaBoard Child = new AlphaBetaBoard(parent);
        //            Child.Parent = parent;
        //            Child.Location = m;
        //            Child.ABB.GetHexBoard()[m.x, m.y].Player = -2;

        //            if (parent.GetHexBoard()[m.x, m.y].Hex == 2)
        //                Child.Points = 2;
        //            if (parent.GetHexBoard()[m.x, m.y].Hex == 1 )
        //                Child.Points = 1;

        //            ABMove(m, parent, point, Child);
        //            parent.Children.Add(Child);
        //            DoMoveList = MovesList(m, DoMoveList, Child);
        //            save = Child;
        //            foreach(AlphaBetaBoard child in parent.Children)
        //            {
        //                if(child.Points > max)
        //                {
        //                    max = child.Points;
        //                    save = child;
        //                }
        //                // add option when both child points are equal
        //            }
        //            DoMoveList.Push(save.Location);
        //            return DoMoveList;
        //        }
        //        return DoMoveList;
        //    }
        //    // Uses the MoveList function in order to obtain a list of moves for a specific
        //    // plot in the "for" loop. foreach player plot on the board it will mke a movelist
        //    public void DoMove(AlphaBetaBoard Board)
        //    {
        //        List<Location> MovesList = new List<Location>();
        //        for (int i = 0; i < 9; i++)
        //        {
        //            for (int j = 0; j < 9; j++)
        //            {
        //            }
        //        }
        //    }

        //    // Returns a list that contains all the moves that can be done from the npoint given
        public List<Location> PossibleMoves(int x, int y, AlphaBetaBoard Board)
        {
            List<Location> Peripherals = new List<Location>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Board.GetHexBoard()[i, j].Hex != 4 && Board.GetHexBoard()[i, j].Player != -2)
                    {
                        if (Math.Abs(y - i) == 1)
                            if (y == j || Math.Abs(j - y) == 1)
                            {
                                Location Point = new Location(i, j);
                                Peripherals.Add(Point);
                            }
                        if (Math.Abs(y - i) == 2 && Math.Abs(x - j) == 1)
                        {
                            Location Point = new Location(i, j);
                            Peripherals.Add(Point);
                        }
                    }
                }
            }
            return Peripherals;
        }

        //    public void ABMove(Location destination, AlphaBetaBoard board, Location location, AlphaBetaBoard child)
        //    {
        //        child.ABB.GetHexBoard()[destination.x, destination.y].Player_Count = board.ABB.GetHexBoard()[location.x, location.y].Player_Count - 1;
        //        child.ABB.GetHexBoard()[destination.x, destination.y].Player = -2;
        //        board.ABB.GetHexBoard()[location.x, location.y].Player_Count = 1;
        //    }

        //}
    }
}
