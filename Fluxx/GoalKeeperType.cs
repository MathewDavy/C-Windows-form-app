using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class GoalKeeperType : Goal
    {
        //names of keeper cards for the goal criteria
        private string _keeper1;
        private string _keeper2;

        public GoalKeeperType(Bitmap bitmap, string keeper1, string keeper2) : base(bitmap)
        {
            _keeper1 = keeper1;
            _keeper2 = keeper2;
        }

        public string Keeper1
        {
            get { return _keeper1; }
        }

        public string Keeper2
        {
            get { return _keeper2; }
        }

        public override bool CheckForWin(Goal goal, Player player)
        {
            bool firstKeeper = false;
            bool secondKeeper = false;

            if (player.KeeperList.Count > 0)
            {
                foreach (Keeper k in player.KeeperList)
                {
                    //cast Goal to GoalKeeperType
                    GoalKeeperType g = (GoalKeeperType)goal;
                    //checks each keeper against the goal criteria
                    if (k.NameOfCard == g.Keeper1)
                    {
                        firstKeeper = true;
                    }
                    if (k.NameOfCard == g.Keeper2)
                    {
                        secondKeeper = true;
                    }
                }
            }
            //if goal met
            if (firstKeeper && secondKeeper)
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
