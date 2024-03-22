using Common;
using Common.GlobalEvents;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class MoveCommand : ICommand
	{
		private const string INCORRECT_FORMAT = "Incorrect command format.";
		private readonly Vector2 _coordsVector = new Vector2(0,0);
		private readonly string _shapeId;
		
		public MoveCommand(string arguments)
		{
			//command format: Move mySuperSquare -10, 20
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
			
			string coords = arguments.Substring(_shapeId.Length + 1);
			string[] parts = coords.Split(',');

			
			if (float.TryParse(parts[0], out float x) && float.TryParse(parts[1], out float y))
			{
				// Create a Vector2 using the parsed coordinates
				_coordsVector = new Vector2(x, y);
				
			}
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent("Invalid coordinates format. Please use the following format: Move mySuperSquare -10, 20"));
			}
			
		}
		
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.MoveShape(_shapeId, _coordsVector);
		}
	}
}
