using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Fluxx
{
    abstract class Goal : Card
    {     
        public Goal(Bitmap bitmap) : base(bitmap)
        {
            
        }

        /// <summary>
        /// checks the goal passed in to see if the player has won
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public abstract bool CheckForWin(Goal goal, Player player);
    }
}
