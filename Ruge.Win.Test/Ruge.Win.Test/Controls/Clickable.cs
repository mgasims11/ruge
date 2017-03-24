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
        protected Canvas InnerCanvas = new Canvas();

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
            set
            {
                var bi = new BitmapImage(new Uri(value));
                InnerCanvas.Background = new ImageBrush(bi);
                if (Width == 0)
                    InnerCanvas.Width = InnerCanvas.Height * bi.Width / bi.Height;
                if (Height == 0)
                    InnerCanvas.Height = InnerCanvas.Width * bi.Height / bi.Width;
            }
        }

        public Clickable(string name, int opacity, double width, double height, string image, int zIndex, bool isEnabled) : base()
        {
            Name = name;
            Width = width;
            Height = height;
            InnerCanvas.Width = width;
            InnerCanvas.Height = height;
            ZIndex = zIndex;            
            IsEnabled = isEnabled;
            Image = image;

            Children.Add(InnerCanvas);

            IsEnabledChanged += OnIsEnabledChanged;

        }

        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
                InnerCanvas.SetValue(OpacityProperty, .6);
            else
                InnerCanvas.SetValue(OpacityProperty, 1.0);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == WidthProperty || e.Property == HeightProperty)
            { }
            base.OnPropertyChanged(e);
        }
    }
}
