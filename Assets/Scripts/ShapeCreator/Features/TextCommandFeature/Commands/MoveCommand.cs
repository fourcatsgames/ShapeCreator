using Common;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class MoveCommand : ICommand
	{
		private readonly Vector2 _coordsVector = new Vector2(0,0);
		private readonly string _shapeId;
		
		public MoveCommand(string arguments)
		{
			//command format: Move mySuperSquare -10, 20
			
			_shapeId = arguments.Substring(0, arguments.IndexOf(' '));
			string coords = arguments.Substring(_shapeId.Length + 1);
			
			string[] parts = coords.Split(',');

			
			if (float.TryParse(parts[0].Trim(), out float x) && float.TryParse(parts[1].Trim(), out float y))
			{
				// Create a Vector2 using the parsed coordinates
				_coordsVector = new Vector2(x, y);
				
			}
			else
			{
				Debug.LogError("Failed to parse coordinates as floats.");
			}
			
		}
		
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.MoveShape(_shapeId, _coordsVector);
		}
	}
}
