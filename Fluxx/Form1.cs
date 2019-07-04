using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace Fluxx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        Deck d;
        Board b = new Board();
        Human human1 = new Human();
        Computer computer1 = new Computer();
        RuleCard currentRule;
        Goal currentGoal;
        Pen pen1 = new Pen(Color.Black, 4);
        Card currentSelected;

        /// <summary>
        /// Starts and resets game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStartGame_Click_1(object sender, EventArgs e)
        {
            //refresh table
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            pictureBoxTable.Refresh();
            //set the pictureboxes
            human1.PictureBoxHand = pictureBoxHand;
            computer1.PictureBoxHand = pictureBoxCompHand;
            human1.PictureBoxKeepers = pictureBoxPlayedCards;
            computer1.PictureBoxKeepers = pictureBoxCompPlayedKeepers;
            b.PictureBoxTable = pictureBoxTable;
            //set the table graphics to the board 
            Graphics paperTable = pictureBoxTable.CreateGraphics();
            b.PaperTable = paperTable;
            //set the Keepers played graphics to each player
            Graphics paperHumankeepers = pictureBoxPlayedCards.CreateGraphics();
            human1.PaperKeepers = paperHumankeepers;
            Graphics paperCompKeepers = pictureBoxCompPlayedKeepers.CreateGraphics();
            computer1.PaperKeepers = paperCompKeepers;
            //set the cards in hand graphics to each player
            Graphics paperHumanHand = pictureBoxHand.CreateGraphics();
            human1.PaperHand = paperHumanHand;
            Graphics paperCompHand = pictureBoxCompHand.CreateGraphics();
            computer1.PaperHand = paperCompHand;

            //remove all cards on the table
            if (b.TableList.Count > 0)
            {
                for (int i = b.TableList.Count - 1; i > 0; i--)
                {
                    b.TableList.RemoveAt(i);
                }
            }
            b.CumulativeXPosTable = b.RESETXPOS;
            //create a new deck
            d = new Deck();
            //set current rule
            currentRule = b.BasicRule;
            //set current goal
            currentGoal = null;

            b.RedrawBoard();
            ResetPlayers(human1);
            ResetPlayers(computer1);
            buttonTakeTurn.Visible = true;
            buttonPlayCard.Visible = false;
        }

        /// <summary>
        /// resets player variables for a new game
        /// </summary>
        /// <param name="player"></param>
        private void ResetPlayers(Player player)
        {
            //reset variables
            player.NumInHand = 0;
            player.NumCardsPlayed = 0;
            player.NumOfKeepersInHand = 0;
            player.NumOfDraws = 0;
            player.CumulativeXPosHand = player.RESETXPOS;
            player.CumulativeXposKeepers = player.RESETXPOS;

            //clear pictureboxes
            player.PictureBoxHand.Refresh();
            player.PictureBoxKeepers.Refresh();

            //remove whole hand
            if (player.HandList.Count > 0)
            {
                for (int i = player.HandList.Count - 1; i >= 0; i--)
                {
                    player.HandList.RemoveAt(i);
                }
            }
            //remove keeperList
            if (player.KeeperList.Count > 0)
            {
                for (int i = player.KeeperList.Count - 1; i >= 0; i--)
                {
                    player.KeeperList.RemoveAt(i);
                }
            }
            d.DealCard(player, 5);
            player.DisplayHand();
            player.RedrawBoard();
        }

        /// <summary>
        /// When clicked, draws the required number of cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeTurn_Click_1(object sender, EventArgs e)
        {
            TakeTurn(human1);
            buttonTakeTurn.Visible = false;
            buttonPlayCard.Visible = true;
        }

        /// <summary>
        /// Draws the required number of cards
        /// </summary>
        /// <param name="player"></param>
        private void TakeTurn(Player player)
        {
            //new turn so reset these
            player.NumCardsPlayed = 0;
            player.NumOfDraws = 0;
            //deals one card in compliance with the basic rule
            d.DealCard(player, b.TableList[0].Num);
            //now looks for draw rules on the table
            foreach (RuleCard rc in b.TableList)
            {
                if (rc is DrawRule)
                {
                    //deal the amount - 1 due to basic rule
                    d.DealCard(player, rc.Num - 1);
                }
            }
            player.DisplayHand();
           // Test(player);
        }

        /// <summary>
        /// When mouse is clicked in player1's hand, it selects or unselects a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Card c in human1.HandList)
            {
                if (c.IsMouseOn(e.X, e.Y))
                {
                    //if it is unclicked
                    if (c.Selected == false)
                    {
                        //Set every card to unselected each time you click so that you can only select one card at a time
                        foreach (Card c1 in human1.HandList)
                        {
                            c1.Selected = false;
                            currentSelected = null;
                            human1.PaperHand.DrawImage(c1.Bitmap, c1.XPos, c1.YPos);
                        }
                        //set the clicked card to selected
                        c.Selected = true;
                        currentSelected = c;
                        //draw blue border
                        Rectangle rect = new Rectangle(c.XPos + 3, c.YPos + 3, c.WIDTH, c.HEIGHT);
                        Pen pen1 = new Pen(Color.Blue, 3);
                        human1.PaperHand.DrawRectangle(pen1, rect);
                        break;
                    }
                    //the card is already clicked
                    else
                    {
                        c.Selected = false;
                        currentSelected = null;
                        //get rid of blue outline
                        human1.PaperHand.DrawImage(c.Bitmap, c.XPos, c.YPos);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Plays the card that is clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlayCard_Click(object sender, EventArgs e)
        {
            //if nothing is actually clicked
            if (currentSelected == null)
            {
                MessageBox.Show("You must select a card to play first");
            }
            //a card is clicked and should be played
            else
            {
                PlayCard(human1);
            }
            //if rules are met, make the end turn button available
            if (human1.CheckRules(human1, b))
            {
                buttonPlayCard.Visible = false;
                buttonEndTurn.Visible = true;
            }
            //if we won, make end turn button unavailable
            if (human1.CheckForWin(currentGoal))
            {
                buttonEndTurn.Visible = false;
            }
        }
        /// <summary>
        /// Plays the card currently selected
        /// </summary>
        /// <param name="player"></param>
        private void PlayCard(Player player)
        {
            bool keeperLimitMet = true;
            //before we play any cards, are we in compliance with the keeperLimitRule?
            foreach (RuleCard rc in b.TableList)
            {
                if (rc is KeeperLimitRule)
                {
                    keeperLimitMet = rc.CheckRule(player);
                    break;
                }
            }
            //we can play a keeper regardless of keeperLimitRule status
            if (currentSelected is Keeper)
            {
                player.PlayKeeper(currentGoal);
                player.NumOfKeepersInHand--;
            }
            //if We are in compliance of the keeper limit. I don't even know if this is a rule but i want it to be
            if (keeperLimitMet || currentSelected is Keeper )
            {
                if (currentSelected is RuleCard)
                {
                    currentRule = player.PlayNewRule(b);
                    //If the new Rule is a draw card rule, we need to draw cards when we play the rule 
                    if (currentRule is DrawRule)
                    {
                        PlayDrawRule(player);
                    }
                }
                else if (currentSelected is Goal)
                {
                    currentGoal = player.PlayGoal(b);
                }
                else if (currentSelected is Action)
                {
                    //just for passing in for the trade card action card
                    Player playerOther;
                    if (player is Human)
                    {
                        playerOther = computer1;
                    }
                    else
                    {
                        playerOther = human1;
                    }
                    player.PlayAction(player, playerOther, d, b);
                }
                //This should be the only time we subtract from NumInHand and Add to NumInHand
                player.NumInHand--;
                player.NumCardsPlayed++;
                
                currentSelected = null;
                player.DisplayHand();
                Test(player);
                //to pause each time computer plays a card
                if (player is Computer)
                {
                    MessageBox.Show("Computer played a card");
                }
                //if someone won
                if (player.CheckForWin(currentGoal))
                {
                    string name = "You";
                    if (player is Computer)
                    {
                        name = "The Computer";
                    }
                    MessageBox.Show(name + " achieved the goal. Game is over");
                    //make it so the only button available is start button
                    buttonPlayCard.Visible = false;
                    buttonEndTurn.Visible = false;
                    buttonTakeTurn.Visible = false;
                }
            }
            //else we haven't complied with the keeperlimit rule AND tried playing a non-keeper card so show message and play no card
            else
            {
                //computer might do this too but we don't want to show a message when it does
                if (player is Human)
                {
                    MessageBox.Show("There is a keeper limit in play." + "\n" +
                            "You must adhere to the keeper limit before you can play a non-keeper card");
                }
            }
        }

        /// <summary>
        /// Draws the number required when a draw rule is played
        /// </summary>
        private void PlayDrawRule(Player player)
        {
            bool drawRuleIn = false;
            //check to see if there even is a drawRule on the table
            for (int r = 1; r < b.TableList.Count - 1; r++)
            {
                if (b.TableList[r] is DrawRule)
                {
                    drawRuleIn = true;
                    break;
                }
            }
            //if there are no other draw rule cards on the table, we just draw the number required, minus one due to basic card
            if (drawRuleIn == false)
            {
                d.DealCard(player, currentRule.Num - 1);
            }
            //else there is another draw rule card on the table
            else
            {
                for (int i = 1; i < b.TableList.Count - 1; i++)
                {
                    //find the drawRule position
                    if (b.TableList[i] is DrawRule)
                    {
                        //if number to draw on the card we just add is greater than what is already in the list
                        if (currentRule.Num > b.TableList[i].Num)
                        {
                            //deal difference of the two draw rule numbers
                            d.DealCard(player, currentRule.Num - b.TableList[i].Num);
                        }
                        b.TableList.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Displays in listbox the player's card status's
        /// </summary>
        /// <param name="player"></param>
        private void Test(Player player)
        {
            string name = "Computer ";
            if (player is Human)
            {
                name = "Human ";
            }
            listBox1.Items.Clear();
            listBox1.Items.Add(name + "num in hand: " + player.NumInHand);
            listBox1.Items.Add(name + "num cards played: " + player.NumCardsPlayed);
            listBox1.Items.Add(name + "num of draws: " + player.NumOfDraws);
            listBox1.Items.Add(name + "num of keepers in hand: " + player.NumOfKeepersInHand);

        }

        /// <summary>
        /// ends player's turn and starts computer's turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            // Only when the rule is met can you end turn
            if (human1.CheckRules(human1, b))
            {
                MessageBox.Show("Rule met. Computer's turn");
                buttonEndTurn.Visible = false;
                buttonTakeTurn.Visible = true;
                //rule is met so computer's turn
                ComputerTurn();
            }
            else
            {
                MessageBox.Show("Rule is not met");
            }
        }

        /// <summary>
        /// draws the required cards, then plays the required cards
        /// </summary>
        private void ComputerTurn()
        {
            TakeTurn(computer1);
            ComputerPlayCard();
        }
       
        /// <summary>
        /// selects a card based on gameplay, then plays it
        /// </summary>
        private void ComputerPlayCard()
        {
            //check first which cards not to play
            computer1.DontPlayCards(human1);
            //We can select only one card so select from most important in terms of winning to least important
            if (computer1.FirstTest())
            {
                listBox2.Items.Add("Computer has played a goal card because it would then win the game");
            }
            else if (computer1.SecondTest(currentGoal))
            {
                listBox2.Items.Add("Computer has played Keeper card because it met part of the current goal");
            }         
            else if (computer1.ThirdTest())
            {           
                listBox2.Items.Add("Computer has played Keeper because it has a goal in its hand that requires that keeper");
            }         
            else
            {
                computer1.LastResort(currentGoal);
                listBox2.Items.Add("Computer played this card randomly but doesn't interfere with desired goal or help human goal");
            }
            //set current selected 
            currentSelected = computer1.HandList[computer1.Num];
            PlayCard(computer1);

            //if computer has met the rules, do nothing more
            if (computer1.CheckRules(computer1, b))
            {
            }
            //else play another card
            else
            {
                //if computer hasn't won
                if (computer1.CheckForWin(currentGoal) == false)
                {
                    ComputerPlayCard();
                }
            }
        }
        
    }
}
