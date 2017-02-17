namespace CardEngine.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    public class Table
    {
        public Guid TableId {get; protected set;}
        public string TableName {get; set;}
        public List<Deck> Decks {get; set;}
        public string ImageUri { get; set; }
        public Table()
        {
            this.Decks = new List<Deck>();
            this.TableId = Guid.NewGuid();        
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var deck in this.Decks)
            {
                sb.AppendLine(deck.ToString());
            }
            return sb.ToString();
        }
    }
}
