using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class GoalNumber : Goal
    {
        //bool to determine if we are checking number of keepers or not
        private bool _keeper;
        private int _num;

        public GoalNumber(Bitmap bitmap, bool keeper, int num) : base(bitmap)
        {
            _keeper = keeper;
            _num = num;
        }

        public int Number
        {
            get { return _num; }
        }

        public bool Keeper
        {
            get { return _keeper; }
        }

        public override bool CheckForWin(Goal goal, Player player)
        {
            //variables for checking each time
            bool numMet = false;

            GoalNumber g = (GoalNumber)goal;
            //if we are checking the number of keepers
            if (g.Keeper == true)
            {
                if (player.KeeperList.Count >= g.Number)
                {
                    numMet = true;
                }
            }
            //else we are checking the number in the hand
            else
            {
                if (player.HandList.Count >= g.Number)
                {
                    numMet = true;
                }
            }
            return numMet;
        }
    }
}
