using UnityEngine;
using UnityEngine.UI;

public class HintByAddsButton : MonoBehaviour
{
	[SerializeField] private Button _button;

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
	}
	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	private void OnClick()
	{
		Debug.Log("Тут могла быть ваша реклама");
		PlayerDataContainer.Instance.HintCount.Value += 1;
	}
}
