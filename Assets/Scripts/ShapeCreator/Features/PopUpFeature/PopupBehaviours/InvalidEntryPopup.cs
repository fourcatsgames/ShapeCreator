using Common.GlobalEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShapeCreator.Features.PopUpFeature.PopupBehaviours
{
	public class InvalidEntryPopup : BasePopupBehaviour
	{
		[SerializeField] Button _closeButton;
		[SerializeField] TMP_Text _titleText;
		[SerializeField] TMP_Text _descriptionText;
		
		protected override void AwakePopupBehaviour()
		{
			_closeButton.onClick.AddListener(OnClose);
		}

		public override void Show<TData>(TData data)
		{
			base.Show(data);

			InvalidEntryEvent popupData = data as InvalidEntryEvent;

			if (popupData == null) return;
			
			_titleText.text = popupData.Title;
			_descriptionText.text = popupData.Description;
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
