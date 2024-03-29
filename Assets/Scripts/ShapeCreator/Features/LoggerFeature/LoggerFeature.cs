using System.IO;
using Common;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace ShapeCreator.Features.LoggerFeature
{
	public class LoggerFeature : IFeature
	{
		private string TAG = "[TEXT_COMMAND]";
		
		public string LogsFolderPath => _logsFolderPath;
		private string _logsFolderPath;
		private FileWriter _fileWriter;
		
		public void Init()
		{
			_logsFolderPath = $"{Application.persistentDataPath}/Logs";

			if (!Directory.Exists(_logsFolderPath))
			{
				Directory.CreateDirectory(_logsFolderPath);
			}
			
			_fileWriter = new FileWriter(_logsFolderPath);
			
			Application.logMessageReceivedThreaded += OnLogMessageReceived;
		}
		
		private void OnLogMessageReceived(string condition, string stacktrace, LogType type)
		{
			if (condition.Length <= TAG.Length || condition.Substring(0, TAG.Length) != TAG) return;
			
			condition = condition.Substring(TAG.Length);
			_fileWriter.WriteLog(new LogMessage(condition));
		}
		
		public void Destroy()
		{
			Application.logMessageReceivedThreaded -= OnLogMessageReceived;
			_fileWriter.Dispose();
		}
	}
}
