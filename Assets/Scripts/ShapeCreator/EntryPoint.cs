using Common;
using Common.GlobalEvents;
using ShapeCreator.Features.PopUpFeature;
using ShapeCreator.Features.PopUpFeature.PopupBehaviours;
using ShapeCreator.Features.ShapeFeature;
using ShapeCreator.Features.TextCommandFeature;
using UnityEngine;

namespace ShapeCreator
{
	public class EntryPoint : MonoBehaviour
	{

		[Header("Managers")]
		[SerializeField] private BaseManager _popupManager;
		[SerializeField] private BaseManager _shapeManager;
		[SerializeField] private BaseManager _commandManager;

		private void Awake() { }

		private void Start()
		{
			PopUpFeature popupFeature = new PopUpFeature();
			popupFeature.Inject(_popupManager);
			FeatureResolver.AddFeature(popupFeature);

			ShapeFeature shapeFeature = new ShapeFeature();
			shapeFeature.Inject(_shapeManager);
			FeatureResolver.AddFeature(shapeFeature);

			TextCommandFeature textCommandFeature = new TextCommandFeature();
			textCommandFeature.Inject(_commandManager);
			FeatureResolver.AddFeature(textCommandFeature);

			textCommandFeature.Init();
			
			EventBroadcaster.Add<InvalidEntryEvent>(OnInvalidEntryEvent);
		}
		
		private void OnInvalidEntryEvent(InvalidEntryEvent e)
		{
			PopUpFeature popupFeature = FeatureResolver.GetFeature<PopUpFeature>();
			popupFeature.AddPopUp<InvalidEntryPopup,InvalidEntryEvent>(e);
		}

	}
	
}
