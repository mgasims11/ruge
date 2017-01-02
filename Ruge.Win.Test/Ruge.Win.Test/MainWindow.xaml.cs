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

        public MainWindow()
        {
            InitializeComponent();
            _canvasManager = new CanvasManager();
            _canvasManager.EngineActionEvent += _canvasManager_EngineActionEvent;
            _canvasManager.CreateCanvas(1920, 1280);
            _canvasManager.AddControl(ControlType.Clickable, 100, 200, 23, 34, "ack", "");

    }

        private void _canvasManager_EngineActionEvent(object sender, EngineActionEventArgs e)
        {

        }
    }
}
