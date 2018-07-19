using System;
using System.Collections.Generic;

namespace Oragon.Logging
{
	public class SafeLogger : AbstractLogger
	{
		#region Public Properties

		public ILogger PrimaryLogger { get; set; }

		public ILogger SecondaryLogger { get; set; }

		#endregion Public Properties

		#region Protected Methods

		protected override void SendLog(LogEntry logEntry)
		{
			List<string> values = new List<string>();
			try
			{
				this.PrimaryLogger.Log(logEntry.Context, logEntry.Content, logEntry.LogLevel, logEntry.Tags);
			}
			catch (Exception ex)
			{
				this.SecondaryLogger.Log("SafeLogger - ", ex.ToString(), LogLevel.Error, logEntry.Tags);
				this.SecondaryLogger.Log(logEntry.Context, logEntry.Content, logEntry.LogLevel, logEntry.Tags);
			}
		}

		#endregion Protected Methods
	}
}