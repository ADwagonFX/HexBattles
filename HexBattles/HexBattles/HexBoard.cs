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
        private static Plot[,] Hex_Board;

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
                    Hex_Board[i, j] = new Plot(Empty, Player_0);
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
                }
                else
                {
                    for (int j = 8; j > 1 + pull; j--)
                    {
                        Hex_Board[i, j].Hex = Percentage(rnd.Next(1, 101));
                    }
                }
            }
            Hex_Board[4, 0].Player = Player_1;
            Hex_Board[4, 8].Player = Player_2;
        }

        // Random Map Generator
        public static int Percentage(int rnd)
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
        public static Plot[,] GetHexBoard()
        {
            return Hex_Board;
        }
    }
}
