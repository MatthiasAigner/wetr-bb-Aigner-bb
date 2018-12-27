using MediaAnnotator.BL;
using MediaAnnotator.Domain;
using System;
using System.ComponentModel;
using System.Windows.Input;


namespace MediaAnnotator.GUI.ViewModel {

    public class MediaItemVM : INotifyPropertyChanged {
        private IMediaManager mediaMgr;
        private MediaItem item;
        private ICommand saveCommand;

        public MediaItemVM(IMediaManager mediaMgr, MediaItem item) {
            this.mediaMgr = mediaMgr;
            this.item = item;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => item.Name;
            set
            {
                if(item.Name != value)
                {
                    item.Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
                
            }
        }

        public string Url {
            get => item.Url;
            set {
                if (item.Url != value) {
                    item.Url = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
                }
            }
        }

        public string Annotation {
            get => item.Annotation;
            set {
                if (item.Annotation != value) {
                    item.Annotation = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Annotation)));
                }
            }
        }

        public DateTime CreationTime {
            get => item.CreationTime;
            set {
                if (item.CreationTime != value) {
                    item.CreationTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CreationTime)));
                }
            }
        }

        public ICommand SaveCommand {
            get {
                if(saveCommand != null)
                {
                    saveCommand = new RelayCommand(
                        param => mediaMgr.UpdateAnnotation(item)
                        );
                }
                return saveCommand;
            }
        }

        
    }
}
