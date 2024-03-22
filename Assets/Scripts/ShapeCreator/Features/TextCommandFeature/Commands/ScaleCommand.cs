using Common;
using Common.GlobalEvents;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class ScaleCommand : ICommand
	{
		private const string INCORRECT_FORMAT = "Incorrect command format.";
		private readonly string _shapeId;
		private readonly float _scaleRatio;
		
		public ScaleCommand(string arguments)
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
			
			string ratio = arguments.Substring(_shapeId.Length + 1);
			
			if (float.TryParse(ratio, out float r))
			{
				_scaleRatio = r;
			}
		}
		
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.ScaleShape(_shapeId, _scaleRatio);
		}
	}
}
