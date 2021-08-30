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

namespace workshop_government_data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private DataTable data;
        private ArrayList departments;
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }





        private void ButtonLoadFile(object sender, RoutedEventArgs e)
        {
            departments = new ArrayList();

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
                    string[] lineInfoTitles = line.Split(",");
                    lineInfoTitles[4] = "Tipo";

                    dataTable.Columns.Add(lineInfoTitles[0], typeof(string));
                    dataTable.Columns.Add(lineInfoTitles[1], typeof(string));
                    dataTable.Columns.Add(lineInfoTitles[2], typeof(string));
                    dataTable.Columns.Add(lineInfoTitles[3], typeof(string));
                    dataTable.Columns.Add(lineInfoTitles[4].Replace("/", "-"), typeof(string));


                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] lineInfo = line.Split(",");
                        if (lineInfo[0].Length < 3)
                        {
                            dataTable.Rows.Add(lineInfo);
                        }

                        //Suponiendo que el array list departments posee arreglos de tamaño 1,
                        //donde en la posicion 0 esta el nombre del departamento y en la posicion 1 la cantidad
                        bool exist = false;
                        for (int i = 0; i < departments.Count; i++)
                        {
                            string[] actuallyArray = (string[])departments[i];
                            string actually = actuallyArray[0];
                            if (actually.Equals(lineInfo[2]))
                            {
                                string[] x = (string[])departments[i];
                                int num = int.Parse(x[1]) + 1;

                                string[] y = (string[])departments[i];
                                y[1] = num.ToString();
                                departments[i] = y;
                                //departments[i].[1] = num.ToString;
                                exist = true;
                            }
                        }

                        if (!exist)
                        {
                            string[] newDeparment = { lineInfo[2], "1" };
                            departments.Add(newDeparment);
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

        private void ButtonLoadGraphic(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = Visibility.Hidden;
            graphic.Visibility = Visibility.Visible;
            aux();
        }

        private void aux()
        {
            //get departments
            string[] departmentsOnly = new string[departments.Count];
            for (int i = 0; i < departments.Count; i++)
            {
                string[] temp = (string[])departments[i];
                departmentsOnly[i] = temp[0];
            }

            //get municipies
            double[] quantityOnly = new double[departments.Count];
            for (int i = 0; i < departments.Count; i++)
            {
                string[] temp = (string[])departments[i];
                double quantity = double.Parse(temp[1]);
                quantityOnly[i] = quantity;
            }

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Cantidad de municipios",
                    Values = new ChartValues<double> (quantityOnly)
                }
            };

            Labels = departmentsOnly;
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
    }
}