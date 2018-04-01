using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class ImagePath
    {
        // Beginning and ending of each picture
        const string BeginStr = "..\\..\\Images\\";
        const string End_Str = ".png";

        // Hexagon type
        const string Grass_hex = "Grass_Hex";
        const string Special_Hex = "Special_Hex";
        const string Bonus_Hex = "Bonus_Hex";
        const string Water_Hex = "Water_Hex";

        // Player type
        const string Player_1 = "Player_1";
        const string Player_2 = "Player_2";

        // Image location 
        public static string getimage(int index)
        {
            switch (index)
            {
                case (-2):
                    return BeginStr + Player_2 + End_Str;
                case (-1):
                    return BeginStr + Player_1 + End_Str;
                case (1):
                    return BeginStr + Grass_hex + End_Str;
                case (2):
                    return BeginStr + Special_Hex + End_Str;
                case (3):
                    return BeginStr + Bonus_Hex + End_Str;
                case (4):
                    return BeginStr + Water_Hex + End_Str;
            }
            return null;
        }
    }
}
