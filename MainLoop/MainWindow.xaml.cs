using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainLoop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
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
            GameLoop loop = new GameLoop();
            Sprite sprite = new Sprite();
            ObjectManager.Current.AddObject(sprite);
            loop.Init();
            loop.Start();
            GameBoard.Children.Add(sprite);
        }
    }

    public class Sprite : Border, IObjectloop
    {
        public void OnDestory()
        {

        }

        public void OnInit()
        {
            Background = new SolidColorBrush(Colors.Red);
            Height = Width = 5;
            CornerRadius = new CornerRadius(5);
            Canvas.SetLeft(this,200);
            Canvas.SetTop(this, 200);
        }

        public void OnRender()
        {
            MatrixTransform matrix = null;
            if (this.RenderTransform == null || !(this.RenderTransform is ScaleTransform))
            {
                matrix = new MatrixTransform();
                this.RenderTransform = matrix;
            }
            else
            {
                matrix = this.RenderTransform as MatrixTransform;
            }
            matrix.Matrix.Scale(1.1, 1.1);

            if (matrix.Matrix.M11 >= 10)
            {
                scale.ScaleX = scale.ScaleY = 1;
            }
        }

        public void OnStart()
        {

        }

        public void OnUpdate()
        {

        }
    }
}
