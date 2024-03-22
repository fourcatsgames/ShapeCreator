using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShapeCreator.Features.ShapeFeature
{
	public class BaseShape : MonoBehaviour
	{
		[SerializeField] private Image _shapeImage;
		
		public void ChangeColor(Color color)
		{
			_shapeImage.color = color;
		}
	}
}
