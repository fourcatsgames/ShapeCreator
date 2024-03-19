using System.Collections.Generic;
using Common;
using ShapeCreator.Features.PopUpFeature.Events;
using ShapeCreator.Features.PopUpFeature.PopupBehaviours;
using UnityEngine;

namespace ShapeCreator.Features.PopUpFeature
{
	public class PopUpFeature : IFeature
	{
		private PopupFeatureManager _popupFeatureManager;
		private Queue<BasePopupBehaviour> _popupsQueue = new Queue<BasePopupBehaviour>();

		private bool _isPopupOpened;

		public PopUpFeature()
		{
			EventBroadcaster.Add<EventPopupClosed>(OnPopupClosed);
		}

		//will be shown as soon as possible
		public void AddPopUp<T>() where T : BasePopupBehaviour
		{
			if (_popupFeatureManager.TryGetPopup(out T popup))
			{
				_popupsQueue.Enqueue(popup);
			}

			if (_isPopupOpened) return;

			ShowPopup();
		}

		private void ShowPopup()
		{
			//check if queue is empty
			if (_popupsQueue.Count == 0)
			{
				_isPopupOpened = false;
				return;
			}

			_isPopupOpened = true;

			//get popup from queue
			BasePopupBehaviour popup = _popupsQueue.Dequeue();
			GameObject p = GameObject.Instantiate(popup.gameObject, _popupFeatureManager.PopupLayer);
			popup = p.GetComponent<BasePopupBehaviour>();
			popup.Show();
		}

		private void OnPopupClosed(EventPopupClosed e)
		{
			ShowPopup();
		}

		public void Inject(PopupFeatureManager popupManager)
		{
			_popupFeatureManager = popupManager;
		}
	}
}
