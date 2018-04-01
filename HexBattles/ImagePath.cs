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

        // Number of soldiers
        const string One = "1";
        const string Two = "2";
        const string Three = "3";
        const string Four = "4";
        const string Five = "5";
        const string Six = "6";
        const string Seven = "7";
        const string Eight = "8";
        const string Nine = "9";

        // Dice
        const string DOne = "dice1";
        const string DTwo = "dice2";
        const string DThree = "dice3";
        const string DFour = "dice4";
        const string DFive = "dice5";
        const string DSix = "dice6";

        // Dice Location
        public static string GetDicePic(int index)
        {
            switch (index)
            {
                case (1):
                    return BeginStr + DOne + End_Str;
                case (2):
                    return BeginStr + DTwo + End_Str;
                case (3):
                    return BeginStr + DThree + End_Str;
                case (4):
                    return BeginStr + DFour + End_Str;
                case (5):
                    return BeginStr + DFive + End_Str;
                case (6):
                    return BeginStr + DSix + End_Str;
            }
            return null;
        }

        // Soldier number location
        public static string GetSoldierNum(int index)
        {
            switch (index)
            {
                case (1):
                    return BeginStr + One + End_Str;
                case (2):
                    return BeginStr + Two + End_Str;
                case (3):
                    return BeginStr + Three + End_Str;
                case (4):
                    return BeginStr + Four + End_Str;
                case (5):
                    return BeginStr + Five + End_Str;
                case (6):
                    return BeginStr + Six + End_Str;
                case (7):
                    return BeginStr + Seven + End_Str;
                case (8):
                    return BeginStr + Eight + End_Str;
                case (9):
                    return BeginStr + Nine + End_Str;
            }
            return null;
        }

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
