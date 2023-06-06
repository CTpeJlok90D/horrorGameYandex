using UnityEngine;
using UnityEngine.AI;

public class GameEnder : MonoBehaviour
{
	[SerializeField] private TitleView _titleView;
	[SerializeField] private GameObject _resultsCanvas;
	[SerializeField] private PlayerMovement _playerMovement;
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private AIDifficultLoader _difficultLoader;

	[ContextMenu("End game")]
	public void LaunchEnd()
	{
		_titleView.ShowBackgournd(onEndfunc: OnBackgroundAnimationEnd);
	}

	public void OnBackgroundAnimationEnd()
	{
		_resultsCanvas.SetActive(true);
		_playerMovement.DisableControl();
	}
}
