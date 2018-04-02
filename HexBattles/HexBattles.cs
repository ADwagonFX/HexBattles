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
        public int Turn_Count = 1; // Counts the number of turns taken in a game
        private int Turn = -1; // Used to identifie turns
        HexBoard Hex_board; // Game board
        ImagePlot[,] PicPlot; // Picture Matrix
        PictureBoxDice[] Dice1Array, Dice2Array;
        public HexBattles()
        {
            Hex_board = new HexBoard();
            PicPlot = new ImagePlot[9, 9];
            InitializeComponent();
        }

        // Draws the board
        private void DrawBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var plot = new ImagePlot(i, j, this.Hex_board);
                    PicPlot[i, j] = plot;
                    this.Controls.Add(plot.HexPic);
                    plot.HexPic.Controls.Add(plot.PlayerPic);
                    plot.PlayerPic.Controls.Add(plot.NumPic);
                    plot.NumPic.Location = new Point(40, 40);
                    plot.PlayerPic.Click += new System.EventHandler(this.Player_Picture_Click);
                }
            }

            Dice1Array = new PictureBoxDice[10];
            Dice2Array = new PictureBoxDice[10];
            for (int o = 0; o < 10; o++)
            {
                Dice1Array[o] = new PictureBoxDice(0, 0, 0);
                Dice2Array[o] = new PictureBoxDice(0, 0, 0);
            }
        }

        // Function For a click even ona a player
        public void Player_Picture_Click(object sender, EventArgs e)
        {
            PictureBoxPlayer Soldier_Pic = (PictureBoxPlayer)sender;
            int Row = Soldier_Pic.Row, Column = Soldier_Pic.Column;

            if (PictureBoxPlayer.PlayerSave != null && this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count > 1 && this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player != this.Hex_board.GetHexBoard()[Row, Column].Player)
            {
                if (this.Turn == -1)
                {
                    if (this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player != this.Hex_board.GetHexBoard()[Row, Column].Player)
                    {
                        if (this.Hex_board.LegalMove(PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column, Row, Column))
                        {
                            if (this.Hex_board.GetHexBoard()[Row, Column].Player != 0 && this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player != this.Hex_board.GetHexBoard()[Row, Column].Player)
                            {
                                int Player1_score, Player2_Score;
                                for (int i = 0; i < 10; i++)
                                {
                                    this.Dice1Array[i].RemoveImage();
                                    this.Dice2Array[i].RemoveImage();
                                }
                                if (this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player == -1)
                                {
                                    Player1_score = this.War1(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count);
                                    Player2_Score = this.War2(this.Hex_board.GetHexBoard()[Row, Column].Player_Count);
                                    if (Player1_score > Player2_Score)
                                    {
                                        this.PicPlot[Row, Column].NumPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.AddPlayerImage(-1);
                                        this.Hex_board.GetHexBoard()[Row, Column].Player = -1;
                                        this.PicPlot[Row, Column].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1);
                                        this.Hex_board.GetHexBoard()[Row, Column].Player_Count = this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1;
                                        this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                        PictureBoxPlayer.PlayerSave = Soldier_Pic;
                                    }
                                    else
                                    {
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                        this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                    }
                                }
                                else
                                {
                                    Player2_Score = this.War2(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count);
                                    Player1_score = this.War1(this.Hex_board.GetHexBoard()[Row, Column].Player_Count);
                                    if (Player2_Score > Player1_score)
                                    {
                                        this.PicPlot[Row, Column].NumPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.AddPlayerImage(-2);
                                        this.PicPlot[Row, Column].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1);
                                        PictureBoxPlayer.PlayerSave = Soldier_Pic;
                                    }
                                    else
                                    {
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                        this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                    }
                                }
                            }
                            else
                            {
                                this.Hex_board.GetHexBoard()[Row, Column].Player = -1;
                                this.Hex_board.GetHexBoard()[Row, Column].Player_Count = this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1;
                                this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                this.PicPlot[Row, Column].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[Row, Column].Player_Count);
                                this.PicPlot[Row, Column].PlayerPic.AddPlayerImage(-1);
                                PictureBoxPlayer.PlayerSave = Soldier_Pic;
                            }
                        }
                    }
                }
                if (this.Turn == -2)
                {
                    if (this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player != this.Hex_board.GetHexBoard()[Row, Column].Player)
                    {
                        if (this.Hex_board.LegalMove(PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column, Row, Column))
                        {
                            if (this.Hex_board.GetHexBoard()[Row, Column].Player != 0 && this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player != this.Hex_board.GetHexBoard()[Row, Column].Player)
                            {
                                int Player1_score, Player2_Score;
                                for (int i = 0; i < 10; i++)
                                {
                                    this.Dice1Array[i].RemoveImage();
                                    this.Dice2Array[i].RemoveImage();
                                }
                                if (this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player == -2)
                                {
                                    Player2_Score = this.War2(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count);
                                    Player1_score = this.War1(this.Hex_board.GetHexBoard()[Row, Column].Player_Count);
                                    if (Player2_Score > Player1_score)
                                    {
                                        this.PicPlot[Row, Column].NumPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.AddPlayerImage(-2);
                                        this.Hex_board.GetHexBoard()[Row, Column].Player = -2;
                                        this.PicPlot[Row, Column].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1);
                                        this.Hex_board.GetHexBoard()[Row, Column].Player_Count = this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1;
                                        this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                        PictureBoxPlayer.PlayerSave = Soldier_Pic;

                                    }
                                    else
                                    {
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                        this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(-2);
                                    }
                                }
                                else
                                {
                                    Player2_Score = this.War2(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count);
                                    Player1_score = this.War1(this.Hex_board.GetHexBoard()[Row, Column].Player_Count);
                                    if (Player2_Score > Player1_score)
                                    {
                                        this.PicPlot[Row, Column].NumPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.RemoveImage();
                                        this.PicPlot[Row, Column].PlayerPic.AddPlayerImage(-2);
                                        this.PicPlot[Row, Column].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1);
                                        PictureBoxPlayer.PlayerSave = Soldier_Pic;

                                    }
                                    else
                                    {
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                        this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                    }
                                }
                            }
                            else
                            {
                                this.Hex_board.GetHexBoard()[Row, Column].Player = -2;
                                this.Hex_board.GetHexBoard()[Row, Column].Player_Count = this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count - 1;
                                this.Hex_board.GetHexBoard()[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].Player_Count = 1;
                                this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.RemoveImage();
                                this.PicPlot[PictureBoxPlayer.PlayerSave.Row, PictureBoxPlayer.PlayerSave.Column].NumPic.AddNumImage(1);
                                this.PicPlot[Row, Column].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[Row, Column].Player_Count);
                                this.PicPlot[Row, Column].PlayerPic.AddPlayerImage(-2);
                                PictureBoxPlayer.PlayerSave = Soldier_Pic;
                            }
                        }
                    }
                }
            }
            else
            {
                PictureBoxPlayer.PlayerSave = Soldier_Pic;
                if (this.Turn == -1 && this.Hex_board.GetHexBoard()[Row, Column].Player != -1)
                    PictureBoxPlayer.PlayerSave = null;
                if (this.Turn == -2 && this.Hex_board.GetHexBoard()[Row, Column].Player != -2)
                    PictureBoxPlayer.PlayerSave = null;
            }
        }

        private void HexBattles_Load(object sender, EventArgs e)
        {
        }

        // Calculates who wins
        private int War1(int Player1_Soldiers)
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 7), Sum = 0, i = 0;
            for (int j = 0; j < Player1_Soldiers; j++)
            {
                this.Dice1Array[i].AddDiceImage(value);
                this.Controls.Add(this.Dice1Array[i]);
                this.Dice1Array[i].Location = new Point(150 + 70 * i, 750);
                i++;
                Sum += value;
                value = rnd.Next(1, 7);
            }
            return Sum;
        }
        private int War2(int Player2_Soldiers)
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 7), Sum = 0, i = 0;
            for (int j = 0; j < Player2_Soldiers; j++)
            {
                this.Dice2Array[i].AddDiceImage(value);
                this.Controls.Add(this.Dice2Array[i]);
                this.Dice2Array[i].Location = new Point(1100 + 70 * i, 750);
                i++;
                Sum += value;
                value = rnd.Next(1, 7);
            }
            return Sum;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            DrawBoard();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Hex_board.GetHexBoard()[i, j].Player == -2)
                    {
                        Location loc = new Location(i, j);
                        Stack<Location> path = new AlphaBeta().GetBestPath(this.Hex_board, loc);
                        DoAIMove(path, this.Hex_board);
                    }
                }
            }

        }

        // Functions done by clicking button1
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Turn == -1)
                this.Turn--;
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (this.Hex_board.GetHexBoard()[i, j].Player != 0)
                        {
                            if (this.Hex_board.GetHexBoard()[i, j].Hex == 2)
                            {
                                if (this.Hex_board.GetHexBoard()[i, j].Player_Count + 2 > 9)
                                {
                                    this.Hex_board.GetHexBoard()[i, j].Player_Count = 9;
                                    this.PicPlot[i, j].NumPic.RemoveImage();
                                    this.PicPlot[i, j].NumPic.AddNumImage(9);
                                }
                                else
                                {
                                    this.Hex_board.GetHexBoard()[i, j].Player_Count += 2;
                                    this.PicPlot[i, j].NumPic.RemoveImage();
                                    this.PicPlot[i, j].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[i, j].Player_Count);
                                }
                            }
                            else
                            {
                                if (this.Hex_board.GetHexBoard()[i, j].Player_Count + 1 > 9)
                                {
                                    this.Hex_board.GetHexBoard()[i, j].Player_Count = 9;
                                    this.PicPlot[i, j].NumPic.RemoveImage();
                                    this.PicPlot[i, j].NumPic.AddNumImage(9);
                                }
                                else
                                {
                                    this.Hex_board.GetHexBoard()[i, j].Player_Count += 1;
                                    this.PicPlot[i, j].NumPic.RemoveImage();
                                    this.PicPlot[i, j].NumPic.AddNumImage(this.Hex_board.GetHexBoard()[i, j].Player_Count);
                                }
                            }
                        }
                    }
                }

                this.Turn++;
            }
            PictureBoxPlayer.PlayerSave = null;
        }

        private void DoAIMove(Stack<Location> moves, HexBoard board)
        {

            if (moves.Count < 2)
            {
                return;
            }
            Location from = moves.Pop();
            Location to = moves.Peek();
            board.DoMove(from, to);
            this.PicPlot[from.x, from.y].NumPic.AddNumImage(6);
            this.PicPlot[to.x, to.y].PlayerPic.AddPlayerImage(-2);
            this.PicPlot[to.x, to.y].NumPic.AddNumImage(Hex_board.GetHexBoard()[from.x, from.y].Player_Count - 1);
        }
    }
}
