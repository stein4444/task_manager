using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace systemProg_hw1
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details(Process prc)
        {
            InitializeComponent();
            load(prc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void load(Process prc)
        {
            this.Title = prc.ProcessName;
            ProcName.Content = prc.ProcessName;
            MachineName.Content = prc.MachineName;
            Size.Content = prc.PrivateMemorySize64 + " bytes";
            Opened.Content = prc.StartTime;
        }
    }
}
