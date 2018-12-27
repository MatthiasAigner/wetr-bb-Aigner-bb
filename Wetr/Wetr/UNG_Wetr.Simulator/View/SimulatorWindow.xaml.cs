using MediaAnnotator.BL;
using MediaAnnotator.GUI.ViewModel;
using System;
using System.Collections.Generic;
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

namespace MediaAnnotator.GUI.View
{
    /// <summary>
    /// Interaction logic for AnnotatorWindow.xaml
    /// </summary>
    public partial class AnnotatorWindow : Window
    {
        //private IMediaManager mediaMgr = MediaManagerFactory.GetMediaManager();
        private IUsersServer usersServer;

        public AnnotatorWindow()
        {
            InitializeComponent();

            this.Loaded += (s, e) => {
                DataContext = new MediaFolderCollectionVM(mediaMgr);
            };
        }
    }
}
