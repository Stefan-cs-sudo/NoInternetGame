using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinoGame
{
    public partial class FormDino : Form
    {
        int DIMENSIUNE = 20;
        PictureBox pictureBox;
        int[][] Board;
        Graphics mDesen;
        SolidBrush[] pensula;
        int dinoX;
        int dinoY;
        int dinoJump = 2;//asta ma gandeam sa o folosim pentru saritura,
                         //atunci cand apesi space PLAYER-ul sare cu 2 pozitii in sus ca sa evitam obstacolele
        bool isJumping = false;
        int ground=10;//linia solului
        Random rand = new Random();//pentru obstacole

        public enum PATRATE
        {
            GOL = 0,
            PLAYER = 1,
            OBSTACOL = 2,

        }
        public FormDino()
        {
            InitializeComponent();
            mDesen = pictureBox1.CreateGraphics();

            pensula = new SolidBrush[3];
            pensula[0] = new SolidBrush(Color.White);
            pensula[1] = new SolidBrush(Color.Blue);
            pensula[2] = new SolidBrush(Color.Red);
            this.KeyDown += pressSpace;

        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Play_Click(object sender, EventArgs e)
        {

            Board = new int[60][];
            for (int i = 0; i < 60; i++)
            {
                Board[i] = new int[20];
                for (int j = 0; j < 20; j++)
                {
                    Board[i][j] = (int)PATRATE.GOL;
                }
            }
            drawBoard();
        }

        void drawBoard()
        {
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    mDesen.FillRectangle(pensula[Board[i][j]], i * DIMENSIUNE + 1, j * DIMENSIUNE + 1, DIMENSIUNE - 1, DIMENSIUNE - 1);
                }
            }

        }

        private void Game(object sender, EventArgs e)
        {
            dinoX = 12;
            dinoY = 10;
            Board[dinoX][dinoY] = (int)PATRATE.PLAYER;
            mDesen.FillRectangle(pensula[Board[dinoX][dinoY]], dinoX * DIMENSIUNE + 1, dinoY * DIMENSIUNE + 1, DIMENSIUNE - 1, DIMENSIUNE - 1);


            drawBoard();
        }
        private void pressSpace(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !isJumping)
            {
                isJumping = true;
                dinoJump = -2;
            }
        }


    }
}