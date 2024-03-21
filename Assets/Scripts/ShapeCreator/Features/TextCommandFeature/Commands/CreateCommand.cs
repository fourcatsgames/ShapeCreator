using System;
using Common;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	[Serializable]
	public class CreateCommand : ICommand
	{
		private string _shapeId;
		private ShapeType _shapeType;
		
		public CreateCommand(string arguments)
		{
			//get string before first space
			string supposedShapeType = arguments.Substring(0, arguments.IndexOf(' '));
			string shapeId = arguments.Substring(supposedShapeType.Length + 1);
			
			_shapeId = shapeId;
			
			if (Enum.TryParse(supposedShapeType, out ShapeType shape))
			{
				_shapeType = shape;
			}
		}
		
		public void Execute()
		{
			var shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.CreateShape(_shapeId, _shapeType);
		}
	}
}
