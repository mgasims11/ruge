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
    public class StaticImage : Image
    {

        public Int32 ZIndex
        {
            get { return (Int32)base.GetValue(Canvas.ZIndexProperty); }
            set
            {
                SetValue(Canvas.ZIndexProperty, value);
            }
        }

        public string ImageUri
        {
            get
            {
                return (GetValue(SourceProperty) as BitmapImage).BaseUri.OriginalString;
            }
            set
            {
                SetValue(SourceProperty, new BitmapImage(new Uri(value)));
            }
        }

        public StaticImage(string controlid, double width, double height, string imageUri, int zIndex) : base()
        {
            Name = controlid;
            SetValue(WidthProperty, width);
            SetValue(HeightProperty, height);
            ImageUri = imageUri;
            ZIndex = zIndex;
        }
    }
}
