using System.Collections.Generic;
using Common;
using Common.GlobalEvents;
using UnityEngine;

namespace ShapeCreator.Features.ShapeFeature
{
	public class ShapeFeature : IFeature
	{
		private ShapeFeatureManager _shapeFeatureManager;
		private Dictionary<string, BaseShape> _shapes = new Dictionary<string, BaseShape>();

		public void Inject(BaseManager manager)
		{
			_shapeFeatureManager = (ShapeFeatureManager)manager;
		}

		public void CreateShape(string shapeId, ShapeType shapeType)
		{
			// check if shape exists
			if (_shapes.ContainsKey(shapeId))
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent($"Shape with id {shapeId} already exists"));
				return;
			}
			
			BaseShape shapePrefab = _shapeFeatureManager.GetShapePrefab(shapeType.ToString());
			BaseShape shape = Object.Instantiate(shapePrefab, _shapeFeatureManager.Layer);
			_shapes.Add(shapeId, shape);
			
		}

		public void DestroyShape(string shapeId)
		{
			// Destroy shape
			if (TryGetShape(shapeId, out BaseShape shape))
			{
				_shapes.Remove(shapeId);
				Object.Destroy(shape.gameObject);
			}
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent($"Shape with id {shapeId} does not exist"));
			}
		}

		public void MoveShape(string shapeId, Vector2 position)
		{
			// Move shape
			if (TryGetShape(shapeId, out BaseShape shape))
			{
				shape.transform.localPosition = position;
			}
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent($"Shape with id {shapeId} does not exist"));
			}
		}

		public void RotateShape(string shapeId, float angle)
		{
			// Rotate shape
			if (TryGetShape(shapeId, out BaseShape shape))
			{
				shape.transform.Rotate(Vector3.forward, angle);
			}
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent($"Shape with id {shapeId} does not exist"));
			}
		}

		public void ScaleShape(string shapeId, float scale)
		{
			// Scale shape
			if (TryGetShape(shapeId, out BaseShape shape))
			{
				shape.transform.localScale = new Vector3(scale, scale, 1);
			}
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent($"Shape with id {shapeId} does not exist"));
			}
		}

		public void ChangeShapeColor(string shapeId, Color color)
		{
			// Change shape color
			if (TryGetShape(shapeId, out BaseShape shape))
				shape.ChangeColor(color);
			else
			{
				EventBroadcaster.Broadcast(new InvalidEntryEvent($"Shape with id {shapeId} does not exist"));
			}
		}

		private bool TryGetShape(string shapeId, out BaseShape shape)
		{
			return _shapes.TryGetValue(shapeId, out shape);
		}
	}
}
