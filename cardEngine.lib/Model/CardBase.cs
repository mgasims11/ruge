namespace CardEngine.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel;

    public class CardBase : ModelBase
    {
        public Guid CardId
        {
            get { return GetGuidProperty("CardId"); }
            set { SetProperty("CardId", value); }
        }

        public Orientations Orientation
        {
            get { return (Orientations)GetIntProperty("Orientation"); }
            set { SetProperty("Orientation", value); }         
        }

        public Guid HomeDeckId
        {
            get { return GetGuidProperty("HomeDeckId"); }
            set { SetProperty("HomeDeckId", value); }
        }

        public Guid CurrentDeckId
        {
            get { return GetGuidProperty("CurrentDeckId"); }
            set { SetProperty("CurrentDeckId", value); }
        }

        public string DisplayValue
        {
            get { return GetStringProperty("DisplayValue"); }
            set { SetProperty("DisplayValue", value); }
        }

        public int Value
        {
            get { return GetIntProperty("Value"); }
            set { SetProperty("Value", value); }
        }

        public CardBase()
        {
            CardId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return DisplayValue;
        }

      
    }
}
