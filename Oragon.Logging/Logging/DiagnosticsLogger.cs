using System.Collections.Generic;

namespace Oragon.Logging
{
	public class DiagnosticsLogger : AbstractLogger
	{
		#region Protected Methods

		protected override void SendLog(LogEntry logEntry)
		{
			System.Diagnostics.Debug.WriteLine("Log-----{0}", new object[] { logEntry.LogLevel.ToString() });
			System.Diagnostics.Debug.WriteLine("Log-----\t{0}", new object[] { logEntry.Content });
			System.Diagnostics.Debug.WriteLine("Log-----\t{0}", new object[] { logEntry.Date.ToLongDateString() });
			System.Diagnostics.Debug.WriteLine("Log-----\t{0}", new object[] { logEntry.Date.ToLongTimeString() });
			foreach (KeyValuePair<string, object> item in logEntry.Tags)
			{
				System.Diagnostics.Debug.WriteLine("Log-----\t\tKey  :{0}", new object[] { item.Key });
				System.Diagnostics.Debug.WriteLine("Log-----\t\tValue:{0}", new object[] { item.Value });
			}
			System.Diagnostics.Debug.WriteLine("Log----- -------- -------- -------- --------");
		}

		#endregion Protected Methods
	}
}