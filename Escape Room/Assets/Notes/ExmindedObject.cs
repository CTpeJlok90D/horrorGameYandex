using UnityEngine;

public class ExmindedObject : MonoBehaviour
{
	[SerializeField] private Vector3 _angleRotate;
	[SerializeField] private bool _unlimitedRotation;
	public bool UnlimitedRotation => _unlimitedRotation;

	public void Rotate(Vector3 delta)
	{
		Vector3 newAngles = transform.localEulerAngles + new Vector3(-delta.y, -delta.x, 0);
		newAngles.z = 0;

		if (_unlimitedRotation)
		{
			newAngles = transform.localEulerAngles + new Vector3(-delta.y, -delta.x, 0);
			transform.localEulerAngles = newAngles;
			return;
		}

		for (int i = 0; i < 2; i++)
		{
			if (newAngles[i] > 180 && newAngles[i] < 360 - _angleRotate[i])
			{
				newAngles[i] = 360 - _angleRotate[i];
			}
			else if (newAngles[i] < 180 && newAngles[i] > _angleRotate[i])
			{
				newAngles[i] = _angleRotate[i];
			}
		}

		transform.localEulerAngles = newAngles;
	}
}
