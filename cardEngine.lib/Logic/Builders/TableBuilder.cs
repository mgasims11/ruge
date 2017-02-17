using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardEngine.Model;

namespace CardEngine.Logic.FluentFactories
{
    public class TableMaker
    {
        private Table _table = null;

        public static TableMaker Create()
        {
            return new TableMaker();
        }

        public TableMaker()
        {
            _table = new Table();
        }

        public TableMaker ImageUri(string imageUri)
        {
            _table.ImageUri = imageUri;
            return this;
        }

        public TableMaker TableName(string tableName)
        {
            _table.TableName = tableName;
            return this;
        }

    }
}
