using System;
using System.IO;
using System.Text;

namespace ShapeCreator.Features.LoggerFeature
{
	public class FileWriter
	{
		private string _logsFolderPath;
		private string _logFilePath;
		
		private const string DateFormat = "yyyy-MM-dd";

		public FileWriter(string logsFolderPath) {
			_logsFolderPath = logsFolderPath;
			_logFilePath = GetLogFilePath();
		}
		
		private string GetLogFilePath()
		{
			return $"{_logsFolderPath}/log_{DateTime.Now.ToString(DateFormat)}.log";
		}
		
		public void WriteLog(string message)
		{
			using (FileStream fs = File.Open(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read)){
				byte[] bytes = Encoding.UTF8.GetBytes(message);
				fs.Write(bytes, 0, bytes.Length);
			}
		}
	}
}
