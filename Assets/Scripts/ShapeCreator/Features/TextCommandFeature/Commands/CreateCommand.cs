using System;
using Common;
using Common.GlobalEvents;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	[Serializable]
	public class CreateCommand : ICommand
	{
		private const string INCORRECT_FORMAT = "Incorrect command format.";
		private string _shapeId;
		private ShapeType _shapeType;
		
		public CreateCommand(string arguments)
		{
			//get string before first space
			if (arguments.IndexOf(' ') == -1)
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent(INCORRECT_FORMAT));
				return;
			}
			
			string supposedShapeType = arguments.Substring(0, arguments.IndexOf(' '));
			
			if (supposedShapeType.Length == 0 || supposedShapeType.Length >= arguments.Length)
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent(INCORRECT_FORMAT));
				return;
			}
			
			string shapeId = arguments.Substring(supposedShapeType.Length + 1);
			
			_shapeId = shapeId;
			
			if (Enum.TryParse(supposedShapeType, out ShapeType shape))
			{
				_shapeType = shape;
			}
			else
			{
				_shapeType = ShapeType.None;
				EventBroadcaster.Broadcast(new InvalidEntryEvent("Only the following shapes are available:  Circle, Square, Triangle"));
			}
		}
		
		public void Execute()
		{
			if (_shapeType == ShapeType.None || string.IsNullOrEmpty(_shapeId))
			{
				return;
			}
			
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.CreateShape(_shapeId, _shapeType);
		}
	}
}
