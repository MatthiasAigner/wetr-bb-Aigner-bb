using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        public IProvincesServer provincesServer = new ProvincesServer();
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
                return provincesServer.FindAllProvinces();
            }
            set { }
        }

        public NotifyTaskCompletion<IEnumerable<Measurements>> GetAllMeasurmentsForDataGridAsync { get; set; }

        private void LbStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            if (lbUnit != null && rbSum != null)
            {
                switch (cbMeasurement.SelectedIndex)
                {
                    case 0: //Lufttemperatur
                        lbUnit.Content = "°C";
                        break;
                    case 1://Luftdruck
                        lbUnit.Content = "hPa";
                        break;
                    case 2: //Regenmenge                  
                        lbUnit.Content = "mm/h";
                        break;
                    case 3: //Luftfeuchtigkeit
                        lbUnit.Content = "%";
                        break;
                    case 4: //Windgeschwindigkeit
                        lbUnit.Content = "km/h";
                        break;
                }
            }

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
            }
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFilterStations != null && lbFilterCommunities != null && lbFilterDistricts != null && lbFilterProvinces != null && dudLongitude != null && dudLatitude != null && dudRadius != null)
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

        private List<Stations> SelectedStations()
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
            return selectedStations;
        }

        private DateTime GetSelectedStartTime()
        {
            DateTime startDateTime = (DateTime)dpStartDate.SelectedDate.Value;
            DateTime startTime = ((DateTime)tpStartTime.Value);
            startDateTime = startDateTime.AddHours(startTime.Hour);
            startDateTime = startDateTime.AddMinutes(startTime.Minute);
            return startDateTime;
        }

        private DateTime GetSelectedEndTime()
        {
            DateTime endDateTime = (DateTime)dpEndDate.SelectedDate.Value;
            DateTime endTime = ((DateTime)tpEndTime.Value);
            endDateTime = endDateTime.AddHours(endTime.Hour);
            endDateTime = endDateTime.AddMinutes(endTime.Minute);
            return endDateTime;
        }

        private void UpdateDataGrid()
        {
            if (lbFilterStations != null && dgMeasurements != null)
            {
                List<Stations> selectedStations = SelectedStations();
                DateTime startDateTime = GetSelectedStartTime();
                DateTime endDateTime = GetSelectedEndTime();
                GetAllMeasurmentsForDataGridAsync = new NotifyTaskCompletion<IEnumerable<Measurements>>(measurementsServer.FindAllMeasurementsByStationsInTimeIntervalAsync(selectedStations, startDateTime, endDateTime));
                dgMeasurements.ItemsSource = GetAllMeasurmentsForDataGridAsync.Result; //(List<Measurements>)measurementsServer.FindAllMeasurementsByStationsInTimeInterval(selectedStations, startDateTime, endDateTime);
            }
        }

        private void BtFilter_Click(object sender, RoutedEventArgs e)
        {
            dgMeasurements.ItemsSource = new List<Measurements>(); //clear table
            UpdateDataGrid();
        }

        private void calculateResult()
        {
            Stations selectedStations = (Stations)lbFilterStations.SelectedItem;
            DateTime startDateTime = GetSelectedStartTime();
            DateTime endDateTime = GetSelectedEndTime();
            double result = 0.0;
            if (rbMin != null && rbMax != null && rbSum != null && tbResult != null && cbMeasurement != null)
            {
                switch (cbMeasurement.SelectedIndex)
                {
                    case 0: //Lufttemperatur
                        if ((bool)rbMin.IsChecked)
                            result = measurementsServer.FindMinTempByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        else if ((bool)rbMax.IsChecked)
                            result = measurementsServer.FindMaxTempByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        else if ((bool)rbAvg.IsChecked)
                            result = Math.Round(measurementsServer.FindAvgTempByStationInTimeInterval(selectedStations, startDateTime, endDateTime), 2);
                        break;
                    case 1://Luftdruck
                        if ((bool)rbMin.IsChecked)
                            result = measurementsServer.FindMinPressureByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        if ((bool)rbMax.IsChecked)
                            result = measurementsServer.FindMaxPressureByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        if ((bool)rbAvg.IsChecked)
                            result = Math.Round(measurementsServer.FindAvgPressureByStationInTimeInterval(selectedStations, startDateTime, endDateTime), 2);
                        break;
                    case 2: //Regenmenge
                        if ((bool)rbMin.IsChecked)
                        {
                            result = measurementsServer.FindMinRainfallByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                            lbUnit.Content = "mm/h";
                        }
                        if ((bool)rbMax.IsChecked)
                        {
                            result = measurementsServer.FindMaxRainfallByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                            lbUnit.Content = "mm/h";
                        }
                        if ((bool)rbAvg.IsChecked)
                        {
                            result = Math.Round(measurementsServer.FindAvgRainfallByStationInTimeInterval(selectedStations, startDateTime, endDateTime), 2);
                            lbUnit.Content = "mm/h";
                        }
                        if ((bool)rbSum.IsChecked)
                        {
                            result = measurementsServer.FindAvgRainfallByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                            lbUnit.Content = "mm";
                            TimeSpan timeSpan = endDateTime - startDateTime;
                            double timeSpanHours = timeSpan.TotalHours;
                            result = Math.Round(result * timeSpanHours, 2);
                        }
                        break;
                    case 3: //Luftfeuchtigkeit
                        if ((bool)rbMin.IsChecked)
                            result = measurementsServer.FindMinHumidityByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        if ((bool)rbMax.IsChecked)
                            result = measurementsServer.FindMaxHumidityByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        if ((bool)rbAvg.IsChecked)
                            result = Math.Round(measurementsServer.FindAvgHumidityByStationInTimeInterval(selectedStations, startDateTime, endDateTime), 2);
                        break;
                    case 4: //Windgeschwindigkeit
                        if ((bool)rbMin.IsChecked)
                            result = measurementsServer.FindMinWindspeedByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        if ((bool)rbMax.IsChecked)
                            result = measurementsServer.FindMaxWindspeedByStationInTimeInterval(selectedStations, startDateTime, endDateTime);
                        if ((bool)rbAvg.IsChecked)
                            result = Math.Round(measurementsServer.FindAvgWindspeedByStationInTimeInterval(selectedStations, startDateTime, endDateTime), 2);
                        break;
                }
                if (result > -999.0)
                    tbResult.Text = result.ToString();
                else
                    tbResult.Text = "kein Wert!";
            }
        }

        private void BtResult_Click(object sender, RoutedEventArgs e)
        {
            calculateResult();
        }
    }
}
