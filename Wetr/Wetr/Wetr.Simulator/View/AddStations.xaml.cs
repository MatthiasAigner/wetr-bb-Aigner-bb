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

namespace Wetr.Simulator.View
{
    /// <summary>
    /// Interaction logic for AddStations.xaml
    /// </summary>
    public partial class AddStations : Window
    {
        
        private MainWindow mainWindow;
        public AddStations(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            
            DataContext = this;
            InitializeComponent();
        }

        public ObservableCollection<Stations> AllStations
        {
            get //kommt später von REST-Service
            {
                ObservableCollection<Stations> ocs = new ObservableCollection<Stations>();
                ocs.Add(new Stations("ANDAU", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("BERNSTEIN", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("BRUCKNEUDORF", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("GÜSSING", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("LUTZMANNSBURG", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("MATTERSBURG", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("PODERSDORF", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("RECHNITZ  ", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("WÖRTERBERG", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("ARRIACH", "", 0.0, 0.0, 0));
                ocs.Add(new Stations("ENNS", "", 0.0, 0.0, 0));
                return ocs;
            }
        }

        

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
