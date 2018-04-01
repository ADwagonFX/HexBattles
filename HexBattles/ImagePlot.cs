using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexBattles
{
    class ImagePlot
    {
        public PictureBoxHex HexPic { get; set; } // Holds the hexagon image
        public PictureBoxPlayer PlayerPic { get; set; } // Holds the player image
        public PictureBoxNumber NumPic { get; set; } // Holds the number of soldiers

        // Builds the imageplot with the images of the hex and the player
        public ImagePlot(PictureBoxHex hex, PictureBoxPlayer player, PictureBoxNumber Number)
        {
            this.HexPic = hex;
            this.PlayerPic = player;
            this.NumPic = Number;
        }
    }
}
