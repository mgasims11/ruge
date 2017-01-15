using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ruge.Win.Test.Controls
{
    public class StaticImage : Image
    {
        public StaticImage(string controlid, int width, int height, string imageUri) : base()
        {
            Name = controlid;
            SetValue(WidthProperty, (double)width);
            SetValue(HeightProperty, (double)height);
            SetValue(SourceProperty, new BitmapImage(new Uri(imageUri)));
        }
    }
}
