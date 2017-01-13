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
    using ruge.lib.model.controls.interfaces;
    using Ruge.Win.Test.Controls;
    using FirstGame;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyGame _myGame = new MyGame();

        public MainWindow()
        {            
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _myGame.CanvasManager.EngineActionSetEvent += _canvasManager_EngineActionSetEvent;
            _myGame.CanvasManager.EngineActionEvent += CanvasManager_EngineActionEvent;
            _myGame.Start();            
        }

        private void CanvasManager_EngineActionEvent(object sender, EngineActionEventArgs e)
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

        private void Render(IControl control)
        {
            if (control is ClickableControl)
            {
                var ClickableControl = control as ClickableControl;
                var clickable = new Clickable(
                            control.ControlId,
                            control.Size.X,
                            control.Size.Y,
                            control.ImageUri,
                            ClickableControl.ImageUriHover,
                            ClickableControl.ImageUriDown,
                            ClickableControl.ImageUriDisabled,
                            ""
                            );
                MainCanvas.Children.Add(clickable);
                clickable.SetValue(TopProperty, (double)control.Location.X);
                clickable.SetValue(LeftProperty, (double)control.Location.Y);
                clickable.MouseDown += Clickable_MouseDown;
            }

            if (control is TextInputControl)
            {
                var textInputControl = control as TextInputControl;
                var textInput = new TextInput(
                    control.ControlId,
                    control.Size.X,
                    control.Size.Y,
                    control.ImageUri,
                    textInputControl.ImageUriHover,
                    textInputControl.ImageUriDown,
                    textInputControl.ImageUriDisabled,
                    textInputControl.Text
                );
                MainCanvas.Children.Add(textInput);
                textInput.SetValue(TopProperty, (double)control.Location.X);
                textInput.SetValue(LeftProperty, (double)control.Location.Y);

            }
        }

        private void Clickable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as Clickable;
            var userAction = new UserAction() { ControlId = control.Name, UserActionType = UserActionType.Click};
            var userActionSet = new UserActionSet();            
            userActionSet.UserActions.Add(userAction);
            _myGame.CanvasManager.ReceiveUserActionSet(userActionSet);            
        }
    }
}

