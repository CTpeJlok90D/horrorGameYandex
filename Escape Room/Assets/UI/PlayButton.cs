using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
	[SerializeField] private GameObject _difficultyPanel;
	[SerializeField] private GameObject _mainUI;
	[SerializeField] private Button _button;
	[SerializeField] private TitleView _titleView;
	[SerializeField] private GameObject _backGround;
	[SerializeField] private int _loadSeneNumber;
	[SerializeField] private string _loadingCaption = "Loading";

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	public void OnClick()
	{
		if (PlayerDataContainer.Instance.IsFirstPlay.Value)
		{
			_mainUI.SetActive(false);
			_difficultyPanel.SetActive(true);
			return;
		}
		_backGround.SetActive(true);
		_titleView.ShowBackgournd(-1, OnAnimationEnd);
		PlayerDataContainer.SavePlayerData();
	}
	private void OnAnimationEnd()
	{
		_titleView.ShowTitle(_loadingCaption, "");
		SceneManager.LoadSceneAsync(_loadSeneNumber);
	}
}
