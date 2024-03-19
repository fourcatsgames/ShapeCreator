using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShapeCreator.Features.ShapeFeature
{
	public class BaseShape : MonoBehaviour
	{
		[SerializeField] private Image _shapeImage;

		private void Awake() { }
		private void Start()
		{
			throw new NotImplementedException();
		}

		private void OnDestroy()
		{
			throw new NotImplementedException();
		}

		public void ChangeColor(Color color)
		{
			_shapeImage.color = color;
		}
	}
}
