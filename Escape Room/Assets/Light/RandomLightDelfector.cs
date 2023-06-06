using UnityEngine;

public class RandomLightDelfector : MonoBehaviour
{
	[SerializeField] private Behaviour _light;
	[SerializeField] private float _minLightEnableTime = 0.5f;
	[SerializeField] private float _maxLightEnableTime = 2;
	[SerializeField] private float _minLightDisableTime = 0.1f;
	[SerializeField] private float _maxLightDisableTime = 1.5f;

	private float _currentTime;

	private void Update()
	{ 
		if (_currentTime > 0)
		{
			_currentTime -= Time.deltaTime;
			return;
		}
		if (_light.enabled)
		{
			DisableLight();
			return;
		}
		EnableLight();
	}

	private void DisableLight()
	{
		_currentTime = Random.Range(_minLightDisableTime, _maxLightDisableTime);
		_light.enabled = false;
	}

	private void EnableLight()
	{
		_currentTime = Random.Range(_minLightEnableTime, _maxLightEnableTime);
		_light.enabled = true;
	}
}
