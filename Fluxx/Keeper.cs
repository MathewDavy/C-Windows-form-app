using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fluxx
{
    class Keeper : Card
    {
        string _name;

        /// <summary>
        /// creates a keeper card
        /// </summary>
        /// <param name="nameOfCard"></param>
        /// <param name="bitmap"></param>
        public Keeper(string nameOfCard, Bitmap bitmap) : base(bitmap)
        {
            _name = nameOfCard;
        }

        public string NameOfCard
        {
            get { return _name; }
        }
    }
}
