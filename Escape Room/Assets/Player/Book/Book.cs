using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Book : MonoBehaviour
{
	[SerializeField] private Collider _noiseCollider;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _noiseTime = 0.4f;
	[SerializeField] private float _liveTime = 10f;

	private Coroutine NoiseCoroutineField;
	private Coroutine LiveCoroutineField;

	public Rigidbody Rigidbody => _rigidbody;

	private void Awake()
	{
		_rigidbody.isKinematic = true;
		_noiseCollider.enabled = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (NoiseCoroutineField != null)
		{
			StopCoroutine(NoiseCoroutineField);
		}
		if (LiveCoroutineField != null)
		{
			StopCoroutine(LiveCoroutineField);
		}

		NoiseCoroutineField = StartCoroutine(NoiseCoroutine());
		LiveCoroutineField = StartCoroutine(LiveCoroutine());
	}

	public void RemoveBook()
	{
		Destroy(this.gameObject);
	}

	private IEnumerator NoiseCoroutine()
	{
		_noiseCollider.enabled = true;
		yield return new WaitForSeconds(_noiseTime);
		_noiseCollider.enabled = false;
	}

	private IEnumerator LiveCoroutine()
	{
		yield return new WaitForSeconds(_liveTime);
		RemoveBook();
	}
}
