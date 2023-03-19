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

namespace WpfApp1
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfApp1"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfApp1;assembly=WpfApp1"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:SingnalLight/>
    ///
    /// </summary>
    public class SingnalLight : Control
    {
        

        


        static SingnalLight()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SingnalLight), new FrameworkPropertyMetadata(typeof(SingnalLight)));
        }
    }
    public class DevButton : Control
    {

        public DevButton()
        {
            SetCurrentValue(WidthProperty, 100d);
            SetCurrentValue(HeightProperty, 25d);
            SetCurrentValue(BackgroundProperty, Brushes.Yellow);
        }
        static DevButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DevButton), new FrameworkPropertyMetadata(typeof(DevButton)));
        }
        private Rectangle statusLed;
        private Button devBtn;
        public override void OnApplyTemplate()
        {
            statusLed = GetTemplateChild("statusLed") as Rectangle;
            devBtn = GetTemplateChild("devBtn") as Button;
            devBtn.Click += DevBtn_Click;
            base.OnApplyTemplate();
        }

        #region 自定义属性
        public int DevId
        {
            get { return (int)GetValue(DevIdProperty); }
            set { SetValue(DevIdProperty, value); }
        }
        public static readonly DependencyProperty DevIdProperty =
          DependencyProperty.Register("DevId", typeof(int), typeof(DevButton), new FrameworkPropertyMetadata(-1, new PropertyChangedCallback(OnDevIdChanged)));
        private static void OnDevIdChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DevButton ctrl = (DevButton)sender;
            ctrl.DevId = (int)e.NewValue;
        }

        public string DevName
        {
            get { return (string)GetValue(DevNameProperty); }
            set { SetValue(DevNameProperty, value); }
        }
        public static readonly DependencyProperty DevNameProperty =
        DependencyProperty.Register("DevName", typeof(string), typeof(DevButton), new FrameworkPropertyMetadata("", new PropertyChangedCallback(OnDevNameChanged)));
        private static void OnDevNameChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DevButton ctrl = sender as DevButton;
            ctrl.DevName = e.NewValue.ToString();
        }

        public int DevStatus
        {
            get { return (int)GetValue(DevStatusProperty); }
            set
            {
                SetValue(DevStatusProperty, value);
            }
        }
        public static readonly DependencyProperty DevStatusProperty =
          DependencyProperty.Register("DevStatus", typeof(int), typeof(DevButton), new FrameworkPropertyMetadata(-1, new PropertyChangedCallback(OnDevStatusChanged)));
        private static void OnDevStatusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DevButton ctrl = (DevButton)sender;
            ctrl.DevStatus = (int)e.NewValue;
            ctrl.StatusBrush = (ctrl.DevStatus > 0) ? Brushes.Green : Brushes.LightGray;
        }

        public Brush StatusBrush
        {
            get { return (Brush)GetValue(StatusBrushProperty); }
            set
            {
                SetValue(StatusBrushProperty, value);
            }
        }
        public static readonly DependencyProperty StatusBrushProperty =
        DependencyProperty.Register("StatusBrush", typeof(Brush), typeof(DevButton), new FrameworkPropertyMetadata(Brushes.LightGray));

        #endregion


        private void DevBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DevName);

        }

    }


}
