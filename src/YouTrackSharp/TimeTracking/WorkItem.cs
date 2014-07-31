using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrackSharp.TimeTracking
{
	public class WorkItem
	{
		public string ID { get; set; }
		public DateTime Timestamp { get; set; }
		public TimeSpan Duration { get; set; }
		public string Description { get; set; }
		public WorkItemAuthor Author { get; set; }

		public override string ToString()
		{
			return String.Format( "{0} - {1} by {2}", Description, Duration, Author );
		}
	}
}
