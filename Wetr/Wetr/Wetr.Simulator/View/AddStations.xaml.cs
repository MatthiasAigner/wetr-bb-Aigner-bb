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
using System.Windows.Shapes;
using Wetr.BL.Server;
using Wetr.Domainclasses;
using Wetr.CSharpClient;
using System.ComponentModel;

namespace Wetr.Simulator.View
{
    /// <summary>
    /// Interaction logic for AddStations.xaml
    /// </summary>
    public partial class AddStations : Window, INotifyPropertyChanged
    {
        private Client client = new Client();
        private List<Stations> stationList = new List<Stations>();
        private MainWindow mainWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddStations(MainWindow mainWindow)
        {
            GetAllStationsAsync = new NotifyTaskCompletion<List<Stations>>(client.GetAllStationsAsync(new System.Net.Http.HttpClient()));
            this.mainWindow = mainWindow;
            DataContext = this;
            InitializeComponent();
        }


        public NotifyTaskCompletion<List<Stations>> GetAllStationsAsync { get; set; }


        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            if(lbAllStations.SelectedItem != null)
                mainWindow.AddSimulatedStations((Stations)lbAllStations.SelectedItem);
            this.Close();
        }
    }
}
