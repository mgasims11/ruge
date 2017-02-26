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
        private double _idleScale = .97;
        private double _hoverScale = 1;
        private double _downScale = .94;
        private Canvas _innerImage = null;
        
        private string _imageCurrent;
        private string _imageNormal;
        private string _imageHover;
        private string _imageDown;
        private string _imageDisabled;

        public string ImageCurrent
        {
            get {return _imageCurrent; }
            set { _imageCurrent = value; }
        }
        public string ImageNormal
        {
            get { return _imageNormal; }
            set {
                _imageNormal = value;
                SetBackground(value);
            }
        }
        public string ImageHover
        {
            get { return _imageHover; }
            set { _imageHover = value; }
        }
        public string ImageDown
        {
            get { return _imageDown; }
            set { _imageDown = value; }
        }
        public string ImageDisabled
        {
            get { return _imageDisabled; }
            set { _imageDisabled = value; }
        }
        public new double Width
        {
            get { return base.Width; ; }
            set {
                base.Width = value;
                SetValue(WidthProperty, value);
            }
        }
        public new double Height
        {
            get { return base.Height; ; }
            set {
                base.Height = value;
                SetValue(HeightProperty, value);
            }
        }
        public new double Opacity
        {
            get { return (int)(base.Opacity * 100);}
            set
            {
                base.Opacity = value;
                SetValue(OpacityProperty, (double)value / 100);
            }
        }
        public Int32 ZIndex
        {
            get { return (Int32)base.GetValue(Canvas.ZIndexProperty); }
            set
            {
                SetValue(ZIndexProperty, value);
            }
        }
        public new string ToolTip
        {
            get { return base.ToolTip.ToString(); }
            set { base.ToolTip = value; }
        }

        public new string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public Clickable(string name, int opacity, double width, double height, string backgroundIdle, string backgroundHover, string backgroundDown, string backgroundDisabled, string tooltip, int zIndex) : base()
        {
            Width = width;
            Height = height;

            CreateCanvas();
            SetStateNormal();

            Name = name;

            if (!String.IsNullOrEmpty(tooltip)) SetValue(ToolTipProperty, tooltip);
            RegisterMouseEvents();

            IsEnabledChanged += Clickable_IsEnabledChanged;

            ImageNormal = backgroundIdle;
            ImageHover = backgroundHover;
            ImageDown = backgroundDown;
            ImageDisabled = backgroundDisabled;

            ZIndex = zIndex;
            SetBackground(ImageNormal);            
        }

        private void RegisterMouseEvents()
        {
            MouseEnter += Clickable_MouseEnter;
            MouseDown += Clickable_MouseDown;
            MouseLeave += Clickable_MouseLeave;
            MouseUp += Clickable_MouseUp;
        }

        private void CreateCanvas()
        {
            _innerImage = new Canvas();
            Children.Add(_innerImage);

            _innerImage.HorizontalAlignment = HorizontalAlignment.Center;
            _innerImage.VerticalAlignment = VerticalAlignment.Center;
        }

        private void SetStateNormal()
        {
            _innerImage.SetValue(WidthProperty, Width * _idleScale);
            _innerImage.SetValue(HeightProperty, Height * _idleScale);
        }

        private void SetStateHover()
        {
            _innerImage.SetValue(WidthProperty, Width * _hoverScale);
            _innerImage.SetValue(HeightProperty, Height * _hoverScale);
        }

        private void SetStateDown()
        {
            _innerImage.SetValue(WidthProperty, Width * _downScale);
            _innerImage.SetValue(HeightProperty, Height * _downScale);
        }

        private void Clickable_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (String.IsNullOrEmpty(ImageDown))
            {
                if (((UIElement)e.Source).IsMouseOver)
                {
                    SetStateHover();
                }
                else
                {
                    SetStateNormal();
                }
            }
            else
            {
                SetBackground(ImageNormal);
            }
        }

        private void Clickable_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(ImageHover))
            {
                SetStateNormal();
            }
            else
            {
                SetBackground(ImageNormal);
            }
        }

        private void Clickable_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetBackground();
        }

        private void Clickable_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (String.IsNullOrEmpty(ImageDown))
            {
                SetStateDown();
            }
            else
            {
                SetBackground(ImageNormal);
            }
        }

        private void Clickable_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (String.IsNullOrEmpty(ImageHover))
            {
                SetStateHover();
            }
            else
            {
                SetBackground(ImageHover);
            }
        }

        private void SetBackground()
        {
            SetBackground(ImageNormal);
        }

        private void SetBackground(string imageUri)
        {
            if (String.IsNullOrEmpty(imageUri))
            {
                imageUri = "C:/data/ruge/Ruge.Win.Test/Ruge.Win.Test/placeholder.png";                            
            }

            if (IsEnabled)
                ImageCurrent = imageUri;
            else
                ImageCurrent = ImageDisabled;

            var bi = new BitmapImage(new Uri(ImageCurrent));
            var ib = new ImageBrush(bi);
            _innerImage.Background = ib;
        }
    }
}
