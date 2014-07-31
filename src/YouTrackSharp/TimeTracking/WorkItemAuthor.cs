using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrackSharp.TimeTracking
{
	public class WorkItemAuthor : IEquatable<WorkItemAuthor>
	{
		public string Login { get; set; }
		public Uri Url { get; set; }

		public override string ToString()
		{
			return Login;
		}

		#region IEquatable<WorkItemAuthor> Members

		public bool Equals( WorkItemAuthor other )
		{
			return
				other != null &&
				this.Login == other.Login &&
				this.Url == other.Url;
		}

		public override bool Equals( object obj )
		{
			return this.Equals( obj as WorkItemAuthor );
		}

		public override int GetHashCode()
		{
			int hash = 17;
			int prime = 23;

			unchecked
			{
				if ( Login != null )
					hash = hash * prime + Login.GetHashCode();

				if ( Url != null )
					hash = hash * prime + Url.GetHashCode();
			}

			return hash;
		}

		public static bool operator ==( WorkItemAuthor author1, WorkItemAuthor author2 )
		{
			return
				Object.ReferenceEquals( author1, author2 ) ||
				Object.ReferenceEquals( author1, null ) && Object.ReferenceEquals( author2, null ) ||
				!Object.ReferenceEquals( author1, null ) && author1.Equals( author2 );
		}

		public static bool operator !=( WorkItemAuthor author1, WorkItemAuthor author2 )
		{
			return !( author1 == author2 );
		}

		#endregion
	}
}
