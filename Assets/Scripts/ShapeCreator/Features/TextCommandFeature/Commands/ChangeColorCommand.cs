using System.Collections.Generic;
using Common;
using Common.GlobalEvents;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class ChangeColorCommand : ICommand
	{
		private const string INCORRECT_FORMAT = "Incorrect command format.";
		private readonly string _shapeId;
		private readonly Color _color = Color.white;
		
		public ChangeColorCommand(string arguments, List<string> availableColors)
		{
			if (arguments.IndexOf(' ') == -1)
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent(INCORRECT_FORMAT));
				return;
			}
			
			_shapeId = arguments.Substring(0, arguments.IndexOf(' '));
			
			if (_shapeId.Length == 0 || _shapeId.Length >= arguments.Length)
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent(INCORRECT_FORMAT));
				return;
			}
			
			string supposedColor = arguments.Substring(_shapeId.Length + 1);
			if (availableColors.Contains(supposedColor))
			{
				_color = ColorUtility.TryParseHtmlString(supposedColor, out Color color) ? color : Color.white;
			}
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent("Only the following colors are available:  White, Black, Red, Green, Blue"));
			}
		}
			
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.ChangeShapeColor(_shapeId, _color);
		}
	}
}
