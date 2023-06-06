using UnityEngine;

public class PlatformObjectSwitch : MonoBehaviour
{
	[SerializeField] private GameObject[] _mobileInputs;
	[SerializeField] private GameObject[] _pcInputs;

	private void Awake()
	{
		foreach (GameObject gameObject in _mobileInputs)
		{
			gameObject.SetActive(PlayerDataContainer.Instance.IsMobileDevise);
		}

		foreach (GameObject gameObject in _pcInputs)
		{
			gameObject.SetActive(PlayerDataContainer.Instance.IsMobileDevise == false);
		}
	}
}
