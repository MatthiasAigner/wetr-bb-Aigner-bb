using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommunitiesServer communitiesServer = new CommunitiesServer();
        public IDistrictServer districtServer = new DistrictServer();
        public IMeasurementsServer measurementsServer = new MeasurementsServer();
        public ObservableCollection<Measurements> DataGridMeasurments;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            dgMeasurements.ItemsSource = new List<Measurements>();
        }

        public IEnumerable<Stations> Stations
        {
            get
            {
                return stationServer.FindAllStations();
            }
            set { }
        }

        public IEnumerable<Communities> Communities
        {
            get
            {
                return communitiesServer.FindAllCommunities();
            }
            set { }
        }

        public IEnumerable<Districts> Districts
        {
            get
            {
                return districtServer.FindAllDistricts();
            }
            set { }
        }

        public IEnumerable<Provinces> Provinces
        {
            get
            {
                ObservableCollection<Provinces> provincesList = new ObservableCollection<Provinces>
                {
                    new Provinces("Burgenland"),
                    new Provinces("Kaernten"),
                    new Provinces("Niederoesterreich"),
                    new Provinces("Oberoesterreich"),
                    new Provinces("Salzburg"),
                    new Provinces("Steiermark"),
                    new Provinces("Tirol"),
                    new Provinces("Vorarlberg"),
                    new Provinces("Wien")
                };
                return provincesList;
            }
            set { }
        }

        //private IEnumerable<Measurements> Measurements
        //{
        //    get
        //    {
        //        Stations selectedStation = (Stations)lbFilters.SelectedItem;
        //        //TODO 
        //        //return measurementsServer.FindAllMeasurementsByStationInTimeInterval(selectedStation, DateTime.Now.AddYears(-2), DateTime.Now);
        //        return measurementsServer.FindAllMeasurementsByStation(selectedStation.Station);
        //    }
        //    set { }
        //}

        private void LbStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(dgMeasurements != null)
            //    dgMeasurements.ItemsSource = Measurements;
            if (lbStations.SelectedIndex >= 0)
            {
                if (btEditStation != null && btDeleteStation != null)
                {
                    btEditStation.IsEnabled = true;
                    btDeleteStation.IsEnabled = true;
                }
            }
            else
            {
                if (btEditStation != null && btDeleteStation != null)
                {
                    btEditStation.IsEnabled = false;
                    btDeleteStation.IsEnabled = false;
                }
            }
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
            if (result == MessageBoxResult.Yes)
            {
                if (((List<Measurements>)measurementsServer.FindAllMeasurementsByStation(selectedStation.Station)).Count == 0)
                {
                    try
                    {
                        stationServer.DeleteStation(selectedStation.Station);
                        lbStations.ItemsSource = stationServer.FindAllStations();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Löschen fehlgeschlgen!", "Error", MessageBoxButton.OKCancel);
                    }
                }
                else
                    MessageBox.Show("Löschen fehlgeschlgen! \nNur Stationen ohne Messdaten können gelöscht werden!", "Error", MessageBoxButton.OKCancel);
            }


        }

        private void CbMeasurement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbResult != null && rbSum != null && rbMin != null)
            {
                tbResult.Text = "";
                if (cbMeasurement.SelectedIndex == 2)
                {
                    rbSum.IsEnabled = true;
                }
                else
                {
                    if ((bool)rbSum.IsChecked)
                    {
                        rbMin.IsChecked = true;
                    }
                    rbSum.IsEnabled = false;
                }
                calculateResult();
            }
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbFilterStations != null && lbFilterCommunities != null && lbFilterDistricts != null && lbFilterProvinces != null && dudLongitude != null && dudLatitude != null && dudRadius != null)
            switch (cbFilter.SelectedIndex)
            {
                case 0: //Wetterstationen
                    lbFilterStations.Visibility = Visibility.Visible;
                    lbFilterCommunities.Visibility = Visibility.Hidden;
                    lbFilterDistricts.Visibility = Visibility.Hidden;
                    lbFilterProvinces.Visibility = Visibility.Hidden;
                    dudLongitude.Visibility = Visibility.Hidden;
                    dudLatitude.Visibility = Visibility.Hidden;
                    dudRadius.Visibility = Visibility.Hidden;
                    break;
                case 1: // Region
                    lbFilterStations.Visibility = Visibility.Hidden;
                    lbFilterCommunities.Visibility = Visibility.Hidden;
                    lbFilterDistricts.Visibility = Visibility.Hidden;
                    lbFilterProvinces.Visibility = Visibility.Hidden;
                    dudLongitude.Visibility = Visibility.Visible;
                    dudLatitude.Visibility = Visibility.Visible;
                    dudRadius.Visibility = Visibility.Visible;
                    break;
                case 2: //Gemeinde
                    lbFilterStations.Visibility = Visibility.Hidden;
                    lbFilterCommunities.Visibility = Visibility.Visible;
                    lbFilterDistricts.Visibility = Visibility.Hidden;
                    lbFilterProvinces.Visibility = Visibility.Hidden;
                    dudLongitude.Visibility = Visibility.Hidden;
                    dudLatitude.Visibility = Visibility.Hidden;
                    dudRadius.Visibility = Visibility.Hidden;
                    break;
                case 3: //Bezirk
                    lbFilterStations.Visibility = Visibility.Hidden;
                    lbFilterCommunities.Visibility = Visibility.Hidden;
                    lbFilterDistricts.Visibility = Visibility.Visible;
                    lbFilterProvinces.Visibility = Visibility.Hidden;
                    dudLongitude.Visibility = Visibility.Hidden;
                    dudLatitude.Visibility = Visibility.Hidden;
                    dudRadius.Visibility = Visibility.Hidden;
                    break;
                case 4: //Bundesland
                    lbFilterStations.Visibility = Visibility.Hidden;
                    lbFilterCommunities.Visibility = Visibility.Hidden;
                    lbFilterDistricts.Visibility = Visibility.Hidden;
                    lbFilterProvinces.Visibility = Visibility.Visible;
                    dudLongitude.Visibility = Visibility.Hidden;
                    dudLatitude.Visibility = Visibility.Hidden;
                    dudRadius.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void LbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


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
            if (lbFilterStations != null && dgMeasurements != null)
            {
                List<Stations> selectedStations = new List<Stations>();

                switch (cbFilter.SelectedIndex)
                {
                    case 0: //Wetterstationen
                        selectedStations.Add((Stations)lbFilterStations.SelectedItem);
                        break;
                    case 1: // Region
                        selectedStations.AddRange(stationServer.FindStationByRegion((double)dudLongitude.Value, (double)dudLatitude.Value, (double)dudRadius.Value));
                        break;
                    case 2: //Gemeinde
                        selectedStations.AddRange(stationServer.FindStationByPostalcode(((Communities)lbFilterCommunities.SelectedItem).Postalcode));
                        break;
                    case 3: //Bezirk
                        selectedStations.AddRange(stationServer.FindStationByDistrict(((Districts)lbFilterDistricts.SelectedItem).District));
                        break;
                    case 4: //Bundesland
                        selectedStations.AddRange(stationServer.FindStationByProvince(((Provinces)lbFilterProvinces.SelectedItem).Province));
                        break;

                }

                DateTime startDateTime = (DateTime)dpStartDate.SelectedDate.Value;
                DateTime startTime = ((DateTime)tpStartTime.Value);
                startDateTime = startDateTime.AddHours(startTime.Hour);
                startDateTime = startDateTime.AddMinutes(startTime.Minute);
                DateTime endDateTime = (DateTime)dpEndDate.SelectedDate.Value;
                DateTime endTime = ((DateTime)tpEndTime.Value);
                endDateTime = endDateTime.AddHours(endTime.Hour);
                endDateTime = endDateTime.AddMinutes(endTime.Minute);

                dgMeasurements.ItemsSource = (List<Measurements>)measurementsServer.FindAllMeasurementsByStationsInTimeInterval(selectedStations, startDateTime, endDateTime);
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void calculateResult()
        {

        }

        private void RbMin_Checked(object sender, RoutedEventArgs e)
        {
            calculateResult();
        }

        private void RbMax_Checked(object sender, RoutedEventArgs e)
        {
            calculateResult();
        }

        private void RbAvg_Checked(object sender, RoutedEventArgs e)
        {
            calculateResult();
        }

        private void RbSum_Checked(object sender, RoutedEventArgs e)
        {
            calculateResult();
        }
    }
}
