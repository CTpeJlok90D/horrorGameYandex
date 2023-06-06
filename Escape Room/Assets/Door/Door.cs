using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{

	[SerializeField] private Transform _doorTransform;
	[SerializeField] private float _openTime = 1;
	[SerializeField] private Quaternion _openRotation;
	[SerializeField] private bool _isOpen = false;
	[SerializeField] private UnityEvent _opened;
	[SerializeField] private UnityEvent _closed;
	[SerializeField] private bool _canBeOpenedByEnemy = true;

	private Quaternion _closeRotation;
	private Coroutine _moveRotationCoroutine;

	public UnityEvent Opened => _opened;
	public UnityEvent Closeed => _closed;


	public bool IsOpen
	{
		get
		{
			return _isOpen;
		}
		set
		{
			_isOpen = value;
			if (_isOpen)
			{
				Open();
			}
			else
			{
				Close();
			}
		}
	}

	public bool CanBeOpenedByEnemy => _canBeOpenedByEnemy;

	private void Awake()
	{
		_closeRotation = _doorTransform.localRotation;
		if (_isOpen)
		{
			_doorTransform.localRotation = _openRotation;
		}
		else
		{
			_doorTransform.localRotation = _closeRotation;
		}
	}
	public void Open()
	{
		if (_moveRotationCoroutine != null)
		{
			return;
		}
		_isOpen = true;
		_moveRotationCoroutine = StartCoroutine(MoveDoorCoroutine(_openRotation, _openTime));
		_opened.Invoke();
	}

	public void Close()
	{
		if (_moveRotationCoroutine != null)
		{
			return;
		}
		_isOpen = false;
		_moveRotationCoroutine = StartCoroutine(MoveDoorCoroutine(_closeRotation, _openTime));
		_closed.Invoke();
	}

	private IEnumerator MoveDoorCoroutine(Quaternion newQuternion, float openTime)
	{
		Quaternion oldRotation = _doorTransform.localRotation;
		for (float i = openTime; i > 0; i -= Time.deltaTime)
		{
			_doorTransform.localRotation = Quaternion.Lerp(newQuternion, oldRotation, i / openTime);
			yield return null;
		}
		_moveRotationCoroutine = null;
	}
}