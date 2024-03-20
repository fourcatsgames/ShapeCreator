using Common;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	public class TextCommandFeature : IFeature
	{
		private CommandFeatureManager _commandFeatureManager;
		private CommandPanel _commandPanel;
		
		public void Inject(BaseManager manager)
		{
			_commandFeatureManager = (CommandFeatureManager) manager;
		}
		
		public void Init()
		{
			_commandPanel = Object.Instantiate(_commandFeatureManager.CommandPanelPrefab, _commandFeatureManager.Layer);
			_commandPanel.SendButton.onClick.AddListener(OnSendButtonClick);
		}
		
		private void OnSendButtonClick()
		{
			
		}
		
		public void Destroy()
		{
			_commandPanel.SendButton.onClick.RemoveListener(OnSendButtonClick);
			Object.Destroy(_commandPanel.gameObject);
		}
	}
}
