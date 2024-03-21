using System.Collections.Generic;
using Common;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	public class CommandFeatureManager : BaseManager
	{
		[SerializeField] private CommandPanel _commandPanelPrefab;
		public CommandPanel CommandPanelPrefab => _commandPanelPrefab;
		
		[Space(10)]
		[SerializeField] private List<string> _commandNames;
		public List<string> CommandNames => _commandNames;
		
	}
}
