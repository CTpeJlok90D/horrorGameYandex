using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CodeElement : MonoBehaviour
{
	[SerializeField] private ReactiveVariable<int> _currentNumber = new(0);
	[SerializeField] private Button _upButton;
	[SerializeField] private Button _downButton;
	[SerializeField] private TMP_Text _view;

	public UnityEvent<int> NumberChanged => _currentNumber.Changed;
	public int CurrentNumber
	{
		get
		{
			return _currentNumber.Value;
		}
		set
		{
			_currentNumber.Value = value;
			if (value < 0)
			{
				_currentNumber.Value = 9;
			}
			if (value > 9)
			{
				_currentNumber.Value = 0;
			}
			_view.text = _currentNumber.Value.ToString();
		}
	}

	private void OnEnable()
	{
		_upButton.onClick.AddListener(OnButtonUpClick);
		_downButton.onClick.AddListener(OnButtonDownClick);
	}

	private void OnDisable()
	{
		_upButton.onClick.RemoveListener(OnButtonUpClick);
		_downButton.onClick.RemoveListener(OnButtonDownClick);
	}

	private void OnButtonUpClick()
	{
		CurrentNumber++;
	}

	private void OnButtonDownClick()
	{
		CurrentNumber--;
	}
}
