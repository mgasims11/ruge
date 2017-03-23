
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
    public class ClickableImaged : Clickable
    {
        public string ImageNormal { get; set; }
        public string ImageHover { get; set; }
        public string ImageDown { get; set; }
        public string ImageDisabled { get; set; }
        
        public ClickableImaged(string name, int opacity, double width, double height, string image, string imageHover, string imageDown, string imageDisabled, int zIndex, bool isEnabled) : base(name, opacity, width, height, image, zIndex, isEnabled)
        {
            ImageNormal = image;
            ImageHover = imageHover;
            ImageDown = imageDown; ;

            Image = ImageNormal;

            MouseEnter += ClickableSized_MouseEnter;
            MouseLeave += ClickableSized_MouseLeave;
            MouseDown += ClickableSized_MouseDown;
            MouseUp += ClickableSized_MouseUp;
        }

        private void ClickableSized_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseOver)
                Image = ImageHover;
            else
                Image = ImageNormal;
        }

        private void ClickableSized_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image = ImageDown;
        }

        private void ClickableSized_MouseLeave(object sender, MouseEventArgs e)
        {
            Image = ImageNormal;
        }

        private void ClickableSized_MouseEnter(object sender, MouseEventArgs e)
        {
            Image = ImageHover;
        }
    }
}

