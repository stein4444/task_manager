using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace systemProg_hw1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = null;
        private int time = 5;
        int[] arr = { 1, 2, 5 };
        public MainWindow()
        {
            InitializeComponent();
            Seconds.ItemsSource = arr;
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, time);
            _timer.Tick += _timer_Tick;
            _timer.Start();
            Load();
        }

        
        private void _timer_Tick(object sender, EventArgs e)
        {
            Load();
            if(Seconds.SelectedItem != null)
            time = int.Parse(Seconds.SelectedItem.ToString());
            _timer.Interval = new TimeSpan(0, 0, time);
        }

        public void Load()
        {
            grid.ItemsSource = Process.GetProcesses();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process prc = grid.SelectedItem as Process;
            if (prc != null)
            {
                try
                {
                    prc.Kill();
                }
                catch (Exception)
                {
                    MessageBox.Show("Process already killed.");
                }
                finally
                {
                    MessageBox.Show("Process killed.");
                }
            }
            prc = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process prc = grid.SelectedItem as Process;
            if (prc != null)
            {
            Details dt = new Details(prc);
            dt.ShowDialog();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Path.Text))
            {
                
                try
                {
                    Process.Start(Path.Text);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                Path.Clear();
            }
            else   
            MessageBox.Show("pleace fill path line");
        }
    }
}
