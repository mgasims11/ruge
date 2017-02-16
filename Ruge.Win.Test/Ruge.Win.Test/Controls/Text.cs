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
        public Text(string controlid, double width, double height, string text,byte r, byte g, byte b) :base()
        {           
            SetValue(WidthProperty, width);
            SetValue(HeightProperty, height);
            SetValue(TextProperty, text);
            SetValue(FontSizeProperty, new FontSizeConverter().ConvertFromString((height * .75).ToString() + "px"));
            SetValue(PaddingProperty, new Thickness(0, 0, 0, 0));
            SetValue(MarginProperty, new Thickness(0, 0, 0, 0));

            var color = new Color();
            color.R = r;
            color.G = g;
            color.B = b;
            color.A = 255;

            this.Background = new SolidColorBrush(color);
            Name = controlid;                                    
        }
    }
}
