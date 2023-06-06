using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CodeDoor : MonoBehaviour
{
	[SerializeField] private Door _door;
	[SerializeField] private string _code;
	[SerializeField] private Interacteble _interact;
	[SerializeField] private string _input;
	[SerializeField] private GameObject _codeInputCanvas;

	private PlayerMovement _movement;

	public string Input
	{
		get
		{
			return _input;
		}
		set
		{
			_input = value;
			OnFieldValueChange(value);
		}
	}

	private void OnEnable()
	{
		_interact.Interacted.AddListener(OnIneract);
	}

	private void OnDisable()
	{
		_interact.Interacted.RemoveListener(OnIneract);

	}

	private void OnFieldValueChange(string value)
	{
		if (_input == _code)
		{
			_door.Open();
			HideCodeInputUI();
		}
	}

	private void OnIneract(Interacteble sender, PlayerInfo info)
	{
		if (_door.IsOpen)
		{
			_door.Close();
			return;
		}
		_movement = info.PlayerMovement;
		_movement.DisableControl();
		ShowCodeInputUI();

		InputSingletone.Instance.Interact.Interact.started += HideCodeInputUI;
	}	

	private void ShowCodeInputUI()
	{
		_codeInputCanvas.SetActive(true);
	}

	private void HideCodeInputUI(InputAction.CallbackContext context)
	{
		HideCodeInputUI();
	}

	private void HideCodeInputUI()
	{
		_movement.EnableControl();
		_codeInputCanvas.SetActive(false);

		InputSingletone.Instance.Interact.Interact.started -= HideCodeInputUI;
	}
}
