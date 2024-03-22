using Common;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class ScaleCommand : ICommand
	{
		private readonly string _shapeId;
		private readonly float _scaleRatio;
		
		public ScaleCommand(string arguments)
		{
			_shapeId = arguments.Substring(0, arguments.IndexOf(' '));
			string ratio = arguments.Substring(arguments.Length + 1);
			
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
