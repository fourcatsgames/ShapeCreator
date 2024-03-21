using UnityEngine;

namespace ShapeCreator.Features.TextCommandFeature
{
	[SerializeField]
	public interface ICommand
	{
		void Execute();
	}
}
