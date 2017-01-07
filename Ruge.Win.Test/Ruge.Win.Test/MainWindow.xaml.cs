namespace Ruge.Win.Test
{
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
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;
    using ruge.lib.model.user;
    using Ruge.Win.Test.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

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
          
        }

        private void _canvasManager_EngineActionEvent(object sender, EngineActionEventArgs e)
        {
            if (e is EngineCanvasActionEventArgs)
            {
                var o = (EngineCanvasActionEventArgs)e;
                switch (o.ActionType)
                {
                    case EngineActionType.Create:
                        MainCanvas.SetValue(WidthProperty, (double)o.Canvas.Dimensions.X);
                        MainCanvas.SetValue(HeightProperty, (double)o.Canvas.Dimensions.Y);
                        break;
                    case EngineActionType.Update:
                        MainCanvas.SetValue(WidthProperty, (double)o.Canvas.Dimensions.X);
                        MainCanvas.SetValue(HeightProperty, (double)o.Canvas.Dimensions.Y);
                        break;
                    case EngineActionType.Delete:
                        break;
                }
            }
            if (e is EngineControlActionEventArgs)
            {
                var o = (EngineControlActionEventArgs)e;
                switch (o.Control.ControlType)
                {
                    case ControlType.Clickable:
                        var clickable = 
                            new Clickable(
                                o.Control.ControlId,
                                o.Control.Size.X,
                                o.Control.Size.Y,
                                o.Control.VisualURIIdle,
                                o.Control.VisualURIHover,
                                o.Control.VisualURIDown,
                                o.Control.VisualURIDisabled
                                );
                        MainCanvas.Children.Add(clickable);
                        clickable.SetValue(TopProperty, (double)o.Control.Location.X);
                        clickable.SetValue(LeftProperty, (double)o.Control.Location.Y);

                        break;
                }
            }
                }
            }
        }

