using System;
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
            //dgMeasurements.ItemsSource = Measurements;
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
                //TODO 
                return measurementsServer.FindAllMeasurementsByStationInTimeInterval(selectedStation, DateTime.Now.AddYears(-2), DateTime.Now);
            }
            set { }
        }

        private void LbStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(dgMeasurements != null)
            //    dgMeasurements.ItemsSource = Measurements;
            if(lbStations.SelectedIndex >= 0)
            {
                if (btEditStation != null && btDeleteStation != null) {
                    btEditStation.IsEnabled = true;
                    btDeleteStation.IsEnabled = true;
                }
            } else
            {
                if (btEditStation != null && btDeleteStation != null)
                {
                    btEditStation.IsEnabled = false;
                    btDeleteStation.IsEnabled = false;
                }
            }
        }

        private void LbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtAddStation_Click(object sender, RoutedEventArgs e)
        {
            AddStation addStation = new AddStation(this);
            addStation.Show();
        }

        private void BtEditStation_Click(object sender, RoutedEventArgs e)
        {
            EditStation editStation = new EditStation(this);
            editStation.Show();
        }

        private void BtDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            Stations selectedStation = (Stations)lbStations.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Wollen Sie die Station " + selectedStation?.Station + " wirklich löschen?", "Warnung", MessageBoxButton.YesNoCancel);
            if(result == MessageBoxResult.Yes)
            {
                if (((List<Measurements>)measurementsServer.FindAllMeasurementsByStation(selectedStation.Station)).Count == 0) {
                    try
                    {
                        stationServer.DeleteStation(selectedStation.Station);
                        lbStations.ItemsSource = stationServer.FindAllStations();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Löschen fehlgeschlgen!", "Error", MessageBoxButton.OKCancel);
                    }
                } else
                    MessageBox.Show("Löschen fehlgeschlgen! \nNur Stationen ohne Messdaten können gelöscht werden!", "Error", MessageBoxButton.OKCancel);
            }


        }

        private void CbMeasurement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void DpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TpStartTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void TpEndTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void UpdateDataGrid()
        {
            if (lbStations != null && dgMeasurements != null)
            {
                Stations selectedStation = (Stations)lbStations.SelectedItem;
                //dgMeasurements.ItemsSource = measurementsServer.FindAllMeasurementsByStationInTimeInterval(selectedStation, DateTime.Now.AddYears(-2), DateTime.Now);
            }
        }
    }
}
