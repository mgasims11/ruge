using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ProCardLib.DataModel
{
    public class Table
    {
        public Guid TableId {get; protected set;}
        public string TableName {get; protected set;}
        public List<Deck> Decks {get; protected set;}
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
