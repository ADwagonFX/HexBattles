using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HexBattles
{
    class PictureBoxDice : PictureBox
    {
        // creates he picture
        public PictureBoxDice(int DNum, int Dvalue, int Player)
        {
            this.BringImage(Dvalue);
            this.Size = new System.Drawing.Size(50, 50);
        }

        // Brings the Image location
        public void BringImage(int index)
        {
            string image = ImagePath.GetDicePic(index);
            this.BackColor = Color.Transparent;
            if (image != null)
            {
                Image im = Image.FromFile(image);
                this.Image = new Bitmap(im, 50, 50);
            }
        }

        // Removes the image
        public void RemoveImage()
        {
            this.Image = null;
        }

        // Adds an image using an index
        public void AddDiceImage(int num)
        {
            BringImage(num);
        }
    }
}
