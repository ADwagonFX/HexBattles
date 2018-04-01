using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HexBattles
{
    class PictureBoxPlayer : PictureBox
    {
        public int Row { get; private set; } // The row value of the image
        public int Column { get; private set; } // The column value of an image
        static public PictureBoxPlayer PlayerSave { get; set; } = null; // Used to save the properties of the first click

        // Creates the picture
        public PictureBoxPlayer(int Player_I, int Player_J, HexBoard board)
        {
            this.Row = Player_I;
            this.Column = Player_J;
            this.BringImage(board.GetHexBoard()[Player_I, Player_J].Player);
            this.Size = new System.Drawing.Size(60, 60);
        }

        // Brings the location of the picture and places it in a bitmap
        public void BringImage(int index)
        {
            string image = ImagePath.getimage(index);
            this.BackColor = Color.Transparent;
            if (image != null)
            {
                Image im = Image.FromFile(image);
                this.Image = new Bitmap(im, 60, 60);
                this.BringToFront();
            }
        }


        // Removes an image
        public void RemoveImage()
        {
            this.Image = null;
        }

        // Adds an image using a player number
        public void AddPlayerImage(int player)
        {
            BringImage(player);
        }
    }
}
