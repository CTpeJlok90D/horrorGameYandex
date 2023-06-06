using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ExmindedObjectShower : MonoBehaviour
{
	[SerializeField] private PlayerMovement _movement;
	[SerializeField] private Transform _noteViewPosition;
	[SerializeField] private float _rotateSensivity = 0.5f;
	[SerializeField] private PlayerInteractView _interactView;

	private ExmindedObject _currentObject;
	private UnityEvent _lookStopped;

	private PlayerInputMap InputMap => InputSingletone.Instance;
	private Coroutine _rotateCoroutine;

	private void OnEnable()
	{
		InputMap.LookingItem.StopLooking.started += OnInteractCancel;
		InputMap.LookingItem.Rotate.started += StartRotate;
		InputMap.LookingItem.Rotate.canceled += StopRotation;

	}

	private void OnDisable()
	{
		InputMap.LookingItem.StopLooking.started -= OnInteractCancel;
		InputMap.LookingItem.Rotate.started -= StartRotate;
		InputMap.LookingItem.Rotate.canceled -= StopRotation;
	}

	public void ShowNote(ExmindedObject note, UnityEvent lookStopped)
	{
		_lookStopped = lookStopped;
		_currentObject = Instantiate(note, _noteViewPosition);
		_movement.DisableControl();
		InputMap.Interact.Disable();
		InputMap.LookingItem.Enable();
		_interactView.ShowAlways = true;
	}

	private void OnInteractCancel(InputAction.CallbackContext context)
	{
		StoppLooking();
	}

	private void StoppLooking()
	{
		if (_currentObject != null)
		{
			Destroy(_currentObject.gameObject);
		}

		_movement.EnableControl();
		InputMap.Interact.Enable();
		InputMap.LookingItem.Disable();
		_lookStopped.Invoke();
		_interactView.ShowAlways = false;
	}

	private void StartRotate(InputAction.CallbackContext context)
	{
		_rotateCoroutine = StartCoroutine(RotateItemCoroutine());
	}

	private void StopRotation(InputAction.CallbackContext context)
	{
		StopCoroutine(_rotateCoroutine);
	}
	private IEnumerator RotateItemCoroutine()
	{
		while (_currentObject != null)
		{
			Vector2 mouseDelta = InputMap.LookingItem.MouseDelta.ReadValue<Vector2>() * _rotateSensivity;
			_currentObject.Rotate(mouseDelta);
			yield return null;
		}
	}
}
