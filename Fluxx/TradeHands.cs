using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class TradeHands : Action
    {

        public TradeHands(Bitmap bitmap) : base(bitmap)
        {

        }

        public override void EnforceAction(Player player, Player playerOther, Deck d, Board b)
        {
            //temp hand holder
            Human h1 = new Human();
            //Before we do the swap, loop through hand and remove the TradeHands action card 
            for (int i = player.HandList.Count -1; i >= 0; i--)
            {
                if (player.HandList[i] is TradeHands)
                {
                    player.HandList.RemoveAt(i);
                   
                    break;
                }
            }
            playerOther.NumInHand++;
            //set temp equal to the first hand
            h1.HandList = player.HandList;
            h1.NumInHand = player.NumInHand - 1;
            h1.NumOfKeepersInHand = player.NumOfKeepersInHand;
            //set the first hand equal to the second hand
            player.HandList = playerOther.HandList;
            player.NumInHand = playerOther.NumInHand;
            player.NumOfKeepersInHand = playerOther.NumOfKeepersInHand;
            //set the second hand equal to the temp hand
            playerOther.HandList = h1.HandList;
            playerOther.NumInHand = h1.NumInHand;
            playerOther.NumOfKeepersInHand = h1.NumOfKeepersInHand;

            //display hands
            player.DisplayHand();
            playerOther.DisplayHand();
        }
    }
}
