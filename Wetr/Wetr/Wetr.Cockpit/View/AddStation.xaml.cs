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
using System.Windows.Shapes;
using Wetr.BL.Server;
using Wetr.Domainclasses;

namespace Wetr.Cockpit.View
{
    /// <summary>
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStation : Window
    {
        private MainWindow mainWindow;
        private IStationsServer stationServer = new StationsServer();

        public AddStation(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            DataContext = this;
            InitializeComponent();
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stationServer.InsertStation(new Stations(tbStationname.Text, tbStationtype.Text, double.Parse(tbLongitude.Text), double.Parse(tbLatitude.Text), int.Parse(tbPostalcode.Text)));
                mainWindow.lbStations.ItemsSource = stationServer.FindAllStations();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hinzufügen fehlgeschlgen! \nPrüfen Sie ob die Postleitzahl und der Stationstyp existieren.", "Error", MessageBoxButton.OKCancel);
            }
        }
    }
}
