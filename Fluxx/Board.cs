using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Fluxx
{
    class Board
    {
        private List<RuleCard> _tableList;
        private int _RESET_XPOS = 85;
        private int _cumulativeXPosTable = 85;
        private PictureBox _pBoxTable;
        private Graphics _paperTable;
        private Pen p = new Pen(Color.Black, 4);
        BasicRules _basicRule = new BasicRules(Properties.Resources.Basic_Rules, 1);

        /// <summary>
        /// The communual board for the game
        /// </summary>
        public Board()
        {
            //initialses tableList with the basicRule in it
            _tableList = new List<RuleCard>() {_basicRule };
        }

        public List<RuleCard> TableList
        {
            get { return _tableList; }
            set { _tableList = value; }
        }

        public int CumulativeXPosTable
        {
            get { return _cumulativeXPosTable; }
            set { _cumulativeXPosTable = value; }
        }

        public int RESETXPOS
        {
            get { return _RESET_XPOS; }
        }

        public Graphics PaperTable
        {
            get { return _paperTable; }
            set { _paperTable = value; }
        }

        public PictureBox PictureBoxTable
        {
            get { return _pBoxTable; }
            set { _pBoxTable = value; }
        }

        /// <summary>
        /// redraws the board
        /// </summary>
        public void RedrawBoard()
        {
            Rectangle rectHand = new Rectangle(0, 0, PictureBoxTable.Width, PictureBoxTable.Height);
           _paperTable.DrawRectangle(p, rectHand);
            _paperTable.DrawImage(_tableList[0].Bitmap, _tableList[0].XPos, _tableList[0].YPos);
        }

        public BasicRules BasicRule
        {
            get { return _basicRule; }
        }


    }
}
