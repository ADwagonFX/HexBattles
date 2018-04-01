using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HexBattles
{
    class PictureBoxHex : PictureBox
    {
        public int Row { get; private set; } // The row value of the image
        public int Column { get; private set; } // The column value of an image

        // Array for board spacing
        private int[] d = { 104, 88, 75, 62, 49, 36, 23, 10, -6 };

        // Creates the picture
        public PictureBoxHex(int Hex_I, int Hex_J, HexBoard board)
        {
            this.Row = Hex_I;
            this.Column = Hex_J;
            int y = 10 + (35 * this.Row), x = (750 - this.Row * 35) + (70 * this.Column);
            x = x = (x - Hex_I * 35) + (55 * Hex_J) - d[Hex_J];

            this.BringImage(board.GetHexBoard()[Hex_I, Hex_J].Hex);
            this.Location = new System.Drawing.Point(x, y);
            this.Size = new System.Drawing.Size(70, 70);
        }

        // Brings the location of the picture and places it in a bitmap
        public void BringImage(int index)
        {
            string image = ImagePath.getimage(index);
            this.BackColor = Color.Transparent;
            if (image != null)
            {
                Image im = Image.FromFile(image);
                this.Image = new Bitmap(im, 70, 70);
            }
        }
        public void RemoveImage()
        {
            this.Image = null;
        }

    }
}
