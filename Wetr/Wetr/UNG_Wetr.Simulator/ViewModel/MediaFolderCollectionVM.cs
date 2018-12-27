using MediaAnnotator.BL;
using MediaAnnotator.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace MediaAnnotator.GUI.ViewModel {
    public class MediaFolderCollectionVM : INotifyPropertyChanged {
        private IMediaManager mediaMgr;
        private MediaFolderVM currentFolder;
        private ICommand loadCommand;

        public ObservableCollection<MediaFolderVM> Folders { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MediaFolderCollectionVM(IMediaManager mediaMgr) {
            this.mediaMgr = mediaMgr;
            Folders = new ObservableCollection<MediaFolderVM>();
            LoadFolders();
        }


        public MediaFolderVM CurrentFolder {
            get => currentFolder;
            set {
                if (currentFolder != value) {
                    currentFolder = value;
                    if(currentFolder != null)
                    {
                        currentFolder.LoadItems();
                    }
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentFolder)));
                }
            }
        }

        public ICommand LoadCommand {
            get {
                if (loadCommand == null)
                    loadCommand = new RelayCommand(param => LoadFolders());
                return loadCommand;
            }
        }

        public void LoadFolders() {
            CurrentFolder = null;
            Folders.Clear();
            IEnumerable<MediaFolder> folders = mediaMgr.GetMediaFolders(Constants.BaseMediaFolder, Constants.MediaExt);

            foreach (MediaFolder fld in folders)
            {
                Folders.Add(new MediaFolderVM(mediaMgr, fld));
            }
        }
    }
}
