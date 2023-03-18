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

namespace WpfPetApp1 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        TwoWayData twoWayData = new TwoWayData() { height = 90};

        /// <summary>
        /// 主窗口
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            AddColorDicData();
            GetTwoWayData();
            WindowMove();
        }

        /// <summary>
        /// 双向绑定
        /// </summary>
        void GetTwoWayData() {
            DataContext = twoWayData;
            Grid.DataContext = twoWayData;
        }

        /// <summary>
        /// 鼠标拖动
        /// </summary>
        private void WindowMove() {
            MouseDown += delegate {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                    DragMove();
            };
        }

        #region 显示背景的隐藏和显示

        private Dictionary<string, Brush> colorDic = new Dictionary<string, Brush>();

        /// <summary>
        /// 添加颜色字典的数据
        /// </summary>
        void AddColorDicData() {
            colorDic.Add("显示背景", new SolidColorBrush(Colors.White));
            colorDic.Add("隐藏背景", new SolidColorBrush(Colors.Transparent));
        }

        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        private void itemBackground_Click(object sender, RoutedEventArgs e) {
            colorDic.TryGetValue(itemBackground.Header.ToString(), out Brush brush);
            if(brush != null) BorderMain.Background = brush;
            if (itemBackground.Header.ToString().Equals("显示背景")) itemBackground.Header = "隐藏背景";
            else itemBackground.Header = "显示背景";
        }

        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            if(itemBackground.Header.ToString().Equals("隐藏背景")) this.ResizeMode = ResizeMode.CanResizeWithGrip;

        }

        #endregion

    }
}
