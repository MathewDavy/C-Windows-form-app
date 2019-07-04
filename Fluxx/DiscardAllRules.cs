using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class DiscardAllRules : Action
    {
        
        public DiscardAllRules(Bitmap bitmap) : base(bitmap)
        {

        }

        public override void EnforceAction(Player player, Player playerOther, Deck d, Board b)
        {
            //clears all rules on table
            for (int i = b.TableList.Count - 1; i > 0; i--)
            {            
                b.PaperTable.DrawImage(Properties.Resources.b3, b.TableList[i].XPos, b.TableList[i].YPos);
                b.TableList.RemoveAt(i);
                b.CumulativeXPosTable = b.RESETXPOS;
            }
        }
    }
}
