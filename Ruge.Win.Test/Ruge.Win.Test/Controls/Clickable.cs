﻿using System;
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
    public class Clickable : Button
    {
        private string _backgroundIdle, _backgroundHover, _backgroundDown, _backgroundDisabled;
        private string _backgroundCurrent;

        public Clickable(Guid guid, int width, int height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled)
        {
            SetValue(WidthProperty, (double)width);
            SetValue(HeightProperty, (double)height);           
            Name = 'C' + guid.ToString().Replace("-", "");
            BorderThickness = new Thickness(0.0);
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

        private void SetBackground(string imageUrl)
        {
            if (IsEnabled)
                _backgroundCurrent = imageUrl;
            else
                _backgroundCurrent = _backgroundDisabled;

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(_backgroundCurrent));
            SetValue(BackgroundProperty, ib);
        }
    }
}
