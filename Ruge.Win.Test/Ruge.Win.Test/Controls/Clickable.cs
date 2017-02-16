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
        private string _backgroundIdle, _backgroundHover, _backgroundDown, _backgroundDisabled;
        private string _backgroundCurrent;

        private Image _innerImage = new Image();
        private double _width = 0;
        private double _height = 0;

        private double _idleScale = .95;
        private double _hoverScale = 1;
        private double _downScale = .90;

        public Clickable(string controlid, int width, int height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled, string tooltip) : base()
        {
            _width = (double)width;
            _height = (double)height;

            Children.Add(_innerImage);
            _innerImage.HorizontalAlignment = HorizontalAlignment.Center;
            _innerImage.VerticalAlignment = VerticalAlignment.Center;


            SetValue(WidthProperty, _width);
            SetValue(HeightProperty, _height);

            _innerImage.SetValue(WidthProperty, _width * _idleScale );
            _innerImage.SetValue(HeightProperty, _height * _idleScale );

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
            if (String.IsNullOrEmpty(_backgroundDown))
            {
                if (((UIElement)e.Source).IsMouseOver)
                { 
                
                    _innerImage.SetValue(WidthProperty, _width * _hoverScale);
                    _innerImage.SetValue(HeightProperty, _height * _hoverScale);
                }
                else
                {
                    _innerImage.SetValue(WidthProperty, _width * _idleScale);
                    _innerImage.SetValue(HeightProperty, _height * _idleScale);
                }
            }
            else
            {
                SetBackground(_backgroundIdle);
            }
        }

        private void Clickable_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(_backgroundHover))
            {
                _innerImage.SetValue(WidthProperty, _width * _idleScale);
                _innerImage.SetValue(HeightProperty, _height * _idleScale);
            }
            else
            {
                SetBackground(_backgroundIdle);
            }
        }

        private void Clickable_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetBackground();
        }

        private void Clickable_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (String.IsNullOrEmpty(_backgroundDown))
            {
                _innerImage.SetValue(WidthProperty, _width * _downScale);
                _innerImage.SetValue(HeightProperty, _height * _downScale);
            }
            else
            {
                SetBackground(_backgroundIdle);
            }
        }

        private void Clickable_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(_backgroundHover))
            {
                _innerImage.SetValue(WidthProperty, _width * _hoverScale);
                _innerImage.SetValue(HeightProperty, _height * _hoverScale);
            }
            else
            {
                SetBackground(_backgroundHover);
            }
        }

        private void SetBackground()
        {
            SetBackground(this._backgroundCurrent);
        }

        private void SetBackground(string imageUri)
        {
            if (String.IsNullOrEmpty(imageUri))
            {
                imageUri = "C:/data/ruge/Ruge.Win.Test/Ruge.Win.Test/placeholder.png";                            
            }

            if (IsEnabled)
                _backgroundCurrent = imageUri;
            else
                _backgroundCurrent = _backgroundDisabled;

            var bi = new BitmapImage(new Uri(_backgroundCurrent));

            _innerImage.Source = bi;
        }
    }
}
