using System.Collections.Generic;
using UnityEngine;

namespace ShapeCreator.Features.ShapeFeature
{
	public class ShapeFeatureManager : MonoBehaviour
	{
		//public List<string> ShapeNames => _shapeNames;
		public GameObject ShapeLayer => _shapeLayer;

		[SerializeField] private GameObject _shapeLayer;
		[Space(10)]
		[SerializeField] private List<string> _shapeNames;
		[SerializeField] private List<BaseShape> _shapePrefabs;

		public bool TryGetShapePrefab(string shapeType, out BaseShape shapePrefab)
		{
			for (int i = 0; i < _shapeNames.Count; i++)
			{
				if (_shapeNames[i] == shapeType)
				{
					shapePrefab = _shapePrefabs[i];
					return true;
				}
			}

			shapePrefab = null;
			return false;
		}
	}
}
