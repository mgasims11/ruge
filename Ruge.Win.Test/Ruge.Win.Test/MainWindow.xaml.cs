using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ruge.lib;
using ruge.lib.logic;
using ruge.lib.model;

namespace Ruge.Win.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CanvasManager _canvasManager;
        private double _snapX, _snapY;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Test();
        }

        private void Test()
        {
            _canvasManager = new CanvasManager();
            _canvasManager.EngineActionEvent += _canvasManager_EngineActionEvent;
            _canvasManager.CreateCanvas(20, 20);
            _canvasManager.AddControl(ControlType.Clickable, 1, 1, 0, 0, "https://b.fastcompany.net/multisite_files/fastcompany/imagecache/inline-small/inline/2015/09/3050613-inline-i-2-googles-new-logo-copy.png", "");
            //_canvasManager.AddControl(ControlType.Clickable, 10, 10, 2, 2, "https://b.fastcompany.net/multisite_files/fastcompany/imagecache/inline-small/inline/2015/09/3050613-inline-i-2-googles-new-logo-copy.png", "");
        }

        private void _canvasManager_EngineActionEvent(object sender, EngineActionEventArgs e)
        {
            if (e is EngineCanvasActionEventArgs)
            {
                var o = (EngineCanvasActionEventArgs)e;
                switch (o.ActionType)
                {
                    case ActionType.Create:
                        MainCanvas.SetValue(WidthProperty, (double)o.Canvas.Dimensions.X);
                        MainCanvas.SetValue(HeightProperty, (double)o.Canvas.Dimensions.Y);
                        break;
                    case ActionType.Update:
                        MainCanvas.SetValue(WidthProperty, (double)o.Canvas.Dimensions.X);
                        MainCanvas.SetValue(HeightProperty, (double)o.Canvas.Dimensions.Y);
                        break;
                    case ActionType.Delete:
                        break;
                }
            }
            if (e is EngineControlActionEventArgs)
            {
                var o = (EngineControlActionEventArgs)e;
                switch (o.Control.ControlType)
                {
                    case ControlType.Clickable:
                        var b = new Button();
                        b.SetValue(WidthProperty, (double)o.Control.Size.X);
                        b.SetValue(HeightProperty, (double)o.Control.Size.Y);
                        b.SetValue(TopProperty, (double)o.Control.Location.X);
                        b.SetValue(LeftProperty, (double)o.Control.Location.Y);
                        b.Name = 'C' + o.Control.ControlId.ToString().Replace("-","");
                        b.BorderThickness = new Thickness(0.0);
                        ImageBrush ib = new ImageBrush();
                        ib.ImageSource = new BitmapImage(new Uri(o.Control.VisualURI));
                        b.SetValue(BackgroundProperty, ib);

                        MainCanvas.Children.Add(b);
                        break;
                    case ControlType.Text:
                     
                        break;
                }
            }
        }
    }
}
