﻿namespace Ruge.Win.Test
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
    using ruge.cardEngine;
    using JokerPoker1;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        JokerPoker _myGame = new JokerPoker();

        public MainWindow()
        {
          
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {          
            _myGame.Renderer.CanvasManager.EngineActionSetEvent += _canvasManager_EngineActionSetEvent;
            CANVAS.MouseDown += Clickable_MouseDown;
            _myGame.Start();
            
        }

        private void _canvasManager_EngineActionSetEvent(object sender, EngineActionSetEventArgs e)
        {
            foreach (var action in e.EngineActionSet.EngineActions)
            {
                if (action.ActionType == EngineActionType.Update)
                {
                    if (action.Element is ruge.lib.model.controls.Control)
                        RenderControl(action.Element as ruge.lib.model.controls.Control);

                    if (action.Element is ruge.lib.model.controls.Canvas)
                    {
                        RenderCanvas(action.Element as ruge.lib.model.controls.Canvas);
                    }
                }
                else
                {
                    if (action.Element is ruge.lib.model.controls.Control)
                        DeleteControl(action.Element as ruge.lib.model.controls.Control);
                }
            }
        }

        private void DeleteControl(ruge.lib.model.controls.Control control)
        {
            var clientControl = LogicalTreeHelper.FindLogicalNode(CANVAS, control.ElementId) as Clickable;
            CANVAS.Children.Remove(clientControl);
        }

        private void RenderCanvas(ruge.lib.model.controls.Canvas canvas)
        {
            CANVAS.SetValue(WidthProperty, canvas.Dimensions.X);
            CANVAS.SetValue(HeightProperty, canvas.Dimensions.Y);
            if (!String.IsNullOrEmpty(canvas.ImageUri))
            {
                SetValue(BackgroundProperty, new BitmapImage(new Uri(canvas.ImageUri)));
            }            
        }

        private void RenderControl(ruge.lib.model.controls.Control control)
        {
            if (control is TextControl)
            {
                var c = control as TextControl;
                var clientControl = new Text(
                            c.ElementId,
                            c.Size.X,
                            c.Size.Y,
                            c.Text,
                            200, 
                            200,
                            200 
                            );
                CANVAS.Children.Add(clientControl);
                clientControl.SetValue(LeftProperty, control.Location.X);
                clientControl.SetValue(TopProperty, control.Location.Y);                
            }

            if (control is ClickableControl)
            {
                var c = control as ClickableControl;
                var clientControl = LogicalTreeHelper.FindLogicalNode(CANVAS, c.ElementId) as Clickable;
                if (clientControl == null)
                {
                    clientControl = new Clickable(
                            c.ElementId,
                            c.Opacity,
                            c.Size.X,
                            c.Size.Y,
                            c.ImageUri,
                            c.ImageUriHover,
                            c.ImageUriDown,
                            c.ImageUriDisabled,
                            "",
                            c.ZIndex
                            );

                    CANVAS.Children.Add(clientControl);
                    clientControl.MouseDown += Clickable_MouseDown;
                }
                else
                {
                    clientControl.Name = c.ElementId;
                    clientControl.Opacity = c.Opacity;
                    clientControl.Width = c.Size.X;
                    clientControl.Height = c.Size.Y;
                    clientControl.ImageNormal = c.ImageUri;
                    clientControl.ImageHover = c.ImageUriHover;
                    clientControl.ImageDown = c.ImageUriDown;
                    clientControl.ImageDisabled = c.ImageUriDisabled;
                    clientControl.ToolTip = "";
                }
                                
                clientControl.SetValue(LeftProperty, control.Location.X);
                clientControl.SetValue(TopProperty, control.Location.Y);
               
            }

            if (control is StaticImageControl)
            {
                var c = control as StaticImageControl;
                var clientControl = new StaticImage(
                            c.ElementId,
                            c.Size.X,
                            c.Size.Y,
                            c.ImageUri
                            );
                CANVAS.Children.Add(clientControl);
                clientControl.SetValue(LeftProperty, control.Location.X);
                clientControl.SetValue(TopProperty, control.Location.Y);
            }

            if (control is TextInputControl)
            {
                var c = control as TextInputControl;
                var clientControl = new TextInput(
                    c.ElementId,
                    c.Size.X,
                    c.Size.Y,
                    c.ImageUri,
                    c.ImageUriHover,
                    c.ImageUriDown,
                    c.ImageUriDisabled,
                    c.Text
                );
                CANVAS.Children.Add(clientControl);
                clientControl.SetValue(TopProperty, control.Location.X);
                clientControl.SetValue(LeftProperty, control.Location.Y);

            }
        }

        private void Clickable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var control = sender as FrameworkElement;
            var userAction = new UserAction() { ControlId = control.Name, UserActionType = UserActionType.Click};
            var userActionSet = new UserActionSet();            
            userActionSet.UserActions.Add(userAction);
            _myGame.Renderer.CanvasManager.ReceiveUserActionSet(userActionSet);
            e.Handled = true;
        }
    }
}

