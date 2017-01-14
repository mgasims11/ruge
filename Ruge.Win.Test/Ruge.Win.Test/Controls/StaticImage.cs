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
        private string _backgroundIdle;

        public StaticImage(string controlid, int width, int height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled, string tooltip) : base()
        {

            SetValue(WidthProperty, (double)width);
            SetValue(HeightProperty, (double)height);
            Name = controlid;

            _backgroundIdle = backgroundIdle;

            var bi = new BitmapImage(new Uri(_backgroundIdle));
            SetValue(SourceProperty, bi);
        }
    }
}
