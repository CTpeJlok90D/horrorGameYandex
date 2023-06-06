using System.Collections;
using UnityEditor;
using UnityEngine;

public class PullOutShelf : MonoBehaviour
{
	[SerializeField] private Transform _shelf;
    [SerializeField] private Vector3 _openPosition;
    [SerializeField] private float _openTime = 1;
    [SerializeField] private Interacteble _handle;
	[SerializeField] private bool _isOpened = false;

	private Vector3 _closePosition;
	private Coroutine _moveCoroutine;

	private void Awake()
	{
		_closePosition = _shelf.localPosition;
	}

	private void OnEnable()
	{
		_handle.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_handle.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, PlayerInfo info)
	{
		if (_moveCoroutine != null)
		{
			return;
		}

		if (_isOpened)
		{
			Close();
		}
		else
		{
			Open();
		}
	}

	public void Open()
	{
		_isOpened = true;
		_moveCoroutine = StartCoroutine(MoveCoroutine(_openPosition, _openTime));
	}

	public void Close()
	{
		_isOpened = false;
		_moveCoroutine = StartCoroutine(MoveCoroutine(_closePosition, _openTime));
	}

	private IEnumerator MoveCoroutine(Vector3 newPosition, float moveTime)
	{
		Vector3 oldPosition = _shelf.localPosition;
		for (float i = moveTime; i > 0; i -= Time.deltaTime)
		{
			_shelf.transform.localPosition = Vector3.Lerp(newPosition, oldPosition, i / moveTime);
			yield return null;
		}

		_moveCoroutine = null;
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(PullOutShelf))]
public class PullOutShelfEditor : Editor
{
	public new PullOutShelf target => base.target as PullOutShelf;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (Application.isPlaying == false)
		{
			return;
		}
		if (GUILayout.Button("Open"))
		{
			target.Open();
		}
		if (GUILayout.Button("Close"))
		{
			target.Close();
		}
	}
}
#endif
