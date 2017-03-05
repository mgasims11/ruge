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
    public class Clickable : Grid
    {

        Image _image;

        public new double Opacity
        {
            get { return (int)(base.Opacity * 100);}
            set
            {
                base.Opacity = value;
                SetValue(OpacityProperty, (double)value / 100);
            }
        }

        public int ZIndex
        {
            get { return (int)GetValue(Canvas.ZIndexProperty); }
            set { SetValue(Canvas.ZIndexProperty, value); }
        }

        public string Image
        {
            get { return ((BitmapImage)_image.Source).UriSource.AbsoluteUri; }
            set
            {
                if (_image == null)
                {
                    _image = new System.Windows.Controls.Image();
                    Children.Add(_image);
                }
                _image.Source = new BitmapImage(new Uri(value));
            }
        }

        public Clickable(string name, int opacity, double width, double height, string image, int zIndex, bool isEnabled) : base()
        {
            Name = name;
            Width = width;
            Height = height;
            ZIndex = zIndex;            
            IsEnabled = isEnabled;
            Image = image;
        }
    }
}
