using System.Collections.Generic;
using Common;
using ShapeCreator.Features.PopUpFeature.Events;
using ShapeCreator.Features.PopUpFeature.PopupBehaviours;
using UnityEngine;
using Object = System.Object;


namespace ShapeCreator.Features.PopUpFeature
{
	public class PopUpFeature : IFeature
	{
		private PopupFeatureManager _popupFeatureManager;
		private Queue<DataContainer<BasePopupBehaviour,Object>> _popupsQueue = new Queue<DataContainer<BasePopupBehaviour, Object>>();

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
				_popupsQueue.Enqueue(new DataContainer<BasePopupBehaviour, Object>(popup, null));
			}

			if (_isPopupOpened) return;

			ShowPopup();
		}

		public void AddPopUp<T,TData>(TData data) where T : BasePopupBehaviour where TData : class
		{
			if (_popupFeatureManager.TryGetPopup(out T popup))
			{
				_popupsQueue.Enqueue(new DataContainer<BasePopupBehaviour, object>(popup, data));
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
			DataContainer<BasePopupBehaviour, Object> container = _popupsQueue.Dequeue();
			GameObject p = GameObject.Instantiate(container.Popup.gameObject, _popupFeatureManager.Layer);
			
			BasePopupBehaviour popup = p.GetComponent<BasePopupBehaviour>();
			popup.Show(container.Data);
		}

		private void OnPopupClosed(EventPopupClosed e)
		{
			ShowPopup();
		}

		public void Inject(BaseManager popupManager)
		{
			_popupFeatureManager = (PopupFeatureManager)popupManager;
		}
		
		public void Destroy()
		{
			EventBroadcaster.Remove<EventPopupClosed>(OnPopupClosed);
		}
	}
	
	public class NODATA { }

	class DataContainer<T,TData> where T : BasePopupBehaviour where TData : class
	{
		public T Popup { get; }
		public TData Data { get; }

		public DataContainer(T popup, TData data) 
		{
			Popup = popup;
			Data = data;
			
		}
	}
}
