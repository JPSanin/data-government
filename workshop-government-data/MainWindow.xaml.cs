using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace workshop_government_data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private DataTable data;

        public MainWindow()
        {
            InitializeComponent();


        }





        private void ButtonLoadFile(object sender, RoutedEventArgs e)
        {
            var dataTable = new DataTable();

            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";


            if (open.ShowDialog() == true)
            {

                loadBtn.Visibility = Visibility.Hidden;
                loadGph.Visibility = Visibility.Visible;

                var path = open.OpenFile();
                using (StreamReader reader = new StreamReader(path))
                {
                    var line = reader.ReadLine();
                    String[] lineInfoTitles = line.Split(",");
                    lineInfoTitles[4] = "Tipo";

                    dataTable.Columns.Add(lineInfoTitles[0], typeof(String));
                    dataTable.Columns.Add(lineInfoTitles[1], typeof(String));
                    dataTable.Columns.Add(lineInfoTitles[2], typeof(String));
                    dataTable.Columns.Add(lineInfoTitles[3], typeof(String));
                    dataTable.Columns.Add(lineInfoTitles[4].Replace("/", "-"), typeof(String));


                    while ((line = reader.ReadLine()) != null)
                    {

                        String[] lineInfo = line.Split(",");
                        if (lineInfo[0].Length < 3)
                        {
                            dataTable.Rows.Add(lineInfo);
                        }

                    }
                }



                dataGrid.DataContext = dataTable.DefaultView;
                data = dataTable;

                cmbType.Items.Add("Tipo");
                cmbType.SelectedItem = "Tipo";

                cmbType.Items.Add("Municipio");
                cmbType.Items.Add("Isla");
                cmbType.Items.Add("Área no municipalizada");
                cmbType.Visibility = Visibility.Visible;


            }

        }



        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (!cmbType.SelectedItem.ToString().Equals("Tipo"))
            {
                data.DefaultView.RowFilter = "Tipo = " + "'" + cmbType.SelectedItem.ToString() + "'";
                dataGrid.DataContext = data.DefaultView;
            }
            else
            {
                data.DefaultView.RowFilter = string.Empty;
            }

        }

        private void ButtonLoadGraphic(object sender, RoutedEventArgs e){
            
        }

        
    }
}
