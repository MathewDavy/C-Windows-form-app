using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class DiscardAndDraw : Action
    {
        public DiscardAndDraw(Bitmap bitmap) : base(bitmap)
        {

        }

        public override void EnforceAction(Player player, Player playerOther, Deck d, Board b)
        {
            int count = player.HandList.Count;
            //remove all cards from hand
            for (int i = player.HandList.Count - 1; i >= 0; i--)
            {               
                player.HandList.RemoveAt(i);
            }
            //reset these counters
            player.NumOfKeepersInHand = 0;
            player.NumInHand = 1;
            //deal the amount of the hand before discard
            d.DealCard(player, count);
        }
    }
}
