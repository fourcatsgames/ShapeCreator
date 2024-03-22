using Common;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature.Commands
{
	public class ChangeColorCommand : ICommand
	{
		private readonly string _shapeId;
		private readonly Color _color = Color.white;
		
		public ChangeColorCommand(string arguments)
		{
			_shapeId = arguments.Substring(0, arguments.IndexOf(' '));
			string supposedColor = arguments.Substring(arguments.Length + 1);
			
			if (ColorUtility.TryParseHtmlString(supposedColor, out Color color))
			{
				_color = color;
			}
			
		}
			
		public void Execute()
		{
			ShapeFeature.ShapeFeature shapeFeature = FeatureResolver.GetFeature<ShapeFeature.ShapeFeature>();
			shapeFeature.ChangeShapeColor(_shapeId, _color);
		}
	}
}
