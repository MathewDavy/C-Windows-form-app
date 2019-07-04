using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class NoLimits : Action
    {
        public NoLimits(Bitmap bitmap) : base(bitmap)
        {

        }

        public override void EnforceAction(Player player, Player playerOther, Deck d, Board b)
        {         
            for (int i = b.TableList.Count - 1; i > 0; i--)
            {
                //clears all rules bitmaps
                b.PaperTable.DrawImage(Properties.Resources.b3, b.TableList[i].XPos, b.TableList[i].YPos);
                //but only actually removes the hand and keeper limits
                if (b.TableList[i] is HandLimitRule || b.TableList[i] is KeeperLimitRule)
                {
                    b.TableList.RemoveAt(i);
                }
            }
            b.CumulativeXPosTable = b.RESETXPOS;
            //draws the remaining rules in the table list from start position
            for (int i = b.TableList.Count - 1; i > 0; i--)
            {
                b.TableList[i].XPos = b.CumulativeXPosTable;
                b.PaperTable.DrawImage(b.TableList[i].Bitmap, b.TableList[i].XPos, b.TableList[i].YPos);
                b.CumulativeXPosTable += b.CumulativeXPosTable;
            }
        }
    }
}
