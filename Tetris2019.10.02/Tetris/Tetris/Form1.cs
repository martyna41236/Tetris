using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class MainForm : Form
    {
        protected int _currentPositionX = 100;
        protected int _currentPositionY = 100;

        protected bool[,] _tetriminoI = null;
        protected bool[,] _tetriminoT = null;
        protected bool[,] _tetriminoO = null;
        protected bool[,] _tetriminoL = null;
        protected bool[,] _tetriminoJ = null;
        protected bool[,] _tetriminoS = null;
        protected bool[,] _tetriminoZ = null;

        public MainForm()
        {
            InitializeComponent();

            //initialize definition of "I" tetrimino that looks like this:
            // #
            // #
            // #
            // #

            //first create appropriate two dimentional array of 4 rows and 1 column
            _tetriminoI = new bool[4, 1];
            //then set appropriate positions to True in order to encode the "I" tetrimino
            //NOTE: arrays are zero-based, so index of rows of this very array ranges from 0 to 3
            _tetriminoI[0, 0] = true;
            _tetriminoI[1, 0] = true;
            _tetriminoI[2, 0] = true;
            _tetriminoI[3, 0] = true;


            //initialize definition of "T" tetrimino that looks like this:
            // ###
            //  #

            //first create appropriate two dimentional array of 2 rows and 3 columns
            _tetriminoT = new bool[2, 3];
            //then set appropriate positions to True in order to encode the "T" tetrimino
            _tetriminoT[0, 0] = true;
            _tetriminoT[0, 1] = true;
            _tetriminoT[0, 2] = true;
            _tetriminoT[1, 1] = true;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //create a blue pen
            Pen bluePen = new Pen(Color.Blue);

            //loop through rows of tetrimino's definition
            for (int rowIndex = 0; rowIndex <= _tetriminoT.GetUpperBound(0); rowIndex++)
            {
                //loop through columns of tetrimino's definition
                for (int columnIndex = 0; columnIndex <= _tetriminoT.GetUpperBound(1); columnIndex++)
                {
                    //if a tetrimino's piece should be drawn at the position selected with row and column indexes
                    if (_tetriminoT[rowIndex, columnIndex] == true)
                    {
                        //yes, according to the tetrimino's definition, there is supposed to be a piece drawn
                        //so first calculate its position offset
                        int positionOffsetX = columnIndex * 10;
                        int positionOffsetY = rowIndex * 10;

                        //then calculate actual position of the piece
                        int actualPositionX = _currentPositionX + positionOffsetX;
                        int actualPositionY = _currentPositionY + positionOffsetY;

                        //finally draw the piece as a square of 10x10 pixels starting at the actual position
                        e.Graphics.DrawRectangle(bluePen, actualPositionX, actualPositionY, 10, 10);
                    }
                }
            }

            //destroy blue pen
            bluePen.Dispose();

            //update vertical position to allow tetrimino to fall
            _currentPositionY += 10;
            //if the vertical position exceeds bottom edge of the window
            if (_currentPositionY > e.ClipRectangle.Bottom)
            {
                //yes, so reset it back to the top
                _currentPositionY = 100;
            }

            //wait for a while
            Thread.Sleep(250);

            //refresh screen
            Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if Left arrow key was pressed
            if (e.KeyCode == Keys.Left)
            {
                //yes, move tetrimino to the left
                _currentPositionX -= 10;
            }
            //if Right arrow key was pressed
            if (e.KeyCode == Keys.Right)
            {
                //yes, move tetrimino to the right
                _currentPositionX += 10;
            }
        }
    }
}
