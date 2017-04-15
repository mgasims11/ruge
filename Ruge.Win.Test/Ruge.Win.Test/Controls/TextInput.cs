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
    public class TextInput : TextBox
    {

        public new double Opacity
        {
            get { return (int)(base.Opacity * 100); }
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
      
        private string _image = "";

        public string Image
        {
            set
            {

                if (value != null && _image != value)
                {
                    _image = value;
                    var bi = new BitmapImage(new Uri(value));
                    Background = new ImageBrush(bi);
                    if (Width == 0)
                        Width = Height * bi.Width / bi.Height;
                    if (Height == 0)
                        Height = Width * bi.Height / bi.Width;
                }
            }
        }
        public TextInput(string name, int opacity, double width, double height, string image, int zIndex, bool isEnabled, string text, double fontSize, int maxLength) : base()
        {
            Width = width;
            Height = height;
            Margin = new Thickness(0, 0, 0, 0);
            Padding = new Thickness(0, 0, 0, 0);
            FontWeight = FontWeights.Bold;
            BorderThickness = new Thickness(0, 0, 0, 0);
            MaxLength = 10;
            FontSize = 10;
            SetValue(IsEnabledProperty, true);
            Name = name;
            FontSize = fontSize;
            MaxLength = maxLength;            
        }
    } 
}
