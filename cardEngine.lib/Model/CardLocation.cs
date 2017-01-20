namespace CardEngine.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardLocation
    {
        public static Int16 MinX = 0;
        public static Int16 MinY = 0;
        public static Int16 MaxX = 1600;
        public static Int16 MaxY = 900;
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
        public Int16 Rotation { get; set; }
    }
}
