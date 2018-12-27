using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MediaAnnotator.BL;
using MediaAnnotator.Domain;

namespace MediaAnnotator.GUI.ViewModel.Test {

	/* Include the following into the Window element of your XAML code.
	 * This assigns a SampleMediaFolderCollectionVM object the DataContext property.
	 * This assignment is only done at design time. The runtime data context has
	 * to be defined in the constructor of the window.
		xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
		xmlns:d="http://schemas.microsoft.com/expression/blend/2008"  
		mc:Ignorable="d"
		xmlns:test="clr-namespace:Swk5.MediaAnnotator.ViewModel.Test"
		d:DataContext="{d:DesignInstance test:SampleMediaFolderCollectionVM, IsDesignTimeCreatable=True}"
	 */

	public class SampleMediaFolderCollectionVM : MediaFolderCollectionVM {
		public SampleMediaFolderCollectionVM() : base(MediaManagerFactory.GetMediaManager()) {
			CurrentFolder = this.Folders.FirstOrDefault();
			if (CurrentFolder != null)
				CurrentFolder.CurrentItem = CurrentFolder.Items.FirstOrDefault();
		}
	}

	public class SampleMediaItemVM : MediaItemVM {
		public SampleMediaItemVM()
			: base(MediaManagerFactory.GetMediaManager(),
						 new MediaItem {
							 Name = "sample item",
							 Annotation = "Nice item.",
							 CreationTime = DateTime.Now,
							 Url = "images/mountain.jpg"
						 }) {
		}
	}

}
