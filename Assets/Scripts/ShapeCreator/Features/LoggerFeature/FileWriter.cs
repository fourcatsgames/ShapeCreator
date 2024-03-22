using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ShapeCreator.Features.LoggerFeature
{
	public class FileWriter : IDisposable
	{
		private string _logsFolderPath;
		private string _logFilePath;
		private FilleAppender _fileAppender;
		private Thread _logThread;
		private readonly ConcurrentQueue<LogMessage> _logMessages = new ConcurrentQueue<LogMessage>();
		private readonly ManualResetEvent _manualReset = new ManualResetEvent(true);
		
		private bool _isRunning = true;
		
		private const string DateFormat = "yyyy-MM-dd";
		private const string LogRowFormat = "{0:dd-MM-yyyy HH:mm:ss} : {1}\r";

		public FileWriter(string logsFolderPath) {
			_logsFolderPath = logsFolderPath;
			_logFilePath = GetLogFilePath();

			_logThread = new Thread(StoreMessages)
			{
				Priority = ThreadPriority.BelowNormal,
				IsBackground = true,
			};
			
			_logThread.Start();
		}
		
		private void StoreMessages()
		{
			while (_isRunning)
			{
				while (!_logMessages.IsEmpty)
				{
					try
					{
						if (!_logMessages.TryPeek(out LogMessage logMessage))
						{
							Thread.Sleep(5);
						}
						
						if (_fileAppender == null || _fileAppender.FileName != _logFilePath)
						{
							_fileAppender = new FilleAppender(_logFilePath);
						}
						
						string message = string.Format(LogRowFormat, logMessage.Time, logMessage.Message);
						if (_fileAppender.Append(message))
						{
							_logMessages.TryDequeue(out logMessage);
						}
						else
						{
							Thread.Sleep(5);
						}
					}
					catch (Exception e)
					{
						break;
					}
				}

				_manualReset.Reset();
				_manualReset.WaitOne(500); // 0.5 sec maximum wait time
			}
		}

		private string GetLogFilePath()
		{
			return $"{_logsFolderPath}/log_{DateTime.Now.ToString(DateFormat)}.log";
		}
		
		public void WriteLog(LogMessage logMessage)
		{
			_logMessages.Enqueue(logMessage);
			_manualReset.Set();
		}
		
		public void Dispose()
		{
			_isRunning = false;
			_logThread?.Abort();
			GC.SuppressFinalize(this);
		}
	}
}
