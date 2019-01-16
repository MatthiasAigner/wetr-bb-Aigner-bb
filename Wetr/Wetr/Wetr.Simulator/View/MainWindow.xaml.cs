using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Wetr.Domainclasses;
using Wetr.Simulator.View;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;

namespace Wetr.Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Stations> SimulatedStations { get; set; }
        public ObservableCollection<Measurements> MeasurementsCollection;
        public ObservableCollection<Measurements> RoundedMeasurementsCollection;
        public SeriesCollection ChartData { get; set; }
        public LineSeries ChartDataLine;
        public ChartValues<double> MyChartValues;
        private DispatcherTimer dt = new DispatcherTimer();
        private int selectedStationIndex;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {

            MeasurementsCollection = new ObservableCollection<Measurements>();
            RoundedMeasurementsCollection = new ObservableCollection<Measurements>();
            SimulatedStations = new ObservableCollection<Stations>();
            dt.Tick += dtTicker;
            InitializeComponent();
            MyChartValues = new ChartValues<double>();
            ChartDataLine = new LineSeries();
            ChartDataLine.Title = "Messwert:";
            ChartDataLine.Values = MyChartValues;
            ChartData = new SeriesCollection { ChartDataLine };
            DataContext = this;
        }


        public void AddSimulatedStations(Stations addedStation)
        {
            bool alreadyAdded = false;
            foreach (Stations station in SimulatedStations)
            {
                if (station.Station == addedStation.Station)
                    alreadyAdded = true;
            }
            if (!alreadyAdded)
            {
                SimulatedStations.Add(addedStation);
                lbStations.SelectedIndex = SimulatedStations.Count - 1;
            }
        }

        public void deleteSimulatedStation()
        {
            if (lbStations.SelectedIndex >= 0)
            {
                SimulatedStations.RemoveAt(lbStations.SelectedIndex);
                lbStations.SelectedIndex = 0;
            }
        }

        public int minValueRange //for Slider
        {
            get
            {
                switch (cbMeasurement.SelectedIndex)
                {
                    case 0: // Lufttemperatur
                        return -25;
                    case 1: // Luftdruck
                        return 813;
                    case 2: // Regenmenge
                        return 0;
                    case 3: // Luftfeuchtigkeit
                        return 0;
                    case 4: // Windgeschwindigkeit
                        return 0;
                    default:
                        return 0;
                }
            }
            set { }
        }

        public int maxValueRange //for Slider
        {
            get
            {
                switch (cbMeasurement.SelectedIndex)
                {
                    case 0: // Lufttemperatur
                        return 45;
                    case 1: // Luftdruck:
                        return 1213;
                    case 2: // Regenmenge
                        return 35;
                    case 3: // Luftfeuchtigkeit
                        return 100;
                    case 4: // Windgeschwindigkeit
                        return 160;
                    default:
                        return 10;
                }
            }
        }

        public string ValueRangeUnit //for Slider
        {
            get
            {
                switch (cbMeasurement.SelectedIndex)
                {
                    case 0: // Lufttemperatur
                        return "°C";
                    case 1: // Luftdruck:
                        return "hPa";
                    case 2: // Regenmenge
                        return "mm/h";
                    case 3: // Luftfeuchtigkeit
                        return "%";
                    case 4: // Windgeschwindigkeit
                        return "km/h";
                    default:
                        return "";
                }
            }
        }

        public double StartValue //for Slider
        {
            get
            {
                return (minValueRange + maxValueRange) / 2.0;
            }
            set { }
        }

        private void BtAddStation_Click(object sender, RoutedEventArgs e)
        {
            AddStations addStations = new AddStations(this);
            addStations.Show();
        }

        private void DudValueRangeTo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            slValueRangeTo.Value = Math.Round((double)dudValueRangeTo.Value, 1);
        }

        private void SlValueRangeTo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dudValueRangeTo.Value = Math.Round((double)slValueRangeTo.Value, 1);
        }

        private void DudValueRangeFrom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            slValueRangeFrom.Value = Math.Round((double)dudValueRangeFrom.Value, 1);
        }

        private void SlValueRangeFrom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dudValueRangeFrom.Value = Math.Round((double)slValueRangeFrom.Value, 1);
        }

        private void CbStrategy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbMeasurement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dudValueRangeFrom != null && dudValueRangeTo != null)
            {
                slValueRangeFrom.Minimum = minValueRange;
                slValueRangeTo.Minimum = minValueRange;
                slValueRangeFrom.Maximum = maxValueRange;
                slValueRangeTo.Maximum = maxValueRange;
                dudValueRangeFrom.Value = StartValue;
                dudValueRangeTo.Value = StartValue;
                dudValueRangeFrom.Minimum = minValueRange;
                dudValueRangeTo.Minimum = minValueRange;
                dudValueRangeFrom.Maximum = maxValueRange;
                dudValueRangeTo.Maximum = maxValueRange;
                lbValueRangeFromUnit.Content = ValueRangeUnit;
                lbValueRangeToUnit.Content = ValueRangeUnit;
            }
        }

        //private ObservableCollection<Measurements> Measurements
        //{
        //    get
        //    {
        //        return MeasurementsCollection;
        //    }
        //    set { }
        //}



        private void BtStartSimulator_Click(object sender, RoutedEventArgs e)
        {
            if (!DateImputsIsValid())
            {
                MessageBox.Show("Endzeit muss später als Startzeit sein!", "Error", MessageBoxButton.OKCancel);
            }
            else
            {
                RoundedMeasurementsCollection.Clear();
                MeasurementsCollection.Clear();
                MyChartValues.Clear();
                Measurements generatedMeasurement = GenerateMeasurements();
                MeasurementsCollection.Add(generatedMeasurement);
                AddChartValue(generatedMeasurement);
                AddMeasurementToRoundedMeasurementCollection(generatedMeasurement);
                dgMeasurements.ItemsSource = RoundedMeasurementsCollection;
                double generateSpeed = 1.0;
                if ((bool)rbSpeed1.IsChecked)
                    generateSpeed = 0.5;
                else if ((bool)rbSpeed3.IsChecked)
                    generateSpeed = 10.0;
                dt.Interval = TimeSpan.FromSeconds((double)dudFrequency.Value / generateSpeed);
                dt.Start();
                btStartSimulator.IsEnabled = false;
                btStopSimulator.IsEnabled = true;
                btSendData.IsEnabled = false;
                UITimeInput(false);
                UIRightColumnEnabled(false);
            }
        }



        private void AddChartValue(Measurements generatedMeasurement)
        {
            switch (cbMeasurement.SelectedIndex)
            {
                case 0: //Lufttemperatur
                    MyChartValues.Add(generatedMeasurement.Airtemperature);
                    ChartDataLine.Title = "Lufttemperatur [°C]";
                    MyYAxis.Title = "Lufttemperatur [°C]";
                    break;
                case 1: //Luftdruck
                    MyChartValues.Add(generatedMeasurement.Airpressure);
                    ChartDataLine.Title = "Luftdruck [hPa]";
                    MyYAxis.Title = "Luftdruck [hPa]";
                    break;
                case 2: //Regenmenge
                    MyChartValues.Add(generatedMeasurement.Rainfall);
                    ChartDataLine.Title = "Regenmenge [mm/h]";
                    MyYAxis.Title = "Regenmenge [mm/h]";
                    break;
                case 3: //Luftfeuchtigkeit
                    MyChartValues.Add(generatedMeasurement.Humidity);
                    ChartDataLine.Title = "Luftfeuchtigkeit [%]";
                    MyYAxis.Title = "Luftfeuchtigkeit [%]";
                    break;
                case 4: //Windgeschwindigkeit
                    MyChartValues.Add(generatedMeasurement.WindSpeed);
                    ChartDataLine.Title = "Windgeschwindigkeit [km/h]";
                    MyYAxis.Title = "Windgeschwindigkeit [km/h]";
                    break;
            }
        }

        private void AddMeasurementToRoundedMeasurementCollection(Measurements generatedMeasurement)
        {
            Measurements roundedMeasurement = new Measurements();
            roundedMeasurement.Station = generatedMeasurement.Station;
            roundedMeasurement.Timestamp = generatedMeasurement.Timestamp;
            roundedMeasurement.Airtemperature = Math.Round(generatedMeasurement.Airtemperature, 1);
            roundedMeasurement.Airpressure = Math.Round(generatedMeasurement.Airpressure, 1);
            roundedMeasurement.Rainfall = Math.Round(generatedMeasurement.Rainfall, 1);
            roundedMeasurement.Humidity = Math.Round(generatedMeasurement.Humidity, 1);
            roundedMeasurement.WindSpeed = Math.Round(generatedMeasurement.WindSpeed, 1);
            roundedMeasurement.WindDirection = generatedMeasurement.WindDirection;
            RoundedMeasurementsCollection.Add(roundedMeasurement);
        }

        private void dtTicker(object sender, EventArgs e)
        {
            Measurements generatedMeasurement = GenerateMeasurements();
            MeasurementsCollection.Add(generatedMeasurement);
            AddMeasurementToRoundedMeasurementCollection(generatedMeasurement);
            AddChartValue(generatedMeasurement);
            DateTime startDateTime = (DateTime)dpStartDate.SelectedDate.Value;
            DateTime startTime = ((DateTime)tpStartTime.Value);
            startDateTime = startDateTime.AddHours(startTime.Hour);
            startDateTime = startDateTime.AddMinutes(startTime.Minute);
            DateTime endDateTime = (DateTime)dpEndDate.SelectedDate.Value;
            DateTime endTime = ((DateTime)tpEndTime.Value);
            endDateTime = endDateTime.AddHours(endTime.Hour);
            endDateTime = endDateTime.AddMinutes(endTime.Minute);
            if (generatedMeasurement.Timestamp.AddSeconds((double)dudFrequency.Value) > endDateTime || endDateTime <= startDateTime)
            {
                dt.Stop();
                btStartSimulator.IsEnabled = true;
                btSendData.IsEnabled = true;
                btStopSimulator.IsEnabled = false;
                UIRightColumnEnabled(true);
            }
            dgMeasurements.ItemsSource = RoundedMeasurementsCollection;
        }



        private void BtStopSimulator_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            btStartSimulator.IsEnabled = true;
            btStopSimulator.IsEnabled = false;
            btSendData.IsEnabled = true;
            UITimeInput(true);
            UIRightColumnEnabled(true);
        }

        private void BtSendData_Click(object sender, RoutedEventArgs e)
        {

        }



        private void BtDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            deleteSimulatedStation();
        }

        private void LbStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStationIndex = lbStations.SelectedIndex;
            if (selectedStationIndex < 0)
            {
                noStationSelected();
            }
            else
            {
                newStationSelected();
            }
        }

        private void newStationSelected()
        {
            lbSimulatedStation.Content = "Simulierte Wetterstation: " + SimulatedStations.ElementAt(selectedStationIndex).Station;
            btStartSimulator.IsEnabled = true;
            btStopSimulator.IsEnabled = false;
            btSendData.IsEnabled = false;
            MeasurementsCollection.Clear();
            RoundedMeasurementsCollection.Clear();
            MyChartValues.Clear();
            UITimeInput(true);
            UIRightColumnEnabled(true);
        }

        private void noStationSelected()
        {
            lbSimulatedStation.Content = "Keine Wetterstation ausgewählt!!!";
            btStartSimulator.IsEnabled = false;
            btStopSimulator.IsEnabled = false;
            btSendData.IsEnabled = false;
            MeasurementsCollection.Clear();
            RoundedMeasurementsCollection.Clear();
            MyChartValues.Clear();
        }



        private Measurements GenerateMeasurements()
        {
            int[] Array = {3,4,2,5,5,6,3,2,1,0,-2,-3,-4,-5,-4,-3,-2,
                0,2,3,4,5,5,5,6,5,5,6,4,4,5,6,7,6,5,4,5,6,7,7,7,8,8,
                9,9,9,8,6,5,6,7,8,9,9,10,9,8,8,9,10,11,12,12,13,12,12,
                13,14,15,16,17,16,16,16,15,14,15,12, 13,12,11,13,14,
                13,11,12,15,10,14,15,16,17,16,17,17,18,18,19,20,21,15,
                14,15,18,21,22,22,22,16,16,15,14,14,13,15,16,18,19,22,
                23,24,19,18,16,17,21,23,23,23,22,21,24,20,19,18,18,24,
                25,26,24,25,24,25,26,25,25,24,25,26,27,25,27,28,26,27,
                28,29,30,30,29,28,29,25,18,19,18,21,22,22,23,24,25,26,
                29,28,29,30,31,30,32,33,30,25,26,28,30,26,27,28,30,30,
                31,32,29,28,26,25,24,25,26,27,28,29,30,32,31,30,32,33,
                34,30,28,26,25,24,23,22,22,22,23,25,26,27,28,29,30,31,
                30,31,30,32,33,34,35,35,34,30,28,26,25,24,24,25,27,26,
                25,24,27,27,28,29,30,31,32,33,32,30,31,27,24,23,24,25,
                26,28,29,30,32,32,34,35,36,35,30,29,28,25,25,27,28,24,
                25,26,24,23,22,20,20,21,24,25,21,22,23,28,27,18,17,16,
                16,18,20,22,23,25,24,19,18,16,17,18,16,17,19,20,14,14,
                13,12,11,14,15,14,13,12,11,10,9,10,8,7,9,8,9,10,14,13,
                13,9,9,8,9,7,8,9,10,9,7,6,4,7,6,5,3,2,2,3,2,4,3,5,6,4,2,2};

            Random random = new Random();
            double generateTimeInterval = (double)dudFrequency.Value;

            Measurements lastMeasurement = MeasurementsCollection.LastOrDefault();
            double startValue = (double)dudValueRangeFrom.Value;
            double endValue = (double)dudValueRangeTo.Value;
            DateTime startDateTime = (DateTime)dpStartDate.SelectedDate.Value;
            DateTime startTime = ((DateTime)tpStartTime.Value);
            startDateTime = startDateTime.AddHours(startTime.Hour);
            startDateTime = startDateTime.AddMinutes(startTime.Minute);
            DateTime endDateTime = (DateTime)dpEndDate.SelectedDate.Value;
            DateTime endTime = ((DateTime)tpEndTime.Value);
            endDateTime = endDateTime.AddHours(endTime.Hour);
            endDateTime = endDateTime.AddMinutes(endTime.Minute);
            DateTime currentTime;
            if (lastMeasurement == null)
            {
                currentTime = startDateTime;
            }
            else
            {
                currentTime = lastMeasurement.Timestamp;
                lastMeasurement = MeasurementsCollection.LastOrDefault();
                currentTime = currentTime.AddSeconds(generateTimeInterval);
            }

            double airTemp = 0.0;
            double airpressure = 0.0;
            double rainfall = 0.0;
            double humidity = 0.0;
            double windspeed = 0.0;
            string windDirection = "";
            if (MeasurementsCollection.Count == 0)
            {
                double offsetTemp = (random.NextDouble() * 4 - 2);
                double offsetPressure = random.NextDouble() * 40 - 20;
                double offsetHumidity = random.NextDouble() * 20 - 10;
                airTemp = Array[currentTime.DayOfYear - 1] + offsetTemp - Math.Abs(currentTime.Hour - 12.0) * 0.7;
                airpressure = 970 + offsetPressure;
                rainfall = random.NextDouble() * 50 - 25;
                if (rainfall < 0.0)
                    rainfall = 0.0;
                humidity = 55 + offsetHumidity;
                windspeed = random.NextDouble() * 50;
                int windDirectionRandom = random.Next(1, 8); ;
                switch (windDirectionRandom)
                {
                    case 1:
                        windDirection = "North";
                        break;
                    case 2:
                        windDirection = "Northeast";
                        break;
                    case 3:
                        windDirection = "East";
                        break;
                    case 4:
                        windDirection = "Southeast";
                        break;
                    case 5:
                        windDirection = "South";
                        break;
                    case 6:
                        windDirection = "Southwest";
                        break;
                    case 7:
                        windDirection = "West";
                        break;
                    case 8:
                        windDirection = "Northwest";
                        break;
                }
            }
            else
            {
                airTemp = lastMeasurement.Airtemperature + (random.NextDouble() - 0.5) * generateTimeInterval * 0.5 / 60;
                airpressure = lastMeasurement.Airpressure + (random.NextDouble() - 0.5) * generateTimeInterval * 2 / 60;
                rainfall = lastMeasurement.Rainfall + (random.NextDouble() - 0.5) * generateTimeInterval * 5 / 60;
                if (rainfall < 0.0)
                    rainfall = 0.0;
                humidity = lastMeasurement.Humidity + (random.NextDouble() - 0.5) * generateTimeInterval * 3 / 60;
                if (humidity < 0.0)
                    humidity = 0.0;
                if (humidity > 100.0)
                    humidity = 100.0;
                windspeed = lastMeasurement.WindSpeed + (random.NextDouble() - 0.5) * generateTimeInterval * 10 / 60;
                string lastWindDirection = lastMeasurement.WindDirection;
                double randomnumber = random.NextDouble();
                switch (lastWindDirection)
                {
                    case "North":
                        windDirection = "North";
                        if (randomnumber < 0.1)
                            windDirection = "Northwest";
                        if (randomnumber > 0.9)
                            windDirection = "Northeast";
                        break;
                    case "Northeast":
                        windDirection = "Northeast";
                        if (randomnumber < 0.1)
                            windDirection = "North";
                        if (randomnumber > 0.9)
                            windDirection = "East";
                        break;
                    case "East":
                        windDirection = "East";
                        if (randomnumber < 0.1)
                            windDirection = "Northeast";
                        if (randomnumber > 0.9)
                            windDirection = "Southeast";
                        break;
                    case "Southeast":
                        windDirection = "Southeast";
                        if (randomnumber < 0.1)
                            windDirection = "East";
                        if (randomnumber > 0.9)
                            windDirection = "South";
                        break;
                    case "South":
                        windDirection = "South";
                        if (randomnumber < 0.1)
                            windDirection = "Southeast";
                        if (randomnumber > 0.9)
                            windDirection = "Southwest";
                        break;
                    case "Southwest":
                        windDirection = "Southwest";
                        if (randomnumber < 0.1)
                            windDirection = "South";
                        if (randomnumber > 0.9)
                            windDirection = "West";
                        break;
                    case "West":
                        windDirection = "West";
                        if (randomnumber < 0.1)
                            windDirection = "Southwest";
                        if (randomnumber > 0.9)
                            windDirection = "Northwest";
                        break;
                    case "Northwest":
                        windDirection = "Northwest";
                        if (randomnumber < 0.1)
                            windDirection = "West";
                        if (randomnumber > 0.9)
                            windDirection = "North";
                        break;
                }
            }

            double minValue;
            double maxValue;
            switch (cbMeasurement.SelectedIndex)
            {

                case 0: //Lufttemperatur 
                    //airTemp = Math.Round((lastMeasurement.Airtemperature + (random.NextDouble() - 0.5) * generateTimeInterval * 0.5 / 60), 1);
                    switch (cbStrategy.SelectedIndex)
                    {
                        case 0: //Linear
                            airTemp = generateNextLinearValue(startValue, endValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 1: //Zufällig
                            airTemp = generateNextRandomValue(startValue, endValue);
                            break;
                        case 2: //Konkav                            
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            airTemp = generateNextKonkavValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 3: //Konvex
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            airTemp = generateNextKonvexValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                    }
                    break;
                case 1: //Luftdruck
                    switch (cbStrategy.SelectedIndex)
                    {
                        case 0: //Linear
                            airpressure = generateNextLinearValue(startValue, endValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 1: //Zufällig
                            airpressure = generateNextRandomValue(startValue, endValue);
                            break;
                        case 2: //Konkav                            
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            airpressure = generateNextKonkavValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 3: //Konvex
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            airpressure = generateNextKonvexValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                    }
                    break;
                case 2: //Regenmenge
                    switch (cbStrategy.SelectedIndex)
                    {
                        case 0: //Linear
                            rainfall = generateNextLinearValue(startValue, endValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 1: //Zufällig
                            rainfall = generateNextRandomValue(startValue, endValue);
                            break;
                        case 2: //Konkav                            
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            rainfall = generateNextKonkavValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 3: //Konvex
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            rainfall = generateNextKonvexValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                    }
                    break;
                case 3: //Luftfeuchtigkeit
                    switch (cbStrategy.SelectedIndex)
                    {
                        case 0: //Linear
                            humidity = generateNextLinearValue(startValue, endValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 1: //Zufällig
                            humidity = generateNextRandomValue(startValue, endValue);
                            break;
                        case 2: //Konkav                            
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            humidity = generateNextKonkavValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 3: //Konvex
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            humidity = generateNextKonvexValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                    }
                    break;
                case 4: //Windgeschwindigkeit
                    switch (cbStrategy.SelectedIndex)
                    {
                        case 0: //Linear
                            windspeed = generateNextLinearValue(startValue, endValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 1: //Zufällig
                            windspeed = generateNextRandomValue(startValue, endValue);
                            break;
                        case 2: //Konkav                            
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            windspeed = generateNextKonkavValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                        case 3: //Konvex
                            if (startValue <= endValue)
                            {
                                minValue = startValue;
                                maxValue = endValue;
                            }
                            else
                            {
                                minValue = endValue;
                                maxValue = startValue;
                            }
                            windspeed = generateNextKonvexValue(minValue, maxValue, startDateTime, endDateTime, currentTime);
                            break;
                    }
                    break;
            }


            Stations station = (Stations)lbStations?.SelectedItem;
            Measurements res = new Measurements(station?.Station, currentTime, airTemp, airpressure, rainfall, humidity, windspeed, windDirection);
            return res;
        }

        private double generateNextLinearValue(double startValue, double endValue, DateTime startTime, DateTime endTime, DateTime currTime)
        {
            TimeSpan deltaStartTimeCurrTime = currTime - startTime;
            TimeSpan deltaStartTimeEndTime = endTime - startTime;
            return startValue + deltaStartTimeCurrTime.TotalSeconds * (endValue - startValue) / deltaStartTimeEndTime.TotalSeconds;
        }

        private double generateNextRandomValue(double startValue, double endValue)
        {
            Random random = new Random();
            return startValue + random.NextDouble() * (endValue - startValue);

        }

        private double generateNextKonkavValue(double minValue, double maxValue, DateTime startTime, DateTime endTime, DateTime currTime)
        {
            TimeSpan deltaStartTimeEndTime = endTime - startTime;
            TimeSpan deltaStartTimeCurrTime = currTime - startTime;
            return ((minValue - maxValue) * 4 * (deltaStartTimeCurrTime.TotalSeconds - deltaStartTimeEndTime.TotalSeconds / 2) * (deltaStartTimeCurrTime.TotalSeconds - deltaStartTimeEndTime.TotalSeconds / 2)) / (deltaStartTimeEndTime.TotalSeconds * deltaStartTimeEndTime.TotalSeconds) + maxValue;
        }

        private double generateNextKonvexValue(double minValue, double maxValue, DateTime startTime, DateTime endTime, DateTime currTime)
        {
            TimeSpan deltaStartTimeEndTime = endTime - startTime;
            TimeSpan deltaStartTimeCurrTime = currTime - startTime;
            return ((maxValue - minValue) * 4 * (deltaStartTimeCurrTime.TotalSeconds - deltaStartTimeEndTime.TotalSeconds / 2) * (deltaStartTimeCurrTime.TotalSeconds - deltaStartTimeEndTime.TotalSeconds / 2)) / (deltaStartTimeEndTime.TotalSeconds * deltaStartTimeEndTime.TotalSeconds) + minValue;
        }

        private void UIRightColumnEnabled(bool enabled)
        {
            rbSpeed1.IsEnabled = enabled;
            rbSpeed2.IsEnabled = enabled;
            rbSpeed3.IsEnabled = enabled;
            cbMeasurement.IsEnabled = enabled;
            cbStrategy.IsEnabled = enabled;
            slValueRangeFrom.IsEnabled = enabled;
            slValueRangeTo.IsEnabled = enabled;
            dudFrequency.IsEnabled = enabled;
            dudValueRangeFrom.IsEnabled = enabled;
            dudValueRangeTo.IsEnabled = enabled;
            lbSpeed.IsEnabled = enabled;
            lbMeasurement.IsEnabled = enabled;
            lbFrequency.IsEnabled = enabled;
            lbValueRangeFrom.IsEnabled = enabled;
            lbValueRangeTo.IsEnabled = enabled;
            lbStrategy.IsEnabled = enabled;
        }

        private bool DateImputsIsValid()
        {
            if (dpStartDate == null || dpEndDate == null || tpStartTime == null || tpEndTime == null)
                return false;
            DateTime startDateTime = (DateTime)dpStartDate.SelectedDate.Value;
            DateTime startTime = ((DateTime)tpStartTime.Value);
            startDateTime = startDateTime.AddHours(startTime.Hour);
            startDateTime = startDateTime.AddMinutes(startTime.Minute);
            DateTime endDateTime = (DateTime)dpEndDate.SelectedDate.Value;
            DateTime endTime = ((DateTime)tpEndTime.Value);
            endDateTime = endDateTime.AddHours(endTime.Hour);
            endDateTime = endDateTime.AddMinutes(endTime.Minute);
            TimeSpan deltaTime = endDateTime - startDateTime;
            if (deltaTime.TotalSeconds > 0)
                return true;
            else
                return false;
        }

        private void UITimeInput(bool enable)
        {
            dpStartDate.IsEnabled = enable;
            dpEndDate.IsEnabled = enable;
            tpStartTime.IsEnabled = enable;
            tpEndTime.IsEnabled = enable;
            lbStartDate.IsEnabled = enable;
            lbStartTime.IsEnabled = enable;
            lbEndDate.IsEnabled = enable;
            lbEndTime.IsEnabled = enable;
        }

        private void TpStartTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (lbDateTimeError != null)
            {
                if (DateImputsIsValid())
                {
                    lbDateTimeError.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbDateTimeError.Visibility = Visibility.Visible;
                }
            }
        }

        private void TpEndTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (lbDateTimeError != null)
            {
                if (DateImputsIsValid())
                {
                    lbDateTimeError.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbDateTimeError.Visibility = Visibility.Visible;
                }
            }
        }

        private void DpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbDateTimeError != null)
            {
                if (DateImputsIsValid())
                {
                    lbDateTimeError.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbDateTimeError.Visibility = Visibility.Visible;
                }
            }
        }

        private void DpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbDateTimeError != null)
            {
                if (DateImputsIsValid())
                {
                    lbDateTimeError.Visibility = Visibility.Hidden;
                }
                else
                {
                    lbDateTimeError.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
