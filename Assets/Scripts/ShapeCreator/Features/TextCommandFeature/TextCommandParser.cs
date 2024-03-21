using System;
using System.Collections.Generic;
using System.Data.Common;
using ShapeCreator.Features.TextCommandFeature.Commands;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	
	
	//text command parser utility
	public class TextCommandParser
	{
		private readonly List<string> _commandNames;
		private readonly List<string> _shapeTypes;
		
		private CommandType _command;
		
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
					if (!Enum.TryParse(commandName, out CommandType commandType))
					{
						Debug.Log("Invalid command");
						return null;
					}
					
					commandParams = message.Substring(commandName.Length - 1); //remove the command name from the input
					commandParams = commandParams.Substring(1); //trim first space, can not use TrimStart() because it can change shapeId in case of shapeId starts with space
					
					//fabric method
					return GenerateCommand(commandType, commandParams);
				}
				else
				{
					Debug.Log("Invalid command");
					return null;
				}
			}
			
			
			
			return null;
		}
		
		private ICommand GenerateCommand(CommandType command, string commandParams)
		{

			switch (command)
			{
				case CommandType.Create:
					return new CreateCommand(commandParams);
					
				case CommandType.Destroy:
					return new DestroyCommand(commandParams);
					
				case CommandType.Move:
					return new MoveCommand(commandParams);
					
				
				case CommandType.Rotate:
					return new RotateCommand(commandParams);
					
				
				case CommandType.Scale:
					return new ScaleCommand(commandParams);
					
				
				case CommandType.ChangeColor:
					return new ChangeColorCommand(commandParams);
					
				
				default:
					Debug.Log("Invalid command");
					return null;
			}
			
		}
	}
}
