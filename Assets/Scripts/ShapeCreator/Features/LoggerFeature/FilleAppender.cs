using System;
using System.IO;
using System.Text;

namespace ShapeCreator.Features.LoggerFeature
{
	public class FilleAppender
	{
		private readonly object _lock = new object();
		
		public string FileName { get; }

		public FilleAppender(string fileName) {
			FileName = fileName;
		}
		
		public bool Append(string message)
		{
			try
			{
				lock (_lock)
				{
					using (FileStream fs = File.Open(FileName, FileMode.Append, FileAccess.Write, FileShare.Read)){
						byte[] bytes = Encoding.UTF8.GetBytes(message);
						fs.Write(bytes, 0, bytes.Length);
					}
				}
				
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}
