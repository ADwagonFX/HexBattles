using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HexBattles
{
    class PictureBoxNumber : PictureBox
    {
        // creates he picture
        public PictureBoxNumber(int i, int j, HexBoard board)
        {
            this.BringImage( board.GetHexBoard()[i,j].Player_Count);
            this.Size = new System.Drawing.Size(20, 20);
        }

        // Brings the Image location
        public void BringImage(int index)
        {
            string image = ImagePath.GetSoldierNum(index);
            this.BackColor = Color.Transparent;
            if (image != null)
            {
                Image im = Image.FromFile(image);
                this.Image = new Bitmap(im, 20, 20);
            }
        }

        // Removes the image
        public void RemoveImage()
        {
            this.Image = null;
        }

        // Adds an image using an index
        public void AddNumImage(int num)
        {
            BringImage(num);
        }
    }
}
