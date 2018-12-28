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
using Wetr.Domainclasses;
using Wetr.Simulator.View;

namespace Wetr.Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public ObservableCollection<Stations> SimulatedStations { get; set; }
        public double valueOfValueRangeTo;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            SimulatedStations = new ObservableCollection<Stations>();
            DataContext = this;
            InitializeComponent();
            
        }
        
        
        



        public void AddSimulatedStations(Stations addedStation)
        {
            bool alreadyAdded = false;
            foreach(Stations station in SimulatedStations)
            {
                if (station.Station == addedStation.Station)
                    alreadyAdded = true;
            }
            if(!alreadyAdded)
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
            slValueRangeTo.Value = Math.Round((double)dudValueRangeTo.Value,1);
        }

        private void SlValueRangeTo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dudValueRangeTo.Value = Math.Round((double)slValueRangeTo.Value,1);
        }

        private void DudValueRangeFrom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            slValueRangeFrom.Value = Math.Round((double)dudValueRangeFrom.Value,1);
        }

        private void SlValueRangeFrom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dudValueRangeFrom.Value = Math.Round((double)slValueRangeFrom.Value,1);
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
    }
}
