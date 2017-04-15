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
        protected TextBox InnerTextBox = new TextBox();

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

        public string Text
        {
            get
            {
                return InnerTextBox.Text;
            }
            set
            {
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
                        InnerTextBox.Width = InnerTextBox.Height * bi.Width / bi.Height;
                    if (Height == 0)
                        InnerTextBox.Height = InnerTextBox.Width * bi.Height / bi.Width;
                }
            }
        }
        public TextInput(string name, int opacity, double width, double height, string image, int zIndex, bool isEnabled, string text) : base()
        {

            Stretch = Stretch.Fill;
            InnerTextBox.FontWeight = FontWeights.Bold;
            InnerTextBox.BorderThickness = new Thickness(0, 0, 0, 0);

            InnerTextBox.MaxLength = 10;
            InnerTextBox.FontSize = 10;
            InnerTextBox.Width = 20 * width;

            InnerTextBox.SetValue(IsEnabledProperty, true);
            Width = width;
            Height = height;

            Name = name;

            this.Child = InnerTextBox;
        }
    } 
}
