using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShapeCreator.Features.TextCommandFeature
{
	public class CommandPanel : MonoBehaviour
	{
		public Button SendButton => _sendButton;
		public String Message => _inputField.text;
		
		[SerializeField] private TMP_Text _inputField;
		[SerializeField] private Button _sendButton;
		
	}
}
