using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace HexBattles
{
    public partial class HexBattles : Form
    {
        ArrayList[,] Piclist; // Array list containing the pictures
        HexBoard Hex_board; // Game board
        PictureBoxHex[,] playerpiclist;
        public HexBattles()
        {
            Hex_board = new HexBoard();
            InitializeComponent();
        }

        private void DrawBoard()
        {
            playerpiclist = new PictureBoxHex[9, 9];
            Piclist = new ArrayList[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    playerpiclist[i, j] = new PictureBoxHex(i, j);
                    this.Controls.Add(playerpiclist[i, j]);
                }
            }
        }
        private void HexBattles_Load(object sender, EventArgs e)
        {

        }
    }
}
