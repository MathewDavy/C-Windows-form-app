using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;


namespace Fluxx
{
    class Deck
    {
        Random rand = new Random();
        private List<Card> _cardList;

        /// <summary>
        /// Holds all the cards in the game and deals to players
        /// </summary>
        public Deck()
        {
            _cardList = new List<Card>();
            AddKeeper();
            AddNewRule();
            AddGoal();
            AddAction();
            Shuffle();
        }

        public List<Card> CardList
        {
            get { return _cardList; }
            set { _cardList = value; }
        }

        /// <summary>
        /// Adds all the keepers to the deck
        /// </summary>
        public void AddKeeper()
        {
            //initialise array off image of each keeper
            Bitmap[] bArray = new Bitmap[]
            {
                Properties.Resources.The_Party,
                Properties.Resources.Cookies,
                Properties.Resources.Milk,
                Properties.Resources.The_Eye,
                Properties.Resources.The_Sun,
                Properties.Resources.The_Brain,
                Properties.Resources.The_Moon,
                Properties.Resources.Chocolate,
                Properties.Resources.Dreams,
                Properties.Resources.Time,
                Properties.Resources.Sleep,
                Properties.Resources.Music,
                Properties.Resources.The_Toaster,
                Properties.Resources.Money,
                Properties.Resources.The_Rocket,
                Properties.Resources.Television,
                Properties.Resources.Bread,
                Properties.Resources.Love,
                Properties.Resources.Peace,

            };
            //*add names of all the keepers from the embedded file so I don't have to add them individually
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Fluxx.Resources.Keepers.csv";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream); 
            //* https://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file/3314203

            //counter for selecting from bArray
            int i = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] csvArray = line.Split(',');
                Keeper k = new Keeper(csvArray[0], bArray[i]);
                _cardList.Add(k);
                i++;
            }          
        }

        /// <summary>
        /// adds all the NewRules to the deck
        /// </summary>
        public void AddNewRule()
        {
            //initialise array off image of each newRule
            Bitmap[] bArray = new Bitmap[]
            {
                Properties.Resources.Draw_2,
                Properties.Resources.Draw_3,
                Properties.Resources.Draw_4,
                Properties.Resources.Draw_5,
                Properties.Resources.Hand_Limit_0,
                Properties.Resources.Hand_Limit_1,
                Properties.Resources.Hand_Limit_2,
                Properties.Resources.Play_2,
                Properties.Resources.Play_3,
                Properties.Resources.Play_4,
                Properties.Resources.Keeper_Limit_2,
                Properties.Resources.Keeper_Limit_3,
                Properties.Resources.Keeper_Limit_4,
            };
            //*add names of all the NewRules from the embedded file so I don't have to add them individually
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Fluxx.Resources.New Rules.csv";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);
            int i = 0;
            int num = 0;
            RuleCard ruleToAdd;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] csvArray = line.Split(','); 
                //parses at index position 1 as index position 0 contains the name of the card which we dont need
                num = int.Parse(csvArray[1]);
                if (csvArray[0] == "Draw")
                {
                    ruleToAdd = new DrawRule(bArray[i], int.Parse(csvArray[1]));
                }
                else if (csvArray[0] == "Hand Limit")
                {
                    ruleToAdd = new HandLimitRule(bArray[i], int.Parse(csvArray[1]));
                }
                else if (csvArray[0] == "Play")
                {
                    ruleToAdd = new PlayRule(bArray[i], int.Parse(csvArray[1]));
                }
                else
                {
                    ruleToAdd = new KeeperLimitRule(bArray[i], int.Parse(csvArray[1]));
                }              
                _cardList.Add(ruleToAdd);
                i++;
            }
        }

        /// <summary>
        /// adds all the goals to the deck
        /// </summary>
        public void AddGoal()
        {
            //initialise array off image of each Goal
            Bitmap[] bArray = new Bitmap[]
            {
                Properties.Resources.Sleep___Music,
                Properties.Resources.Money___Love,
                Properties.Resources.Brain___Rocket,
                Properties.Resources.Party___Time,
                Properties.Resources.Milk___Cookies,
                Properties.Resources.Moon___Rocket,
                Properties.Resources.Cookies___Bread,
                Properties.Resources.Money___Television,
                Properties.Resources.Bread___Toaster,
                Properties.Resources._10_cards_in_hand,
                Properties.Resources._5_Keepers
            };

            //*add names of all the Goals from the embedded file so I don't have to add them individually
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Fluxx.Resources.Goals.csv";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            StreamReader reader = new StreamReader(stream);
            int i = 0;           
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] csvArray = line.Split(',');
                string[] temp = csvArray[0].Split('+');
                string keeper1 = temp[0].Trim();
                string keeper2 = temp[1].Trim();        
              
                GoalKeeperType g = new GoalKeeperType(bArray[i], keeper1, keeper2);
                _cardList.Add(g);
                i++;
            }
            //only two types for this type of goal so just do it manually
            GoalNumber gNum = new GoalNumber(bArray[bArray.Length - 2], false, 10);
            _cardList.Add(gNum);
            GoalNumber gNum1 = new GoalNumber(bArray[bArray.Length - 1], true, 5);
            _cardList.Add(gNum1);
        }

        /// <summary>
        /// adds all the action cards to the deck
        /// </summary>
        public void AddAction()
        {
            //each action is a whole new class due to the differences in what their action does. It's easier just to create them manually
            DiscardAllRules d = new DiscardAllRules( Properties.Resources.Discard_all_rules);
            Draw3Cards d1 = new Draw3Cards(Properties.Resources.Draw_3_cards);
            DiscardAndDraw d2 = new DiscardAndDraw( Properties.Resources.Discard_hand__Draw_number_of_cards_discarded);
            NoLimits n = new NoLimits(Properties.Resources.Remove_keeper___hand_limits);
            TradeHands t = new TradeHands(Properties.Resources.Trade_Hands);

            _cardList.Add(d);
            _cardList.Add(d1);
            _cardList.Add(d2);
            _cardList.Add(n);
            _cardList.Add(t);
        }

        /// <summary>
        /// shuffles deck
        /// </summary>
        public void Shuffle()
        {
            //swaps each card with a random card at element k starting rom the end
            for (int i = _cardList.Count - 1; i > 0; --i)
            {
                int k = rand.Next(i + 1);
                Card temp = _cardList[i];
                _cardList[i] = _cardList[k];
                _cardList[k] = temp;
            }
        }
 
        /// <summary>
        /// adds a specified number of cards to the player's hand
        /// </summary>
        /// <param name="player"></param>
        /// <param name="num"></param>
        public void DealCard(Player player, int num)
        {
            for (int i = 0; i < num; i++)
            {
                //only deal a card if there are enough cards
                if (_cardList.Count > 0)
                {
                    //adds "top" card to hand
                    player.AddToHand(_cardList[_cardList.Count - 1]);
                    if (_cardList[_cardList.Count - 1] is Keeper)
                    {
                        player.NumOfKeepersInHand++;
                    }
                    //remove that card from the deck
                    _cardList.RemoveAt(_cardList.Count - 1);
                    player.NumInHand++;
                    player.NumOfDraws++;
                }              
                else
                {
                    MessageBox.Show("There are no more cards in the deck");
                    break;
                }
            }         
        }
    }
}
