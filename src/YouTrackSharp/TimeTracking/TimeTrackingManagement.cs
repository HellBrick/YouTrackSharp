using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrackSharp.Infrastructure;
using YouTrackSharp.TimeTracking.Internal;

namespace YouTrackSharp.TimeTracking
{
	public class TimeTrackingManagement
	{
		private IConnection _connection;

		public TimeTrackingManagement( IConnection connection )
		{
			_connection = connection;
		}

		public IList<WorkItem> WorkItemsForIssue( string issueID )
		{
			string command = String.Format( "issue/{0}/timetracking/workitem", issueID );
			var result = _connection
				.Get<IEnumerable<WorkItemSerializationWrapper>>( command )
				.Select( w => w.ToWorkItem() )
				.ToList();

			return result;
		}
	}
}
