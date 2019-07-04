using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    abstract class RuleCard : Card
    {      
        //every RuleCard has a number
        protected int _num;

        public RuleCard(Bitmap bitmap, int num) : base(bitmap)
        {
            _num = num;
        }

        public int Num
        {
            get { return _num; }
        }

        /// <summary>
        /// Checks if the player has met this rule
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public abstract bool CheckRule(Player player);
    }
}
