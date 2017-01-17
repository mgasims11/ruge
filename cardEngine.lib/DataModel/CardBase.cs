using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class CardBase
    {
        public Guid CardId {get; private set;}
        public Orientations Orientation { get; set; }
        public Guid HomeDeckId { get; set; }
        public string DisplayValue { get; set; }
        public int Value {get;set;}
        public CardBase()
        {
            this.CardId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}
