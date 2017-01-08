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
    using FirstGame;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CanvasManager _canvasManager = null;


        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var myGame = new MyGame();
            _canvasManager.EngineActionSetEvent += _canvasManager_EngineActionSetEvent;
        }

        private void _canvasManager_EngineActionSetEvent(object sender, EngineActionSetEventArgs e)
        {
            foreach (var action in e.EngineActionSet.EngineActions)
            {
                if (action.ActionType == EngineActionType.Create || action.ActionType == EngineActionType.Update)
                {
                    Render(action.Control);
                }
            }
        }

        private void Render(ruge.lib.model.controls.Control control)
        {
            switch (control.ControlType)
            {
                case ControlType.Clickable:
                    var clickable =
                        new Clickable(
                            control.ControlId,
                            control.Size.X,
                            control.Size.Y,
                            control.VisualURIIdle,
                            control.VisualURIHover,
                            control.VisualURIDown,
                            control.VisualURIDisabled
                            );
                    MainCanvas.Children.Add(clickable);
                    clickable.SetValue(TopProperty, (double)control.Location.X);
                    clickable.SetValue(LeftProperty, (double)control.Location.Y);

                    break;
            }
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
        }
    }
}

