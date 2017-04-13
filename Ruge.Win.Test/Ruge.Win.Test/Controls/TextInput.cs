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
        private string _backgroundIdle, _backgroundHover, _backgroundDown, _backgroundDisabled;
        private string _backgroundCurrent;

        public TextInput(string controlid, double width, double height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled, string text) :base()
        {
           
            var textBox = new TextBox();

            Stretch = Stretch.Fill;
            textBox.FontWeight = FontWeights.Bold;            
            textBox.BorderThickness = new Thickness(0, 0, 0, 0);

            textBox.MaxLength = 10;
            textBox.FontSize = 10;
            textBox.Width = 20 * width;           

            textBox.SetValue(IsEnabledProperty, true);
            Width = width;
            Height = height;

            Name = controlid;
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
            this.Child = textBox;            
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
            if (!String.IsNullOrEmpty(imageUri))
            {
                if (IsEnabled)
                    _backgroundCurrent = imageUri;
                else
                    _backgroundCurrent = _backgroundDisabled;

                var bi = new BitmapImage(new Uri(_backgroundCurrent));
                
            }
        }
    }
}
