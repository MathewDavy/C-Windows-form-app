using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluxx
{
    class Computer : Player
    {
        //random number for selecting a card
        private int _num = 0;    
        private List<int> _numsNotToPlay = new List<int>();     
        private bool _ableToPlayGoal = true;

        /// <summary>
        /// creates a computer player
        /// </summary>
        public Computer()
        {

        }

        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public bool AbleToPlayGoal
        {
            get { return _ableToPlayGoal; }
            set { _ableToPlayGoal = value; }
        }


        public override void PlayKeeper(Goal currentGoal)
        {
            PlayKeeperBase(currentGoal, _num);
        }

        public override RuleCard PlayNewRule(Board board)
        {
            return PlayNewRuleBase(board, _num);
            
        }

        public override Goal PlayGoal(Board b)
        {
            return PlayGoalBase(b, _num);
            
        }

        public override void PlayAction(Player player, Player playerOther, Deck d, Board b)
        {
            PlayActionBase(player, playerOther, d, b, _num);
        }

        /// <summary>
        /// if the player has a goal card and its requirements have been played, play the goal card
        /// </summary>
        /// <returns></returns>
        public bool FirstTest()
        {          
            for (int i = 0; i < HandList.Count; i++)
            {
                if (HandList[i] is GoalKeeperType)
                {
                    GoalKeeperType g = (GoalKeeperType)HandList[i];
                    for (int j = 0; j < KeeperList.Count; j++)
                    {
                        if (KeeperList[j].NameOfCard == g.Keeper1 || KeeperList[j].NameOfCard == g.Keeper2)
                        {                   
                            for (int k = j + 1; k < KeeperList.Count; k++)
                            {
                                if (KeeperList[k].NameOfCard == g.Keeper1 || KeeperList[k].NameOfCard == g.Keeper2)
                                {
                                    Num = i;                                  
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        
        /// <summary>
        /// if the player has a keeper in hand and that keeper is one of the requirements for the current goal, play that keeper
        /// </summary>
        /// <param name="currentGoal"></param>
        /// <returns></returns>
        public bool SecondTest(Goal currentGoal)
        {
            for (int i = 0; i < HandList.Count; i++)
            {
                if (HandList[i] is Keeper)
                {
                    Keeper k = (Keeper)HandList[i];
                    if (currentGoal is GoalKeeperType)
                    {
                        GoalKeeperType g = (GoalKeeperType)currentGoal;
                        
                        if (k.NameOfCard == g.Keeper1 || k.NameOfCard == g.Keeper2)
                        {                        
                            Num = i;
                            return true;                           
                        }
                    }
                }
            }
            return false;
        }
        
       
         /// <summary>
        /// If the player has a keeper in hand that meets one of the requirements for a goal also in hand, play that keeper
        /// </summary>
        /// <param name="currentGoal"></param>
        /// <returns></returns> 
        public bool ThirdTest()
        {
            for (int i = 0; i < HandList.Count; i++)
            {
                if (HandList[i] is GoalKeeperType)
                {
                    GoalKeeperType g = (GoalKeeperType)HandList[i];

                    for (int j = 0; j < HandList.Count; j++)
                    {
                        if (HandList[j] is Keeper)
                        {
                            Keeper k = (Keeper)HandList[j];

                            if (k.NameOfCard == g.Keeper1 || k.NameOfCard == g.Keeper2)
                            {
                                Num = j;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// finds out which goal cards in the Computer's hand would let the human win instantly
        /// </summary>
        /// <param name="player"></param>
        public void DontPlayCards(Player player)
        {
            for (int i = 0; i < HandList.Count; i++)
            {
                if (HandList[i] is GoalKeeperType)
                {
                    GoalKeeperType g = (GoalKeeperType)HandList[i];

                    for (int j = 0; j < player.KeeperList.Count; j++)
                    {
                        //if the human has played keepers that would meet the goal in the computer's hand
                        if (player.KeeperList[j].NameOfCard == g.Keeper1 || player.KeeperList[j].NameOfCard == g.Keeper2)
                        {
                            //look for the second keeper
                            for (int k = j + 1; k < player.KeeperList.Count; k++)
                            {
                                if (player.KeeperList[k].NameOfCard == g.Keeper1 || player.KeeperList[k].NameOfCard == g.Keeper2)
                                {
                                    //don't play that goal
                                    _numsNotToPlay.Add(i);                                 
                                }
                            }
                        }
                    }
                }
            }          
        }
       
        /// <summary>
        /// Play a random card that doesn't let the human instantly win OR override the goal when one of the keepers required is already in play
        /// </summary>
        /// <param name="currentGoal"></param>
        public void LastResort(Goal currentGoal)
        {
            Random rand = new Random();
            int num = rand.Next(HandList.Count);
            bool onGoal = true;
            bool foundValidCard = false;

            //checks to see we are able to play a card at random
            if (currentGoal is GoalKeeperType)
            {
                GoalKeeperType g = (GoalKeeperType)currentGoal;
                for (int i = 0; i < KeeperList.Count; i++)
                {
                    //if there is a played keeper that meets part of the current goal
                    if (KeeperList[i].NameOfCard == g.Keeper1 || KeeperList[i].NameOfCard == g.Keeper2)
                    {
                        for (int j = 0; j < HandList.Count; j++)
                        {
                            //if there is a goal card in the hand, we cannot select the first random number as it may be the goal card 
                            //and thus override the current goal
                            if (HandList[j] is Goal)
                            {
                                AbleToPlayGoal = false;
                            }
                        }
                    }
                }
            }
            
            int goalCounter = 0;
            //counts number of goals in the hand as if there are only goal cards in the hand, the computer will have to override the current goal anyway
            foreach (Card c in HandList)
            {
                if (c is Goal)
                {
                    goalCounter++;
                }
            }
            //if there are no goal cards in the hand OR there are only goal cards in the hand
            if (AbleToPlayGoal || goalCounter == HandList.Count )
            {
                //we need to keep selecting a random card in the handlist until we get a valid card i.e not a goal card that will let the human win
                while (foundValidCard == false)
                {
                    num = rand.Next(HandList.Count);
                    Num = num;
                    //there are no bad cards to play so we can play any card we want
                    if (_numsNotToPlay.Count == 0)
                    {
                        foundValidCard = true;
                    }
                    //else there are bad cards and we dont want to play it
                    else
                    {
                        for (int i = 0; i < _numsNotToPlay.Count; i++)
                        {
                            if (_numsNotToPlay[i] == num)
                            {
                                //go through the while loop again with a different random number
                            }
                            else
                            {
                                foundValidCard = true;
                                break;
                            }
                        }
                    }
                }             
            }
            //We don't want to play a goal card as it will override the current one
            else
            {
                //while the random number is selecting a goal card, keep trying with a different random number
                while (onGoal == true)
                {
                    Num = rand.Next(HandList.Count);
                    if (HandList[Num] is Goal)
                    {
                        //go around the loop again
                    }
                    else
                    {
                        onGoal = false;
                    }
                }
            }
        }

       

    }
}
