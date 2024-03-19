using System.Collections.Generic;
using ShapeCreator.Features.PopUpFeature.PopupBehaviours;
using UnityEngine;

namespace ShapeCreator.Features.PopUpFeature
{
	public class PopupFeatureManager : MonoBehaviour
	{
		[SerializeField] private List<BasePopupBehaviour> _popUpPrefabs;

		public Transform PopupLayer => _popupLayer;
		[SerializeField] private Transform _popupLayer;

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
