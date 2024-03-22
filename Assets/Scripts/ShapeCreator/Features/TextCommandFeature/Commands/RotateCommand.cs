using Common;
using Common.GlobalEvents;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class RotateCommand : ICommand
	{
		private const string INCORRECT_FORMAT = "Incorrect command format.";
		private readonly string _shapeId;
		private readonly float _angle;
		
		public RotateCommand(string arguments)
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
			
			string angle = arguments.Substring(_shapeId.Length + 1);
			
			if (float.TryParse(angle, out float a))
			{
				_angle = a;
			}
		}

		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.RotateShape(_shapeId, _angle);
		}
	}
}
