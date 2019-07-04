using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class Human : Player
    {
       

        public Human()
        {

        }
   

        public override void PlayKeeper(Goal currentGoal)
        {
            for (int i = _hand.Count - 1; i >= 0; i--)
            {
                //only play the card(s) that is selected
                if (_hand[i].Selected)
                {
                    PlayKeeperBase(currentGoal, i);
                    break;
                }
            }
        }
       
        public override RuleCard PlayNewRule(Board board)
        {          
            for (int i = _hand.Count - 1; i >= 0; i--)
            {
                //only play the card that is selected
                if (_hand[i].Selected)
                {
                   return PlayNewRuleBase(board, i);
                }
            }
            return null;
        }
            
        public override Goal PlayGoal(Board board)
        {
            
            for (int i = _hand.Count - 1; i >= 0; i--)
            {
                //only play the card(s) that is selected
                if (_hand[i].Selected)
                {
                    return PlayGoalBase(board, i);
                }
            }
            return null;
        }

        public override void PlayAction(Player player, Player playerOther, Deck d, Board b)
        {
            for (int i = _hand.Count - 1; i >= 0; i--)
            {
                //only play the card(s) that is selected
                if (_hand[i].Selected)
                {
                    PlayActionBase(player, playerOther, d, b, i);
                    break;
                }
            }
        }
    }
}
