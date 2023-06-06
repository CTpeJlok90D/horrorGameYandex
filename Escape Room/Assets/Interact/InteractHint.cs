using UnityEngine;

public class InteractHint : MonoBehaviour
{
	[SerializeField] private float _minDistanceToView = 5f;
	[SerializeField] private SpriteRenderer _image;
	[SerializeField] private Color _farColor;
	[SerializeField] private Color _closeColor;

	private void Update()
	{
		Camera mainCamera = Camera.main;
		transform.LookAt(mainCamera.transform.position);

		float currentDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
		_image.color = Color.Lerp(_closeColor, _farColor, currentDistance/_minDistanceToView);
	}

	private void OnValidate()
	{
		_image = GetComponent<SpriteRenderer>();
		if (_image != null)
		{
			_image.color = _closeColor;
		}
	}
}
