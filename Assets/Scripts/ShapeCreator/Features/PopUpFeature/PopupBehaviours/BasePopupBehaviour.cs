using Common;
using ShapeCreator.Features.PopUpFeature.Events;
using UnityEngine;

namespace ShapeCreator.Features.PopUpFeature.PopupBehaviours
{


	public abstract class BasePopupBehaviour : MonoBehaviour
	{

		public virtual void OnClose()
		{
			EventBroadcaster.Broadcast(new EventPopupClosed());
		}

		private void Awake()
		{
			gameObject.SetActive(false);
			enabled = false;

			AwakePopupBehaviour();
		}

		protected abstract void AwakePopupBehaviour();

		public void Show()
		{
			enabled = true;
			gameObject.SetActive(true);
		}
		
		public virtual void Show<TData>(TData data)
		{	
			enabled = true;
			gameObject.SetActive(true);
		}
	}
}
