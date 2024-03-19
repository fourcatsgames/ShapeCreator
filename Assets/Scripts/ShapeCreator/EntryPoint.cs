using Common;
using ShapeCreator.Features.PopUpFeature;
using ShapeCreator.Features.ShapeFeature;
using UnityEngine;

namespace ShapeCreator
{
	public class EntryPoint : MonoBehaviour
	{

		[Header("Managers")]
		[SerializeField] private PopupFeatureManager _popupManager;
		[SerializeField] private ShapeFeatureManager _shapeManager;

		private void Awake() { }

		private void Start()
		{
			PopUpFeature popupFeature = new PopUpFeature();
			popupFeature.Inject(_popupManager);
			FeatureResolver.AddFeature(popupFeature);

			ShapeFeature shapeFeature = new ShapeFeature();
			shapeFeature.Inject(_shapeManager);
			FeatureResolver.AddFeature(shapeFeature);

			shapeFeature.CreateShape("test", "Triangle");
		}

	}
}
