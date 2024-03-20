using UnityEngine;

namespace Common
{
	public class BaseManager : MonoBehaviour
	{
		public Transform Layer => _layer;
		[SerializeField] private Transform _layer;
	}
}
