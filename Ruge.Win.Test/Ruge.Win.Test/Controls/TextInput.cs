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
    public class TextInput : Viewbox
    {
        private TextBox InnerTextBox = new TextBox();

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
      
        public int MaxLength
        {
            get
            {
                return InnerTextBox.MaxLength;
            }
            set
            {
                InnerTextBox.MaxLength = value;
            }
        }

        public new double Height
        {
            get {
                return base.Height;
            }
            set
            {
                //base.Height = value;
                //InnerTextBox.Height = base.Height / base.Width * 1000;               
            }
        }

        public new double Width
        {
            get {
                return base.Width;
            }
            set {
                base.Width = value;
                InnerTextBox.Width = 1000;
            }
        }

        public double FontSize
        {
            get {
                return InnerTextBox.FontSize * 4;
            }
            set {
                InnerTextBox.FontSize = value * 4;

            }
        }

        public string Text
        {
            get
            {
                return InnerTextBox.Text;
            }
            set {
                InnerTextBox.Text = value;
            }
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
                    InnerTextBox.Background = new ImageBrush(bi);
                    if (Width == 0)
                        Width = Height * bi.Width / bi.Height;
                    if (Height == 0)
                        Height = Width * bi.Height / bi.Width;
                }
            }
        }
        public TextInput(string name, int opacity, double width, double height, string image, int zIndex, bool isEnabled, string text, double fontSize, int maxLength) : base()
        {
            Child = InnerTextBox;
            Stretch = Stretch.Fill;
            Width = width;
            //Height = height;
            InnerTextBox.Margin = new Thickness(0, 0, 0, 0);
            InnerTextBox.Padding = new Thickness(0, 0, 0, 0);
            InnerTextBox.FontWeight = FontWeights.Bold;
            InnerTextBox.BorderThickness = new Thickness(0, 0, 0, 0);
            InnerTextBox.MaxLength = 10;
            InnerTextBox.FontSize = 10;
            SetValue(IsEnabledProperty, true);
            Name = name;
            InnerTextBox.FontSize = fontSize;
            InnerTextBox.MaxLength = maxLength;            
        }
    } 
}
