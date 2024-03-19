using UnityEngine;
using UnityEngine.UI;

namespace ShapeCreator.Features.PopUpFeature.PopupBehaviours
{
	public class MessagePopup : BasePopupBehaviour
	{
		[SerializeField] Button _closeButton;

		protected override void AwakePopupBehaviour()
		{
			_closeButton.onClick.AddListener(OnClose);
		}

		public override void OnClose()
		{
			base.OnClose();
			Destroy(gameObject);
		}

		private void OnDestroy()
		{
			_closeButton.onClick.RemoveListener(OnClose);
		}
	}
}
