using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;
using Wetr.Domainclasses;
using Wetr.Simulator.View;

namespace Wetr.Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //, INotifyPropertyChanged
    {
        public ObservableCollection<Stations> SimulatedStations { get; set; }
        public ObservableCollection<Measurements> MeasurementsCollection;

        private DispatcherTimer dt = new DispatcherTimer();

        //public double valueOfValueRangeTo;

        //public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            MeasurementsCollection = new ObservableCollection<Measurements>();
            SimulatedStations = new ObservableCollection<Stations>();
            DataContext = this;
            InitializeComponent();

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
                SimulatedStations.Add(addedStation);
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

        private ObservableCollection<Measurements> Measurements
        {
            get
            {
                return MeasurementsCollection;
            }
            set { }
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
            double offsetTemp = random.NextDouble() * 4 - 2;
            double offsetPressure = random.NextDouble() * 40 - 20;
            double offsetHumidity = random.NextDouble() * 20 - 10;
            Measurements lastMeasurement = MeasurementsCollection.LastOrDefault();
            DateTime currentDate;
            if (lastMeasurement == null)
            {
                currentDate = (DateTime)dpStartDate.SelectedDate.Value;
                DateTime time = ((DateTime)tpStartTime.Value);
                currentDate = currentDate.AddHours(time.Hour);
                currentDate = currentDate.AddMinutes(time.Minute);
            }
            else
            {
                currentDate = lastMeasurement.Timestamp;
                lastMeasurement = MeasurementsCollection.LastOrDefault();
            }
            currentDate = currentDate.AddSeconds(generateTimeInterval);
            double airTemp = Math.Round((Array[currentDate.DayOfYear - 1] + offsetTemp - Math.Abs(currentDate.Hour - 12.0) * 0.7), 1);
            double airpressure = Math.Round((970 + offsetPressure), 1);
            double rainfall = Math.Round((random.NextDouble() * 50 - 25), 1);
            if (rainfall < 0.0)
                rainfall = 0.0;
            double humidity = Math.Round((55 + offsetHumidity), 1);
            double windspeed = Math.Round((random.NextDouble() * 50), 1);
            int windDirectionRandom = random.Next(1, 8);
            string windDirection = "";
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
            if (MeasurementsCollection.LastOrDefault() != null)
            {


                switch (cbMeasurement.SelectedIndex)
                {
                    case 0: //Lufttemperatur 
                        airTemp = Math.Round((lastMeasurement.Airtemperature + (random.NextDouble() - 0.5) * generateTimeInterval * 0.5 / 60) ,1);
                        break;
                    case 1: //Luftdruck
                        airpressure = Math.Round((lastMeasurement.Airpressure + (random.NextDouble() - 0.5) * generateTimeInterval * 2 / 60), 1);
                        break;
                    case 2: //Regenmenge
                        rainfall = Math.Round((lastMeasurement.Rainfall + (random.NextDouble() - 0.5) * generateTimeInterval * 2 / 60), 1);
                        if (rainfall < 0.0)
                            rainfall = 0.0;
                        break;
                    case 3: //Luftfeuchtigkeit
                        humidity = Math.Round((lastMeasurement.Humidity + (random.NextDouble() - 0.5) * generateTimeInterval * 1 / 60), 1);
                        if (humidity < 0.0)
                            humidity = 0.0;
                        if (humidity > 100.0)
                            humidity = 100.0;
                        break;

                }
            }



            Stations station = (Stations)lbStations.SelectedItem;
            Measurements res = new Measurements(station.Station, currentDate, airTemp, airpressure, rainfall, humidity, windspeed, windDirection);
            return res;

        }

        private void BtStartSimulator_Click(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromSeconds((double)dudFrequency.Value);
            dt.Tick += dtTicker;
            dt.Start();
            btStartSimulator.IsEnabled = false;
            btStopSimulator.IsEnabled = true;
        }

        private void dtTicker(object sender, EventArgs e)
        {
            Measurements generatedMeasurement = new Measurements();
            generatedMeasurement = GenerateMeasurements();
            
            MeasurementsCollection.Add(generatedMeasurement);


            DateTime startDate = (DateTime)dpStartDate.SelectedDate.Value;
            DateTime startTime = ((DateTime)tpStartTime.Value);
            startDate = startDate.AddHours(startTime.Hour);
            startDate = startDate.AddMinutes(startTime.Minute);
            DateTime endDate = (DateTime)dpEndDate.SelectedDate.Value;
            DateTime endTime = ((DateTime)tpEndTime.Value);
            endDate = endDate.AddHours(endTime.Hour);
            endDate = endDate.AddMinutes(endTime.Minute);

            if (generatedMeasurement.Timestamp > endDate || endDate < startDate)
            {
                dt.Stop();
            }
            dgMeasurements.ItemsSource = Measurements;
        }

        private void BtStopSimulator_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
            btStartSimulator.IsEnabled = true;
            btStopSimulator.IsEnabled = false;
        }
    }
}
