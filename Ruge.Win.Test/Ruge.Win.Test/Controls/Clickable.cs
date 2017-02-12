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
    public class Clickable : Image
    {
        private string _backgroundIdle, _backgroundHover, _backgroundDown, _backgroundDisabled;
        private string _backgroundCurrent;

        public Clickable(string controlid, int width, int height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled, string tooltip) : base()
        {

            SetValue(WidthProperty, (double)width);
            SetValue(HeightProperty, (double)height);
            Name = controlid;
            if (!String.IsNullOrEmpty(tooltip)) SetValue(ToolTipProperty, tooltip);
            MouseEnter += Clickable_MouseEnter;
            MouseDown += Clickable_MouseDown;
            MouseLeave += Clickable_MouseLeave;
            MouseUp += Clickable_MouseUp;
            IsEnabledChanged += Clickable_IsEnabledChanged;           

            _backgroundIdle = backgroundIdle;
            _backgroundHover = backgroundHover;
            _backgroundDown = backgroundDown;
            _backgroundDisabled = backgroundDisabled;

            SetBackground(backgroundIdle);            
        }

        private void Clickable_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetBackground(_backgroundIdle);
        }

        private void Clickable_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SetBackground(_backgroundIdle);
        }

        private void Clickable_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetBackground();
        }

        private void Clickable_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetBackground(_backgroundDown);
        }

        private void Clickable_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SetBackground(_backgroundHover);
        }

        private void SetBackground()
        {
            SetBackground(this._backgroundCurrent);
        }

        private void SetBackground(string imageUri)
        {
            if (String.IsNullOrEmpty(imageUri))
            {
                imageUri = @"C:/data/ruge/Ruge.Win.Test/Ruge.Win.Test/placeholder.bmp";
                            
            }

            if (IsEnabled)
                _backgroundCurrent = imageUri;
            else
                _backgroundCurrent = _backgroundDisabled;

            var bi = new BitmapImage(new Uri(_backgroundCurrent));
            SetValue(SourceProperty, bi);
        }
    }
}
