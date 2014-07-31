using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using JsonFx.Json;
using YouTrackSharp.Projects;

namespace YouTrackSharp.TimeTracking.Internal
{
	class WorkItemSerializationWrapper
	{
		private static readonly DateTime _zeroDateTime = new DateTime( year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc );

		public string ID { get; set; }
		public long Date { get; set; }
		public int Duration { get; set; }
		public string Description { get; set; }
		public ExpandoObject Author { get; set; }

		public WorkItem ToWorkItem()
		{
			dynamic author = this.Author;

			return new WorkItem()
			{
				ID = this.ID,
				Timestamp = ConvertDate(),
				Duration = TimeSpan.FromMinutes( this.Duration ),
				Description = this.Description,
				Author = new WorkItemAuthor() { Login = author.login, Url = new Uri( author.url ) }
			};
		}

		private DateTime ConvertDate()
		{
			DateTime date = _zeroDateTime.AddMilliseconds( Date );
			
			//	Fix for the YouTrack timezone bug
			if ( date.TimeOfDay != TimeSpan.Zero )
			{
				double dayFraction = date.TimeOfDay.TotalHours / 24.0;
				int dateShift = (int) Math.Round( dayFraction );
				date = date.AddDays( dateShift );
				date = date.Date;
			}

			return date;
		}
	}
}
