using System.Collections.Generic;
using Common;
using ShapeCreator.Features.PopUpFeature.PopupBehaviours;
using UnityEngine;

namespace ShapeCreator.Features.PopUpFeature
{
	public class PopupFeatureManager : BaseManager
	{
		[SerializeField] private List<BasePopupBehaviour> _popUpPrefabs;

		

		public bool TryGetPopup<T>(out T p) where T : BasePopupBehaviour
		{
			foreach (BasePopupBehaviour f in _popUpPrefabs)
			{
				if (f is not T specificPopup) continue;

				p = specificPopup;
				return true;
			}

			p = null;
			return false;
		}
	}
}
