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
		PlayerDataContainer.Instance.ShowBannerAd();
		PlayerDataContainer.Instance.HintCount.Value += 1;
	}
}
