using UnityEngine;

public class EnableSoundSwitcher : MonoBehaviour
{
	private void OnEnable()
	{
		PlayerDataContainer.Instance.AudioIsEnabled.Changed.AddListener(OnValueChanged);
	}

	private void OnDisable()
	{
		PlayerDataContainer.Instance.AudioIsEnabled.Changed.RemoveListener(OnValueChanged);
	}

	private void OnValueChanged(bool newValue)
	{
		AudioListener.pause = newValue == false;
	}
}
