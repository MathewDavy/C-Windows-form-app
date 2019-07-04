using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Fluxx
{
    class BasicRules : RuleCard
    {

        /// <summary>
        /// creates a basic rule card
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="num"></param>
        public BasicRules(Bitmap bitmap, int num) : base(bitmap, num)
        {
            
        }

        
        public override bool CheckRule(Player player)
        {
            if (player.NumOfDraws >= _num && player.NumCardsPlayed >= _num)
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
