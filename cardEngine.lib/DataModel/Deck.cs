using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections.ObjectModel;

namespace ProCardLib.DataModel
{
    public class Deck
    {
        public Guid DeckId {get; protected set;}
        public string DeckName {get; set;}
        public List<Card> Cards {get; protected set;}
        public DeckOptions Options {get; set;}                           
        public Deck()
        {            
            this.Cards = new List<Card>();
            this.DeckId = Guid.NewGuid();         
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(DeckName);
            sb.Append(": ");

            foreach(var card in this.Cards)
            {
                sb.Append(card.DisplayValue);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
