using MediaAnnotator.BL;
using MediaAnnotator.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace MediaAnnotator.GUI.ViewModel {
    public class MediaFolderVM : INotifyPropertyChanged {
        private IMediaManager mediaMgr;
        private MediaFolder folder;
        private MediaItemVM currentItem;
        
        public ObservableCollection<MediaItemVM> Items { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public MediaFolderVM(IMediaManager mediaMgr, MediaFolder folder) {
            this.mediaMgr = mediaMgr;
            this.folder = folder;
            Items = new ObservableCollection<MediaItemVM>();
        }

        public string Name {
            get => folder.Name;
            set {
                if (folder.Name != value) {
                    folder.Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public string Url {
            get => folder.Url;
            set {
                if (folder.Url != value) {
                    folder.Url = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
                }
            }
        }

        public int ElementCount {
            get => folder.ElementCount;
            set {
                if (folder.ElementCount != value) {
                    folder.ElementCount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ElementCount)));
                }
            }
        }

        public MediaItemVM CurrentItem
        {
            get => currentItem;
            set
            {
                if(currentItem != value)
                {
                    currentItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentItem)));

                }
            }
        }

        public void LoadItems() {
            CurrentItem = null;
            Items.Clear();
            foreach (MediaItem item in mediaMgr.GetMediaItems(folder, Constants.MediaExt))
            {
                Items.Add(new MediaItemVM(mediaMgr, item));
            }
        }
    }
}
