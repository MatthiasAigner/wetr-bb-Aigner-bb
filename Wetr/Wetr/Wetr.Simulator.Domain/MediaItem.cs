﻿using System;

namespace MediaAnnotator.Domain {

  public class MediaItem {
		public string Name { get; set; }
		public string Url { get; set; }
		public string Annotation { get; set; }
		public DateTime CreationTime { get; set; }
	}

}