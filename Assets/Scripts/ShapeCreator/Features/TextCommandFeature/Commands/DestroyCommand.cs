using Common;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class DestroyCommand : ICommand
	{
		private readonly string _shapeId;
		
		public DestroyCommand(string arguments)
		{
			_shapeId = arguments;
		}
		
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.DestroyShape(_shapeId);
		}
	}
}
