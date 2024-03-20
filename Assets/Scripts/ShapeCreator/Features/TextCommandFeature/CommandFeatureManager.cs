using Common;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	public class CommandFeatureManager : BaseManager
	{
		[SerializeField] private CommandPanel _commandPanelPrefab;
		public CommandPanel CommandPanelPrefab => _commandPanelPrefab;
	}
}
