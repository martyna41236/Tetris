using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To jest Handler eventu Paint.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e) //< ----- to 'e' jest skrótem od 'event'
        {
            //tutaj tworzymy pisak o kolorze niebieskim
            //i podstawiamy pod zmienną o nazwie 'bluePen'
            Pen bluePen; //<---- to jest deklaracja zmiennej o nazwie 'bluePen',
                         //to znaczy, że mówie komputerowi, iż chcę mieć zmienną o nazwie 'bluePen'
                         //i będę jej używał jako pisak (Pen)

            //mająć już zmienną, o której powiedziałem, że bedzie moim pisakime
            //przystawiam do niej ów pisak
            bluePen = new Pen(Color.Blue);


            //w tym miejscu mamy już pisak (niebieski) i chcemy teraz narysować poziomą kreskę

            //jednym ze sposobów rysowania linii jest podanie pisaka, który u nas jest przystawiony
            //do zmiennej o nazwie 'bluePen' oraz podanie początku i końca linii do narysowania
            e.Graphics.DrawLine(bluePen, 100, 100, 130, 100);
            e.Graphics.DrawLine(bluePen, 130, 100, 130, 90);
            e.Graphics.DrawLine(bluePen, 130, 90, 120, 90);
            e.Graphics.DrawLine(bluePen, 120, 90, 120, 80);
            e.Graphics.DrawLine(bluePen, 120, 80, 110, 80);
            e.Graphics.DrawLine(bluePen, 110, 80, 110, 90);
            e.Graphics.DrawLine(bluePen, 110, 90, 100, 90);
            e.Graphics.DrawLine(bluePen, 100, 90, 100, 100);

            e.Graphics.DrawLine(bluePen, 100, 100, 110, 100);
            e.Graphics.DrawLine(bluePen, 110, 100, 110, 200);
            e.Graphics.DrawLine(bluePen, 200, 110, 100, 200);
            e.Graphics.DrawLine(bluePen, 100, 200, 100, 100);

            //narysowawszy wszystkie linie ciągle mamy w łapie pisak
            //a więc musimy go teraz oddać
            //i tutaj go oddajemy 
            bluePen.Dispose();
        }
        public MainForm()
        {
            InitializeComponent();

            _tetriminoT = new bool[2, 3];

        }
    }
}
