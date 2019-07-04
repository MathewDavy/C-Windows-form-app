using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Fluxx
{
    abstract class Action : Card
    {      
        /// <summary>
        /// Creates a new action card
        /// </summary>
        /// <param name="bitmap"></param>
        public Action(Bitmap bitmap) : base(bitmap)
        {
            
        }

        /// <summary>
        /// Completes an action
        /// </summary>
        /// <param name="player"></param>
        /// <param name="paper"></param>
        /// <param name="d"></param>
        public abstract void EnforceAction(Player player, Player playerOther, Deck d, Board b);
       

    }
}
