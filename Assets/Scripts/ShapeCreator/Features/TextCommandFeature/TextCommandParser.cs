using System.Collections.Generic;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	//text command parser utility
	public class TextCommandParser
	{
		private readonly List<string> _commandNames;
		private string _command;
		
		public TextCommandParser(List<string> commandNames)
		{
			_commandNames = commandNames;
		}
		
		public ICommand Parse(string message)
		{
			string commandParams = "";
			
			foreach (string commandName in _commandNames)
			{
				//if command name found and it is first
				if (message.Contains(commandName) && message.IndexOf(commandName, System.StringComparison.Ordinal) == 0)
				{
					_command = commandName;
					
					commandParams = message.Substring(commandName.Length - 1); //remove the command name from the input
					
					
				}
				else
				{
					Debug.Log("Invalid command");
					return null;
				}
			}
			
			//parse the message and return the appropriate command
			string[] words = message.Split(' ');
			
			string command = words[0];

			if (command.ToLower() == "change")
			{
				Debug.Log("Invalid command");
				return null;
			}
			
			
			return null;
		}
	}
}
