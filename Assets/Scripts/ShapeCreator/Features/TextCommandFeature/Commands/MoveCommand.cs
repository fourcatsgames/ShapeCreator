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
			string coords = arguments.Substring(arguments.Length + 1);
			
			string[] coordsArray = coords.Split(',');
			
			if (coordsArray.Length >= 2)
			{
				if (float.TryParse(coordsArray[0], out float x))
				{
					_coordsVector.x = x;
				}
				
				if (float.TryParse(coordsArray[1], out float y))
				{
					_coordsVector.y = y;
				}
				
			}
			else
			{
				Debug.Log("Invalid command");
				return;
			}
			
			
			
		}
		
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.MoveShape(_shapeId, _coordsVector);
		}
	}
}
