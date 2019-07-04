using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Fluxx
{
    abstract class Card
    {
        //dimensions of every card
        protected const int _WIDTH = 70;
        protected const int _HEIGHT = 100;
        protected const int _GAP = 15;
        
        protected const int _RESET_XPOS = 5;
      
        protected Bitmap _bitmap;
        protected bool _selected = false;

        protected int _xPos = _RESET_XPOS;
        protected int _yPos = 5;

        public Card(Bitmap bitmap)
        {           
            _bitmap = bitmap;                      
        }
  
        public Bitmap Bitmap
        {
            get { return _bitmap; }           
        }

        public int XPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }

        public int YPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }

        public int WIDTH
        {
            get { return _WIDTH; }
        }

        public int HEIGHT
        {
            get { return _HEIGHT; }
        }

        public int GAP
        {
            get { return _GAP; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        /// <summary>
        /// Checks whether the mouse click is on a card
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsMouseOn(int x, int y)
        {
            if (XPos <= x && x < XPos + WIDTH && YPos <= y && y < YPos + HEIGHT)
            {      
                return true;
            }
            else
            {        
                return false;
            }
        }
    }
}
