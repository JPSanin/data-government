using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace workshop_government_data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLoadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter= "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            var filePath = string.Empty;

            if (open.ShowDialog() == true)
            {
                
                loadBtn.Visibility = Visibility.Hidden;

                var path = open.OpenFile();
                using (StreamReader reader = new StreamReader(path))
                {
                    var line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        MessageBox.Show(line);
                    }
                }
            }

        }
    }
}
