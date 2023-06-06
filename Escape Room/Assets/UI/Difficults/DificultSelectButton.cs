using UnityEngine;
using UnityEngine.UI;

public class DificultSelectButton : DifficultListElement
{
	[SerializeField] private Button _button;
	[SerializeField] private Image _selectedImage;

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
		PlayerDataContainer.Instance.SelectedDifficult.Changed.AddListener(OnDifficultChange);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
		if (PlayerDataContainer.HaveInstance())
		{
			PlayerDataContainer.Instance.SelectedDifficult.Changed.RemoveListener(OnDifficultChange);
		}
	}

	private void OnClick()
	{
		PlayerDataContainer.Instance.SelectedDifficult.Value = Difficult;
	}

	private void OnDifficultChange(PlayerData.Difficult difficult)
	{
		_selectedImage.enabled = Difficult == difficult;
	}
}
