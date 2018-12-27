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
using Wetr.Domainclasses;
using Wetr.Simulator.View;

namespace Wetr.Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Stations> SimulatedStations { get; set; }

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

        public int minValueRange()
        {
            switch (cbMeasurement.SelectedValue)
            {
                case "Lufttemperatur":
                    return -20;
                case "Luftdruck":
                    return 900;
                case "Regenmenge":
                    return 0;
                case "Luftfeuchtigkeit":
                    return 0;
                case "Windgeschwindigkeit":
                    return 0;
                default:
                    return 0;
            }
        }

        public int maxValueRange()
        {
            switch (cbMeasurement.SelectedValue)
            {
                case "Lufttemperatur":
                    return 40;
                case "Luftdruck":
                    return 1100;
                case "Regenmenge":
                    return 30;
                case "Luftfeuchtigkeit":
                    return 100;
                case "Windgeschwindigkeit":
                    return 130;
                default:
                    return 0;
            }
        }

        private void BtAddStation_Click(object sender, RoutedEventArgs e)
        {
            AddStations addStations = new AddStations(this);
            addStations.Show();
        }
    }
}
