using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class DrawRule : RuleCard
    {

        public DrawRule(Bitmap bitmap, int num) : base(bitmap, num)     
        {
            
        }

        public override bool CheckRule(Player player)
        {
            if (player.NumOfDraws >= _num)
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
