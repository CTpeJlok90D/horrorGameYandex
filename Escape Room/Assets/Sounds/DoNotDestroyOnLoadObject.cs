using UnityEngine;

public class DoNotDestroyOnLoadObject : MonoBehaviour
{
	private static DoNotDestroyOnLoadObject _instance;
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
