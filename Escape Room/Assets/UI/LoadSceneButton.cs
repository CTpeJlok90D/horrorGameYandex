using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
	[SerializeField] private Button _playButton;
	[SerializeField] private TitleView _titleView;
	[SerializeField] private GameObject _background;
	[SerializeField] private int _loadSeneNumber;
	[SerializeField] private string _loadingCaption = "Loading";
	[SerializeField] private GameObject _loadingIndicator;
	private void OnEnable()
	{
		_playButton.onClick.AddListener(OnClick);
	}

	private void OnDisable()
	{
		_playButton.onClick.AddListener(OnClick);
	}

	public void OnClick()
	{
		_loadingIndicator.SetActive(true);
		_titleView.ShowBackgournd(-1,OnAnimationEnd);
		_titleView.ShowHint("", "");
		_titleView.ShowTitle(_loadingCaption, "");
		PlayerDataContainer.SavePlayerData();
		_background.SetActive(true);
	}

	private void OnAnimationEnd()
	{
		SceneManager.LoadSceneAsync(_loadSeneNumber);
	}
}
