using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class UnlockHintButton : MonoBehaviour
{
	[SerializeField] private Button _button;
	[SerializeField] private TMP_Text _costCaption;
	[SerializeField] private int _cost = 25;
	[SerializeField] private int _amout = 1;

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
		if (PlayerDataContainer.Instance.CoinCount.Value <= _cost)
		{
			return;
		}

		PlayerDataContainer.Instance.HintCount.Value += _amout;
		PlayerDataContainer.Instance.CoinCount.Value -= _cost;
	}

	private void Awake()
	{
#if UNITY_EDITOR
		if (Application.IsPlaying(gameObject) == false)
		{
			_button = GetComponent<Button>();
			_costCaption = GetComponent<TMP_Text>();
		}
#endif
		_costCaption.text = _cost.ToString();
	}
}
