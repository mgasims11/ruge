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
        private string _backgroundIdle, _backgroundHover, _backgroundDown, _backgroundDisabled;
        private string _backgroundCurrent;

        public TextInput(string controlid, double width, double height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled, string text) :base()
        {           
            SetValue(WidthProperty, width);
            SetValue(HeightProperty, height);
            SetValue(BorderThicknessProperty, new Thickness(0, 0, 0, 0));
            SetValue(FontSizeProperty, new FontSizeConverter().ConvertFromString((height * .75).ToString() + "px"));
            SetValue(PaddingProperty, new Thickness(0, 0, 0, 0));
            SetValue(IsEnabledProperty, true);
            SetValue(ScrollViewer.PaddingProperty, new Thickness(0, 0, 0, 0));

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
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            SetInnerMargin();

        }
        private void TextInput_Initialized(object sender, EventArgs e)
        {
            SetInnerMargin();
        }

        private void SetInnerMargin()
        {
            var b = VisualTreeHelper.GetChild(this,0);
            var s = VisualTreeHelper.GetChild(b, 0);

            s.SetValue(PaddingProperty, new Thickness(0, 0, 0, 0));
            s.SetValue(MarginProperty, new Thickness(0, 0, 0, 0));
            b.SetValue(PaddingProperty, new Thickness(0, 0, 0, 0));
            b.SetValue(MarginProperty, new Thickness(0, 0, 0, 0));

            //VisualTreeHelper.
            //var contentHost = VisualTreeHelper.
            //if (contentHost != null && contentHost.Content != null && contentHost.Content is FrameworkElement)
            //{
            //    var textBoxView = contentHost.Content as FrameworkElement;
            //    textBoxView.Margin = new Thickness(0, 0, 0, 0);
            //}

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
                //SetValue(BackgroundProperty, bi);
            }
        }
    }
}
