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
        // Creates the picture
        public PictureBoxPlayer(int Player_I, int Player_J)
        {
            this.BringImage(HexBoard.GetHexBoard()[Player_I, Player_J].Player);
            this.Size = new System.Drawing.Size(70, 70);
        }

        // Brings the location of the picture and places it in a bitmap
        public void BringImage(int index)
        {
            string image = ImagePath.getimage(index);
            if (image != null)
            {
                Image im = Image.FromFile(image);
                this.Image = new Bitmap(im, 60, 60);
                this.BackColor = Color.Transparent;
            }
            else
            {
                this.Image = null;
                this.BackColor = Color.Transparent;
            }
        }
    }
}
