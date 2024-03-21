using System.Collections.Generic;
using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	//scriptable object
	[CreateAssetMenu(fileName = "CommandsData", menuName = "CommandsData")]
	
	public class CommandsData : ScriptableObject
	{
		List<ICommand> _commands;
	}
}
