using TMPro;
using UnityEngine;

public class CoinCountView : MonoBehaviour
{
	[SerializeField] private TMP_Text _caption;

	private void OnEnable()
	{
		PlayerDataContainer.Instance.CoinCount.Changed.AddListener(OnCountChanged);
		OnCountChanged(PlayerDataContainer.Instance.CoinCount.Value);
	}

	private void OnDisable()
	{
		if (PlayerDataContainer.HaveInstance())
			PlayerDataContainer.Instance.CoinCount.Changed.RemoveListener(OnCountChanged);
	}

	private void OnCountChanged(int newValue)
	{
		_caption.text = newValue.ToString();
	}
}
