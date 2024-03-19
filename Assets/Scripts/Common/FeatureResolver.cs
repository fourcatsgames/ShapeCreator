using System.Collections.Generic;

namespace Common
{
	public static class FeatureResolver
	{
		private static readonly List<IFeature> _features = new List<IFeature>();

		public static void AddFeature(IFeature feature)
		{
			_features.Add(feature);
		}

		public static T GetFeature<T>() where T : class, IFeature
		{
			foreach (IFeature f in _features)
			{
				if (f is not T specificFeature) continue;
				return specificFeature;
			}

			return null;
		}

		public static bool TryGetFeature<T>(out T feature) where T : class, IFeature
		{
			foreach (IFeature f in _features)
			{
				if (f is not T specificFeature) continue;
				feature = specificFeature;
				return true;
			}

			feature = null;
			return false;
		}
	}
}
