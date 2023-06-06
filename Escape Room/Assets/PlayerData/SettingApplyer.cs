using System;
using TMPro;
using UnityEngine;

public class SettingApplyer : MonoBehaviour
{
	[SerializeField] private TMP_Text _mouseSensivityCaption;

	public void SetAuidio(bool value)
	{
		PlayerDataContainer.Instance.AudioIsEnabled.Value = value;
	}

	public void SetMouseSensivity(float value)
	{
		PlayerDataContainer.Instance.MouseSensivity.Value = value;
		_mouseSensivityCaption.text = MathF.Round(value, 2).ToString();
	}
}
