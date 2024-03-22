using Common;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class RotateCommand : ICommand
	{
		private readonly string _shapeId;
		private readonly float _angle;
		
		public RotateCommand(string arguments)
		{
			_shapeId = arguments.Substring(0, arguments.IndexOf(' '));
			string angle = arguments.Substring(arguments.Length + 1);
			
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
