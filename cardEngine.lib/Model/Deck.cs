﻿namespace CardEngine.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;
    using System.Collections.ObjectModel;

    public class Deck
    {
        public Guid DeckId {get; protected set;}
        public string DeckName {get; set;}
        public List<Card> Cards {get; protected set;}
        public DeckOptions Options {get; set;}

        public Deck()
        {            
            Cards = new List<Card>();
            DeckId = Guid.NewGuid();         
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
