using UnityEngine;

namespace Common.GlobalEvents
{
	public class InvalidEntryEvent
	{
		public string Description => _description;
		public string Title => _title;
		
		private readonly string _description;
		private readonly string _title;
		
		public InvalidEntryEvent(string description)
		{
			_title = "Invalid Entry";
			_description = description;
		}
	}
}
