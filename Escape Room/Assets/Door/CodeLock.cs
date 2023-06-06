using UnityEngine;

public class CodeLock : MonoBehaviour
{
	[SerializeField] private CodeDoor _door;
	[SerializeField] private CodeElement[] _elements;

	private void OnEnable()
	{
		foreach (CodeElement element in _elements)
		{
			element.NumberChanged.AddListener(OnPasswordChange);
		}
	}

	private void OnDisable()
	{
		foreach (CodeElement element in _elements)
		{
			element.NumberChanged.RemoveListener(OnPasswordChange);
		}
	}

	private void OnPasswordChange(int value) => OnPasswordChange();
	private void OnPasswordChange()
	{
		string result = "";
		foreach (CodeElement element in _elements)
		{
			result += element.CurrentNumber.ToString();
		}

		_door.Input = result;
	}
}
