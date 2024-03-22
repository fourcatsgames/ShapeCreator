using System;
using System.Collections.Generic;
using Common;
using Common.GlobalEvents;
using ShapeCreator.Features.TextCommandFeature.Commands;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	
	
	//text command parser utility
	public class TextCommandParser
	{
		private const string INCORRECT_FORMAT = "Incorrect command format.";
		
		private readonly List<string> _commandNames;
		private readonly List<string> _shapeTypes;
		
		private CommandType _command;
		private List<string> _availableColors;

		public TextCommandParser(List<string> commandNames, List<string> colors)
		{
			_commandNames = commandNames;
			_availableColors = colors;
		}
		
		public ICommand Parse(string message)
		{
			message = Utils.RemoveZWSP(message,string.Empty);
			
			foreach (string commandName in _commandNames)
			{
				//if command name found and it is first
				if (message.Contains(commandName) && message.IndexOf(commandName, System.StringComparison.Ordinal) == 0)
				{
					string fixedCommandName = commandName.Replace(" ", string.Empty);
					if (!Enum.TryParse(fixedCommandName, out CommandType commandType))
					{
						EventBroadcaster.Broadcast(new InvalidEntryEvent("Only the following commands are available:  Create, Destroy, Move, Rotate, Scale, Change Color"));
						return null;
					}
					
					if (message.Length <= commandName.Length)
					{
						EventBroadcaster.Broadcast(new InvalidEntryEvent(INCORRECT_FORMAT));
						return null;
					}
					
					string commandParams = message.Substring(commandName.Length + 1); //trim first space, can not use TrimStart() because it can change shapeId in case of shapeId starts with space

					//fabric method
					return GenerateCommand(commandType, commandParams);
				}
			}

			EventBroadcaster.Broadcast(new InvalidEntryEvent("Only the following commands are available:  Create, Destroy, Move, Rotate, Scale, Change Color"));
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
					return new ChangeColorCommand(commandParams, _availableColors);
				
				default:
					Debug.Log("Invalid command");
					return null;
			}
			
		}
	}
}
