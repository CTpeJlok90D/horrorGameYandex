using UnityEngine;


public class TabSwitcher : MonoBehaviour
{
    [SerializeField] private UnityDictionarity<UI.TabButton, RectTransform> _panelPerButton;

	private RectTransform _currentPanel;

	private void OnEnable()
	{
		foreach (UI.TabButton button in _panelPerButton.Keys)
		{
			button.OnTabClick.AddListener(OnButtonClick);
		}
	}

	private void OnDisable()
	{
		foreach (UI.TabButton button in _panelPerButton.Keys)
		{
			button.OnTabClick.RemoveListener(OnButtonClick);
		}
	}

	private void OnButtonClick(UI.TabButton button)
	{
		foreach (RectTransform rect in _panelPerButton.Values)
		{
			rect.gameObject.SetActive(false);
		}

		if (_currentPanel != _panelPerButton[button])
		{
			_panelPerButton[button].gameObject.SetActive(true);
			_currentPanel = _panelPerButton[button];
		}
		else
		{
			_currentPanel = null;
		}
	}
}
