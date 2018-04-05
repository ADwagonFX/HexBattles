using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class HexBoard
    {
        // Board Hexagons
        const int Empty = 0;
        const int Grass_Hex = 1;
        const int Special_Hex = 2;
        const int Bonus_Hex = 3;
        const int Water_Hex = 4;

        // Players
        const int Player_0 = 0;
        const int Player_1 = -1;
        const int Player_2 = -2;

        //Game Board
        public Plot[,] Hex_Board;

        // Game Board Builder
        public HexBoard()
        {
            Hex_Board = new Plot[9, 9];
            int push = 0, pull = -1;
            Random rnd = new Random();

            // temporary solution
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Hex_Board[i, j] = new Plot(Empty, Player_0, Empty);
                }
            }
            // temporary solution

            for (int i = 0; i < 9; i++)
            {
                if (i < 5)
                {
                    for (int j = 0; j <= 4 + push; j++)
                    {
                        Hex_Board[i, j].Hex = Percentage(rnd.Next(1, 101));
                    }
                    push++;
                }
                else
                {
                    for (int j = 8; j > 1 + pull; j--)
                    {
                        Hex_Board[i, j].Hex = Percentage(rnd.Next(1, 101));
                    }
                    pull++;
                }
            }
            Hex_Board[4, 0].Player = Player_1;
            Hex_Board[4, 0].Player_Count = 5;
            Hex_Board[4, 8].Player = Player_2;
            Hex_Board[4, 8].Player_Count = 5;
            Hex_Board[4, 8].Hex = 1;
            Hex_Board[4, 0].Hex = 1;

        }

        public Plot this[Location location]
        {
            get
            {
                return Hex_Board[location.x, location.y];
            }
        }

        // Random Map Generator
        public int Percentage(int rnd)
        {
            if (rnd <= 60)
                return Grass_Hex;
            if (rnd <= 80 && rnd > 60)
                return Special_Hex;
            if (rnd <= 85 && rnd > 80)
                return Bonus_Hex;
            else
                return Water_Hex;
        }

        // Returns the hexboard
        public Plot[,] GetHexBoard()
        {
            return Hex_Board;
        }

        // Checks if the move is legal
        public bool LegalMove(int locationI, int locationJ, int destI, int destJ)
        {
            var dest = this.Hex_Board[destI, destJ];
            var location = this.Hex_Board[locationI, locationJ];
            if (dest.Hex != 4 && dest.Hex != 0 && dest.Player != location.Player)
            {
                if (Math.Abs(locationI - destI) == 2)
                {
                    if (locationI > destI && locationJ - destJ == 1)
                        return true;
                    if (locationI < destI && destJ - locationJ == 1)
                        return true;
                }

                if(Math.Abs(locationI - destI) == 1)
                {
                    if (locationJ == destJ)
                        return true;
                    if ((locationI > destI && locationJ - destJ == 1) || (locationI < destI && locationJ - destJ == -1))
                        return true;
                }
            }

            PictureBoxPlayer.PlayerSave = null;
            return false;
        }

        // Checks if the board is in a state of end
        public bool WinCheck()
        {
            int Player1_Count = 0, Player2_Count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Hex_Board[i, j].Player == -1)
                        Player1_Count++;
                    if (Hex_Board[i, j].Player == -2)
                        Player2_Count++;
                }
                if (Player1_Count != 0 && Player2_Count != 0)
                    return false;
            }
            return true;
        }

        public void DoMove(Location from, Location to)
        {
            this.Hex_Board[to.x, to.y].Player = this.Hex_Board[from.x, from.y].Player;
            this.Hex_Board[to.x, to.y].Player_Count = this.Hex_Board[from.x, from.y].Player_Count - 1;
            this.Hex_Board[from.x, from.y].Player_Count = 1;
        }
    }
}
