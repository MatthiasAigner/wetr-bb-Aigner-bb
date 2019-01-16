using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Wetr.BL.Server;
using Wetr.Cockpit.View;
using Wetr.Domainclasses;

namespace Wetr.Cockpit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public IStationsServer stationServer = new StationsServer();
        public IMeasurementsServer measurementsServer = new MeasurementsServer();
        public MainWindow()
        {     
            DataContext = this;
            InitializeComponent();
            dgMeasurements.ItemsSource = Measurements;
        }
        
        public IEnumerable<Stations> Stations
        {
            get
            {
                return stationServer.FindAllStations(); ;
            }
            set { }
        }

        private IEnumerable<Measurements> Measurements
        {
            get
            {
                Stations selectedStation = (Stations)lbStations.SelectedItem;
                return measurementsServer.FindAllMeasurementsByStation(selectedStation.Station);
            }
            set { }
        }

        private void LbStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgMeasurements != null)
                dgMeasurements.ItemsSource = Measurements;
        }

        private void LbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtAddStation_Click(object sender, RoutedEventArgs e)
        {
            AddStation addStation = new AddStation(this);
            addStation.Show();
        }
    }
}
