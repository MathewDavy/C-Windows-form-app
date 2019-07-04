using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class HandLimitRule : RuleCard
    {

        public HandLimitRule(Bitmap bitmap, int num) : base(bitmap, num)
        {
            
        }

        public override bool CheckRule(Player player)
        {
            if (player.NumInHand <= _num)
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
