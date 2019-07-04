using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class PlayRule : RuleCard
    {

        public PlayRule(Bitmap bitmap, int num) : base(bitmap, num)
        {

        }

        public override bool CheckRule(Player player)
        {
            if (player.NumCardsPlayed >= _num || player.HandList.Count == 0)
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
