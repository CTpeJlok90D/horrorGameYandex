using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerBox : MonoBehaviour
{
	[SerializeField] private Interacteble _interacteble;
	[SerializeField] private List<GameObject> _fuseObjects;
	[SerializeField] private Item _requestItem;
	[SerializeField] private int _fuseCount = 0;
	[SerializeField] private UnityEvent _powerBoxIsCharged;

	public UnityEvent PowerBoxIsCharged => _powerBoxIsCharged;

	public int FuseCount
	{
		get
		{
			return _fuseCount;
		}
		set
		{
			_fuseCount = value;
			if (value > _fuseObjects.Count)
			{
				_fuseCount = _fuseObjects.Count;
			}

			int count = 0;
			foreach (GameObject gameObject in _fuseObjects)
			{
				count++;
				gameObject.SetActive(count <= _fuseCount);
			}
			if (_fuseCount == _fuseObjects.Count)
			{
				_powerBoxIsCharged.Invoke();
			}
		}
	}

	private void OnEnable()
	{
		_interacteble.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_interacteble.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, InteractContext info)
	{
		while (info.Container.ContainItem(_requestItem))
		{
			info.Container.RemoveItem(_requestItem);
			FuseCount++;
		}
	}

	private void OnValidate()
	{
		FuseCount = _fuseCount;
	}
}
