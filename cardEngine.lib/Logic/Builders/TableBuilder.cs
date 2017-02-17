using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardEngine.Model;

namespace CardEngine.Logic.Builders
{
    public static class TableBuilder
    {
        public static Table Create()
        {
            return new Table();
        }

        public static Table SetImageUri(this Table table, string imageUri)
        {
            table.ImageUri = imageUri;
            return table;
        }

        public static Table SetTableName(this Table table, string tableName)
        {
            table.TableName = tableName;
            return table;
        }

        public static Table SetDecks(this Table table, List<Deck> decks)
        {
            table.Decks = decks;
            return table;
        }

    }
}
