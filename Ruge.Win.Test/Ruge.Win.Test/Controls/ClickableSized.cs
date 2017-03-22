using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ruge.Win.Test.Controls
{
    public class ClickableSized : Clickable
    {
        public double NormalScale { get; set; } // .97;
        public double HoverScale { get; set; } // _hoverScale = 1;
        public double DownScale { get; set; } // .94

        public ClickableSized(string name, int opacity, double width, double height, string image, int zIndex, bool isEnabled) : base(name, opacity, width, height, image, zIndex, isEnabled)
        {
            IsEnabledChanged += ClickableSized_IsEnabledChanged;

            NormalScale = .97;
            HoverScale = 1;
            DownScale = .94;

            InnerCanvas.SetValue(WidthProperty, Width * NormalScale);
            InnerCanvas.SetValue(HeightProperty, Height * NormalScale);

            MouseEnter += ClickableSized_MouseEnter;
            MouseLeave += ClickableSized_MouseLeave;
            MouseDown += ClickableSized_MouseDown;
            MouseUp += ClickableSized_MouseUp;
        }

        private void ClickableSized_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseOver)
            {
                InnerCanvas.SetValue(WidthProperty, Width * HoverScale);
                InnerCanvas.SetValue(HeightProperty, Height * HoverScale);
            }
            else
            {
                InnerCanvas.SetValue(WidthProperty, Width * NormalScale);
                InnerCanvas.SetValue(HeightProperty, Height * NormalScale);
            }
        }

        private void ClickableSized_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InnerCanvas.SetValue(WidthProperty, Width * DownScale);
            InnerCanvas.SetValue(HeightProperty, Height * DownScale);
        }

        private void ClickableSized_MouseLeave(object sender, MouseEventArgs e)
        {
            InnerCanvas.SetValue(WidthProperty, Width * NormalScale);
            InnerCanvas.SetValue(HeightProperty, Height * NormalScale);
        }

        private void ClickableSized_MouseEnter(object sender, MouseEventArgs e)
        {
            InnerCanvas.SetValue(WidthProperty, Width * HoverScale);
            InnerCanvas.SetValue(HeightProperty, Height * HoverScale);
        }

        private void ClickableSized_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
                InnerCanvas.SetValue(OpacityProperty, .6);
            else
                InnerCanvas.SetValue(OpacityProperty, 1);
        }

         private void CreateCanvas()
        {
            InnerCanvas = new Canvas();
            Children.Add(InnerCanvas);

            InnerCanvas.HorizontalAlignment = HorizontalAlignment.Center;
            InnerCanvas.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
