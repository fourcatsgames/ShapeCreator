using System.Collections.Generic;
using Common;
using UnityEngine;

namespace ShapeCreator.Features.ShapeFeature
{
	public class ShapeFeatureManager : BaseManager
	{
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

		public BaseShape GetShapePrefab(string shapeType)
		{
			for (int i = 0; i < _shapeNames.Count; i++)
			{
				if (_shapeNames[i] == shapeType)
				{
					return _shapePrefabs[i];
				}
			}

			return null;
		}
	}
}
