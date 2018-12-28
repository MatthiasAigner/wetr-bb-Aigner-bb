using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Wetr.BL.Server;
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
    }
}
