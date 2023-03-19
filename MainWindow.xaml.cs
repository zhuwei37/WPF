using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.DAL;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            using (var context = new DataClasses1DataContext())
            {
                
                var query=from  stu in context.student
                          join sco in context.score 
                          on stu.Student_ID equals sco.Student_ID
                           select new { stu.Name,sco.Score1};
                
                foreach (var q in query)
                {
                    Console.WriteLine(q.Name+"="+q.Score1);
                }
                

            }


            //    object[] values = { "a", "b", "c", "d", "e" };
            //IterationSample sample = new IterationSample(values, 3);
            //foreach (object x in sample)
            //{
            //    Console.WriteLine(x);
            //    foreach (object a in sample)
            //    {
            //        Console.WriteLine(a);
            //    }
            //}
            //List<string> ss = new List<string>();
            //List<string> vs = new List<string>() { "dsd", "dsdsa", "dsd", "dsds", "dsdf" };
            //var query = from v in(from vv in vs 
            //                      select vv)
            //            select v;
            //int[] b = new int[4];

            //IEnumerator<string> iterator = query.GetEnumerator();

            //iterator.MoveNext();
            //foreach (var q in query)
            //{
            //    Console.WriteLine(q);
            //}
            InitializeComponent();

            //t = new ObservableCollection<list>();
          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
           
          
        }

        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {
            int n;
            n = 10;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n;
            n = 10;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainViewModel.Instance.ActiveTypeChange();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoubleAnimationUsingKeyFrames dax = new DoubleAnimationUsingKeyFrames();
            DoubleAnimationUsingKeyFrames day = new DoubleAnimationUsingKeyFrames();



            //dax.From = -200;
            //day.From = -200;
            //dax.To = 200;
            //day.To = 200;
            //Duration duration = new Duration(TimeSpan.FromMilliseconds(900));
            //dax.Duration = duration;
            //day.Duration = duration;


            //LinearDoubleKeyFrame x_kf_1 = new LinearDoubleKeyFrame();
            //LinearDoubleKeyFrame x_kf_2 = new LinearDoubleKeyFrame();
            //LinearDoubleKeyFrame x_kf_3 = new LinearDoubleKeyFrame();
            //x_kf_1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300));
            //x_kf_1.Value = 200;

            //x_kf_2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(600));
            //x_kf_2.Value = 0;
            //x_kf_3.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(900));
            //x_kf_3.Value = 200;

            //dax.KeyFrames.Add(x_kf_1);
            //dax.KeyFrames.Add(x_kf_2);
            //dax.KeyFrames.Add(x_kf_3);

            //LinearDoubleKeyFrame y_kf_1 = new LinearDoubleKeyFrame();
            //LinearDoubleKeyFrame y_kf_2 = new LinearDoubleKeyFrame();
            //LinearDoubleKeyFrame y_kf_3 = new LinearDoubleKeyFrame();

            //y_kf_1.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300));
            //y_kf_1.Value = 0;
            //y_kf_2.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(600));
            //y_kf_2.Value = 180;
            //y_kf_3.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(900));
            //y_kf_3.Value = 180;
            //day.KeyFrames.Add(y_kf_1);
            //day.KeyFrames.Add(y_kf_2);
            //day.KeyFrames.Add(y_kf_3);


            //t2.BeginAnimation(TranslateTransform.XProperty, dax);
            //t2.BeginAnimation(TranslateTransform.YProperty, day);


            //DoubleAnimationUsingKeyFrames dakx = new DoubleAnimationUsingKeyFrames();
            //dakx.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            //SplineDoubleKeyFrame kf = new SplineDoubleKeyFrame();
            //kf.Value = 200;
            //kf.KeyTime = KeyTime.FromPercent(1);
            //KeySpline ks = new KeySpline();
            //ks.ControlPoint1 = new Point(0, 1);
            //ks.ControlPoint2 = new Point(1, 0);
            //kf.KeySpline = ks;
            //dakx.KeyFrames.Add(kf);
        
            //t2.BeginAnimation(TranslateTransform.XProperty, dakx);


        }
    }
}
