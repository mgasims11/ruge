using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace Ruge.Win.Test.Controls
{
    public class Text : TextBlock
    {
        public Text(string controlid, int width, int height, string text) :base()
        {           
            SetValue(WidthProperty, (double)width);
            SetValue(HeightProperty, (double)height);
            SetValue(FontSizeProperty, new FontSizeConverter().ConvertFromString((height * .75).ToString() + "px"));

            Name = controlid;                                    
        }
    }
}
