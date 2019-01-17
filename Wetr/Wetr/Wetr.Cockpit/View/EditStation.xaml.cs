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
    /// Interaction logic for EditStation.xaml
    /// </summary>
    public partial class EditStation : Window
    {
        private IStationsServer stationServer = new StationsServer();
        private MainWindow mainWindow;
        public EditStation(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            DataContext = this;
            InitializeComponent();
            FillTextboxes();
        }

        private void FillTextboxes()
        {
            Stations editStation = (Stations)mainWindow.lbStations.SelectedItem;
            if (editStation != null)
            {
                tbStationname.Text = editStation.Station;
                tbStationtype.Text = editStation.StationTyp;
                tbLongitude.Text = editStation.CoordinatesLongitude.ToString();
                tbLatitude.Text = editStation.CoordinatesLatitude.ToString();
                tbPostalcode.Text = editStation.Postalcode.ToString();
            }
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stationServer.EditStation(new Stations(tbStationname.Text, tbStationtype.Text, double.Parse(tbLongitude.Text), double.Parse(tbLatitude.Text), int.Parse(tbPostalcode.Text)));
                mainWindow.lbStations.ItemsSource = stationServer.FindAllStations();
                this.Close();
        }
            catch (Exception)
            {
                MessageBox.Show("Ändern fehlgeschlgen! \nPrüfen Sie ob die Postleitzahl und der Stationstyp existieren.", "Error", MessageBoxButton.OKCancel);
            }
}

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
