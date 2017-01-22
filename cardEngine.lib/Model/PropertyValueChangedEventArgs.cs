using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardEngine.Model
{
    public class PropertyValueChangedEventArgs
    {
        public string PropertyName { get; private set; }
        public object OldValue { get; private set; }
        public object Newalue { get; private set; }

        public PropertyValueChangedEventArgs(string propertyName, object oldValue, object newValue)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            Newalue = newValue;
        }
    }
}

