using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Fluxx
{
    abstract class Player
    {
        protected List<Card> _hand;
        protected List<Keeper> _keepersPlayedList;
        protected PictureBox _pBoxHand;
        protected PictureBox _pBoxKeepers;
        protected Graphics _paperHand;
        protected Graphics _paperKeepers;
        protected Pen p = new Pen(Color.Black, 4);

        protected int _numOfDraws = 0;
        protected int _numInHand = 0;
        protected int _numOfKeepersInHand = 0;     
        protected int _numCardsPlayed = 0;

        protected int _cumulativeXposHand = 5;
        protected int _cumulativeXPosPlayedCards = 5;
        protected const int _RESET_XPOS = 5;

        /// <summary>
        /// A player in the game
        /// </summary>
        public Player()
        {
            _hand = new List<Card>();
            _keepersPlayedList = new List<Keeper>();
        }

        public List<Card> HandList
        {
            get { return _hand; }
            set { _hand = value; }
        }

        public List<Keeper> KeeperList
        {
            get { return _keepersPlayedList; }
        }

        public void AddToHand(Card card)
        {
            _hand.Add(card);
        }

        public int NumCardsPlayed
        {
            get { return _numCardsPlayed; }
            set { _numCardsPlayed = value; }
        }

        public int NumOfDraws
        {
            get { return _numOfDraws; }
            set { _numOfDraws = value; }
        }

        public int NumInHand
        {
            get { return _numInHand; }
            set { _numInHand = value; }
        }

        public int NumOfKeepersInHand
        {
            get { return _numOfKeepersInHand; }
            set { _numOfKeepersInHand = value; }
        }

        public int CumulativeXPosHand
        {
            get { return _cumulativeXposHand; }
            set { _cumulativeXposHand = value; }
        }

        public int CumulativeXposKeepers
        {
            get { return _cumulativeXPosPlayedCards; }
            set { _cumulativeXPosPlayedCards = value; }
        }

        public PictureBox PictureBoxHand
        {
            get { return _pBoxHand; }
            set { _pBoxHand = value; }
        }

        public PictureBox PictureBoxKeepers
        {
            get { return _pBoxKeepers; }
            set { _pBoxKeepers = value; }
        }

        public int RESETXPOS
        {
            get { return _RESET_XPOS; }
        }

        public Graphics PaperKeepers
        {
            get { return _paperKeepers; }
            set { _paperKeepers = value; }
        }

        public Graphics PaperHand
        {
            get { return _paperHand; }
            set { _paperHand = value; }
        }

        /// <summary>
        /// displays hand
        /// </summary>
        /// <param name="paper"></param>
        public void DisplayHand()
        {
            //clears picturebox and resets border
            PictureBoxHand.Refresh();
            Rectangle rectPlayerHand = new Rectangle(0, 0, PictureBoxHand.Width, PictureBoxHand.Height);
            _paperHand.DrawRectangle(p, rectPlayerHand);

            //then draw each card
            foreach (Card c in _hand)
            {
                _paperHand.DrawImage(c.Bitmap, _cumulativeXposHand, c.YPos);
                //need to set XPos for the IsMouseOn() method
                c.XPos = _cumulativeXposHand;
                _cumulativeXposHand += c.WIDTH + c.GAP;
            }
            //reset for next time it is called          
            _cumulativeXposHand = _RESET_XPOS;
        }

        /// <summary>
        /// draws a keeper card, adds to the keeper list, removes from hand and checks for win
        /// </summary>
        /// <param name="paper"></param>
        public abstract void PlayKeeper(Goal currentGoal);

        /// <summary>
        /// The base method for draws a keeper card, adds to the keeper list, removes from hand and checks for win
        /// </summary>
        /// <param name="currentGoal"></param>
        /// <param name="num"></param>
        public void PlayKeeperBase(Goal currentGoal, int num)
        {
            Keeper k = (Keeper)_hand[num];
            Keeper k1 = new Keeper(k.NameOfCard, k.Bitmap);
            PaperKeepers.DrawImage(_hand[num].Bitmap, _cumulativeXPosPlayedCards, _hand[num].YPos);
            _cumulativeXPosPlayedCards += _hand[num].WIDTH + _hand[num].GAP;
            _keepersPlayedList.Add(k1);         
            _hand.RemoveAt(num);       
        }

        /// <summary>
        /// draws a new rule, adds it to the table list and removes from hand
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public abstract RuleCard PlayNewRule(Board board);

        /// <summary>
        /// the base method for draws a new rule, adds it to the table list and removes from hand
        /// </summary>
        /// <param name="board"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public RuleCard PlayNewRuleBase(Board board, int num)
        {
            //the new rule to be added
            RuleCard nR1;

            //converts from card to new rule
            RuleCard nR = (RuleCard)_hand[num];
            //creates new object, not just reference object
            if (nR is DrawRule)
            {
                nR1 = new DrawRule(nR.Bitmap, nR.Num);
            }
            else if (nR is PlayRule)
            {
                nR1 = new PlayRule(nR.Bitmap, nR.Num);
            }
            else if (nR is HandLimitRule)
            {
                nR1 = new HandLimitRule(nR.Bitmap, nR.Num);
            }
            else
            {
                nR1 = new KeeperLimitRule(nR.Bitmap, nR.Num);
            }
            //if the only thing in the list is the basic rule, draw new rule to the side
            if (board.TableList.Count == 1)
            {
                nR1.XPos = board.CumulativeXPosTable;
                board.PaperTable.DrawImage(nR1.Bitmap, nR1.XPos, nR1.YPos);
                board.CumulativeXPosTable += nR1.WIDTH + nR1.GAP;
            }
            //else there is at least already one rule on the table
            else
            {
                //for every new rule in the list not counting the basic rule
                for (int n = 1; n < board.TableList.Count; n++)
                {
                    //if the nR1 is the same rule type as a rule already there, draw over it
                    if (nR1.GetType() == board.TableList[n].GetType())
                    {
                        nR1.XPos = board.TableList[n].XPos;
                        board.PaperTable.DrawImage(nR1.Bitmap, board.TableList[n].XPos, board.TableList[n].YPos);
                        //We Want to remove the rule that we are drawing over but not if it is a DrawRule
                        if (board.TableList[n] is DrawRule)
                        {

                        }
                        else
                        {
                            board.TableList.RemoveAt(n);
                        }
                        break;
                    }
                    //if we've gone passed every new rule and we didn't hit the break above, it is a unique new rule so draw to the side
                    if (n == board.TableList.Count - 1)
                    {
                        nR1.XPos = board.CumulativeXPosTable;
                        board.PaperTable.DrawImage(nR1.Bitmap, nR1.XPos, nR1.YPos);
                        board.CumulativeXPosTable += nR1.WIDTH + nR1.GAP;
                    }
                }
            }
            board.TableList.Add(nR1);
            _hand.RemoveAt(num);
            return nR1;
        }

        /// <summary>
        /// Draws a goal card, sets current goal, removes from hand and checks for win
        /// </summary>
        /// <param name="paper"></param>
        public abstract Goal PlayGoal(Board b);

        /// <summary>
        /// the base method for Draws a goal card, sets current goal, removes from hand and checks for win
        /// </summary>
        /// <param name="b"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public Goal PlayGoalBase(Board b, int num)
        {
            Goal goalToAdd;
            //set goalToAdd to the selected goal
            goalToAdd = (Goal)_hand[num];
            if (goalToAdd is GoalKeeperType)
            {
                GoalKeeperType gK = (GoalKeeperType)goalToAdd;
                //create a new goal of correct type
                goalToAdd = new GoalKeeperType(gK.Bitmap, gK.Keeper1, gK.Keeper2);
            }
            else
            {
                GoalNumber gN = (GoalNumber)goalToAdd;
                //essesntially two types of GoalNUmber cards: Card requirement and Keeper requirement
                if (gN.Keeper == true)
                {
                    goalToAdd = new GoalNumber(gN.Bitmap, true, gN.Number);
                }
                else
                {
                    goalToAdd = new GoalNumber(gN.Bitmap, false, gN.Number);
                }

            }
            //draw the goalToAdd
            b.PaperTable.DrawImage(goalToAdd.Bitmap, _RESET_XPOS, goalToAdd.HEIGHT + goalToAdd.GAP);
            _hand.RemoveAt(num);           
            return goalToAdd;
        }

        /// <summary>
        /// Draws an action card, does the action and removes from hand
        /// </summary>
        /// <param name="paper"></param>
        /// <param name="d"></param>
        /// <param name="b"></param>
        public abstract void PlayAction(Player player, Player playerOther, Deck d, Board b);

        /// <summary>
        /// base method for Draws an action card, does the action and removes from hand
        /// </summary>
        /// <param name="d"></param>
        /// <param name="b"></param>
        /// <param name="num"></param>
        public void PlayActionBase(Player player, Player playerOther, Deck d, Board b, int num)
        {
            //draw the action card played
            b.PaperTable.DrawImage(_hand[num].Bitmap, _hand[num].WIDTH + 10, _hand[num].HEIGHT + 15);
            Action action = (Action)_hand[num];
            //performs the action
            action.EnforceAction(player, playerOther, d, b);
            //we don't want to remove the action card selected from the hand if "Discard and Draw" card
            //as its EnforceAction method already discards it
            if (action is DiscardAndDraw || action is TradeHands)
            {

            }
            else
            {
                _hand.RemoveAt(num);
            }
        }

        /// <summary>
        /// checks the current goal to see if the player has won
        /// </summary>
        /// <returns></returns>
        public bool CheckForWin(Goal currentGoal)
        {         
            if (currentGoal != null)
            {
                //checks the current goal for win
                if (currentGoal.CheckForWin(currentGoal, this))
                {                 
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the player is in compliance with all the rules on the table
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CheckRules(Player player, Board board)
        {
            //booleans for types of rules, set to true as not every type of rule will be on the table
            //so automatically in compliance with the rule if that rule is not on the table          
            bool draw = true;
            bool play = true;
            bool handLimit = true;
            bool keeperLimit = true;
            bool basicRule = true;

            //for all the rules on the table, set the above bools to the result of the compliance testing
            for (int i = 0; i < board.TableList.Count; i++)
            {
                if (board.TableList[i] is BasicRules)
                {
                    basicRule = board.TableList[i].CheckRule(player);
                }

                else if (board.TableList[i] is DrawRule)
                {
                    draw = board.TableList[i].CheckRule(player);
                }

                else if (board.TableList[i] is PlayRule)
                {
                    play = board.TableList[i].CheckRule(player);
                }

                else if (board.TableList[i] is HandLimitRule)
                {
                    handLimit = board.TableList[i].CheckRule(player);
                }
                else
                {
                    keeperLimit = board.TableList[i].CheckRule(player);
                }
            }
            //if in compliance with all the rules return true
            if (draw && play && handLimit && keeperLimit && basicRule)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Redraws outline of player's hand and keepers played picturebox
        /// </summary>
        public void RedrawBoard()
        {
            Rectangle rectHand = new Rectangle(0, 0, _pBoxHand.Width, _pBoxHand.Height);
            _paperHand.DrawRectangle(p, rectHand);
            Rectangle rectKeepers = new Rectangle(0, 0, _pBoxKeepers.Width, _pBoxKeepers.Height);
            _paperKeepers.DrawRectangle(p, rectKeepers);
        }
    }
}
