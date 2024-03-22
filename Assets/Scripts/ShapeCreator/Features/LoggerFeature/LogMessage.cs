using System;

namespace ShapeCreator.Features.LoggerFeature
{
	public class LogMessage
	{
		public string Message { get; }
		public DateTime Time { get; }

		public LogMessage(string message)
		{
			Message = message;
			Time = DateTime.UtcNow;
		}
	}
}
