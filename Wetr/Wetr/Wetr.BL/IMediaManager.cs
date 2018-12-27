
using System.Collections.Generic;

namespace Wetr.BL {

  public interface IMediaManager {
		IEnumerable<string> GetMediaFolders(string baseUrl, string[] mediaExtensions);
		MediaFolder GetMediaFolder(string url, string[] mediaExtensions);
		IEnumerable<MediaItem> GetMediaItems(MediaFolder folder, string[] mediaExtensions);
		void UpdateAnnotation(MediaItem mediaElement);
	}
}
