using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CardEngine.Model
{
    public class ModelBase
    {
        protected Dictionary<string, object> PropertyBag = new Dictionary<string, object>();

        public delegate void PropertyValueChangedEventHandler(object sender, PropertyValueChangedEventArgs args);
        public event PropertyValueChangedEventHandler PropertyValueChangedEvent;

        protected string GetStringProperty(string propertyName)
        {
            return GetProperty(propertyName) as string;
        }

        protected int GetIntProperty(string propertyName)
        {
            return (int)GetProperty(propertyName);
        }

        protected Guid GetGuidProperty(string propertyName)
        {
            return (Guid)GetProperty(propertyName);
        }

        protected object GetProperty(string propertyName)
        {
            if (PropertyBag.ContainsKey(propertyName))
                return PropertyBag[propertyName];
            else
                return null;
        }

        protected void SetProperty(string propertyName, object value)
        {
            if (!PropertyBag.ContainsKey(propertyName))
            {
                PropertyBag.Add(propertyName, value);
                RaisePropertyChanged(propertyName, null, value);
            }
            else
            {
                var oldValue = PropertyBag[propertyName];
                PropertyBag[propertyName] = value;
                RaisePropertyChanged(propertyName, oldValue, value);
            }
        }

        protected void RaisePropertyChanged(string propertyName, object oldValue, object newValue)
        {
            if (PropertyValueChangedEvent != null)
            {
                PropertyValueChangedEvent(this, new PropertyValueChangedEventArgs(propertyName, oldValue, newValue));
            }
        }
    }
}
