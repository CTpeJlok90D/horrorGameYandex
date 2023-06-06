using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlaceForHide : MonoBehaviour
{
	[SerializeField] private Interacteble _interacteble;
	[SerializeField] private Animator _animator;
	[SerializeField] private Transform _playerPositionObject;
	[SerializeField] private string _animatiorBoolValue = "Entered";
	[SerializeField] private string _throwAnimationTrigger = "ThrowTrigger";
	[SerializeField] private UnityEvent _playerHided;
	[SerializeField] private UnityEvent _playerExited;
	[SerializeField] private PlayerInteractView _interactView;

	private PlayerMovement _playerMovement;
	private CharacterController _character;

	public UnityEvent PlayerHided => _playerHided;
	public UnityEvent PlayerExided => _playerExited;
	public PlayerMovement PlayerMovement => _playerMovement;

	public bool PlayerInside => _playerMovement != null;
	private void OnEnable()
	{
		_interacteble.Interacted.AddListener(Interact);
	}

	private void OnDisable()
	{
		_interacteble.Interacted.RemoveListener(Interact);
	}

	private void Interact(Interacteble sender, PlayerInfo info)
	{
		if (PlayerInside) FreePlayer();
		else HidePlayer(info.PlayerMovement, info.Character);
	}

	public void HidePlayer(PlayerMovement player, CharacterController character)
	{
		_playerMovement = player;
		_playerMovement.transform.SetParent(_playerPositionObject);
		_playerMovement.transform.localPosition = Vector3.zero;
		_playerMovement.transform.localRotation = Quaternion.identity;
		_character = character;
		player.IsUnderControl = false;
		_animator.SetBool(_animatiorBoolValue, true);
		_interacteble.CanInteract = false;
		_character.enabled = false;
		_playerHided.Invoke();

		_interactView.ShowAlways = true;
		InputSingletone.Instance.Interact.Interact.started += FreePlayer;
	}

	public void ThrowPlayer()
	{
		_animator.SetTrigger(_throwAnimationTrigger);
		_animator.SetBool(_animatiorBoolValue, false);
		if (_playerMovement == null)
		{
			return;
		}
		_playerMovement.IsUnderControl = true;
		_character.enabled = true;
		_playerMovement.transform.SetParent(null);
		_playerMovement = null;
	}

	private void FreePlayer(InputAction.CallbackContext context) => FreePlayer();

	public void FreePlayer()
	{
		_animator.SetBool(_animatiorBoolValue, false);
		_interacteble.CanInteract = true;

		_interactView.ShowAlways = false;
		InputSingletone.Instance.Interact.Interact.started -= FreePlayer;
	}

	public void OnAnimationExitEnd()
	{
		_playerMovement.IsUnderControl = true;
		_character.enabled = true;
		_playerMovement.transform.SetParent(null);
		_playerMovement = null;
		_character = null;
		_playerExited.Invoke();
	}
}
