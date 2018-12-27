using System;

namespace MediaAnnotator.BL {

  public class InvalidUrlException : Exception {
		public InvalidUrlException(string msg)
			: base(string.Format("Invalid URL \"{0}\".", msg)) {
		}
	}
}
