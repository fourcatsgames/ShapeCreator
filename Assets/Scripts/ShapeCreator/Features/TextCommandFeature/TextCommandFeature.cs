using Common;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	public class TextCommandFeature : IFeature
	{
		private CommandFeatureManager _commandFeatureManager;
		private CommandPanel _commandPanel;
		private TextCommandParser _textCommandParser;
		
		public void Inject(BaseManager manager)
		{
			_commandFeatureManager = (CommandFeatureManager) manager;
		}
		
		public void Init()
		{
			_textCommandParser = new TextCommandParser(_commandFeatureManager.CommandNames, _commandFeatureManager.AvailableColorNames);
			_commandPanel = Object.Instantiate(_commandFeatureManager.CommandPanelPrefab, _commandFeatureManager.Layer);
			_commandPanel.SendButton.onClick.AddListener(OnSendButtonClick);
		}
		
		private void OnSendButtonClick()
		{
			Debug.Log("[TEXT_COMMAND]" + _commandPanel.Message);
			
			ICommand command = _textCommandParser.Parse(_commandPanel.Message);
			command?.Execute();
		}
		
		public void Destroy()
		{
			_commandPanel.SendButton.onClick.RemoveListener(OnSendButtonClick);
		}
	}
}
