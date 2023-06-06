using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _charancter;
    [SerializeField] private float _crouchScaleFactor = 0.6f;
    [SerializeField] private float _crouchMoveSpeedFactor = 0.35f;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private bool _isUnderControl = true;
    [SerializeField] private UnityEvent<Vector3> _moved;

    private float _standartScale;
    private float _standartSpeed;
    private ReactiveVariable<bool> _crouching = new(false);
    private Coroutine _crouchCoroutine;

    public PlayerInputMap InputMap => InputSingletone.Instance;
    public ReactiveVariable<bool> Crouching => _crouching;
    public UnityEvent<Vector3> Moved => _moved;
    public CharacterController Character => _charancter;
	public bool CanGetUp => Physics.Raycast(transform.position + new Vector3(0, _charancter.height / 2, 0), Vector3.up, _standartScale - _standartScale * _crouchScaleFactor) == false;
    public bool IsUnderControl
    {
        get 
        { 
            return _isUnderControl;
        }
        set
        {
            _isUnderControl = value;
            _charancter.enabled = _isUnderControl;
            Cursor.lockState = _isUnderControl ? CursorLockMode.Locked : CursorLockMode.None;
			if (_isUnderControl)
            {
                InputMap.PlayerMovement.Enable();
            }
            else
            {
                InputMap.PlayerMovement.Disable();
            }
		}
    }

    public void DisableControl()
    {
        IsUnderControl = false;
	}

    public void EnableControl()
    {
		IsUnderControl = true;
	}

    public Vector3 MoveDirection
	{
		get
		{
			Vector3 result = InputMap.PlayerMovement.Move.ReadValue<Vector2>();
			result = new Vector3(result.x, 0, result.y);
			result = _charancter.transform.TransformDirection(result);
			return result;
		}
	}

	protected void Awake()
	{
		IsUnderControl = _isUnderControl;

		_standartScale = _charancter.height;
        _standartSpeed = _speed;
	}

	private void OnEnable()
	{
        InputMap.PlayerMovement.Crouch.started += OnCrouchInput;

        _crouching.Changed.AddListener(OnCrouchChanged);
	}

	private void OnDisable()
	{
		InputMap.PlayerMovement.Crouch.started += OnCrouchInput;

		_crouching.Changed.RemoveListener(OnCrouchChanged);
	}

	protected void Update()
    {
        if (_charancter.enabled == false)
        {
            return;
        }
        _charancter.Move(MoveDirection * _speed * Time.deltaTime);
        Moved.Invoke(MoveDirection * _speed);
		AppplyGravitation();
    }

    private void AppplyGravitation()
    {
        _charancter.Move(Physics.gravity.normalized * _gravity * Time.deltaTime);
    }

    private void OnCrouchInput(InputAction.CallbackContext context)
    {
		_crouching.Value = _crouching.Value == false;
	}

    private void OnCrouchChanged(bool newValue)
    {
        if (newValue) StartCrouching();
        else StopCrouching();
    }

    public void StartCrouching()
    {
		_charancter.height = _standartScale * _crouchScaleFactor;
        _speed = _standartSpeed * _crouchMoveSpeedFactor;
        if (_crouchCoroutine != null)
        {
            StopCoroutine(_crouchCoroutine);
        }
	}

    public void StopCrouching()
    {
        if (CanGetUp)
        {
			_charancter.height = _standartScale;
			_speed = _standartSpeed;
		}
        else
        {
            _crouchCoroutine = StartCoroutine(StopCrouchCoroutine());
		}
	}

    private IEnumerator StopCrouchCoroutine()
    {
        while (CanGetUp == false)
        {
            yield return null;
        }
        StopCrouching();
	}
#if UNITY_EDITOR
    private void OnDrawGizmos()
	{
        Vector3 from = transform.position + new Vector3(0, _charancter.height / 2, 0);
        Vector3 to = from + new Vector3(0,_standartScale -_standartScale * _crouchScaleFactor,0);

        Gizmos.color = Color.yellow;
		Gizmos.DrawLine(from, to);
	}

	private void OnValidate()
	{
		if (Application.isPlaying)
        {
            IsUnderControl = _isUnderControl;
        }
	}
#endif
}
