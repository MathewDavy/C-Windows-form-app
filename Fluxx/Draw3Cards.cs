using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class Draw3Cards : Action
    {
        public Draw3Cards(Bitmap bitmap) : base(bitmap)
        {

        }

        public override void EnforceAction(Player player, Player playerOther, Deck d, Board b)
        {           
            d.DealCard(player, 3);          
        }
    }
}
