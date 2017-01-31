namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Model;

    public partial class TableManager
    {
        public delegate void CardOrientationChangingEventHandler(object sender, CardEventArgs e);
        public delegate void CardOrientationChangedEventHandler(object sender, CardEventArgs e);
        public event CardOrientationChangingEventHandler CardOrientationChangingEvent;
        public event CardOrientationChangedEventHandler CardOrientationChangedEvent;

        public void ChangeOrientation(Orientations orientation)
        {
            add card logic, update rugecard library
        }
    }
}
