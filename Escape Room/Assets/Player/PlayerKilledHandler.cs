using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKilledHandler : MonoBehaviour
{
	[SerializeField] private TitleView _titleView;
	[SerializeField] private DayCounter _dayCounter;
	[SerializeField] private CinemachineVirtualCamera _camera;
	[SerializeField] private string _deathTitle = "You was cathed";
	[SerializeField] private AudioSource _source;
	[SerializeField] private UnityEvent _chached;
	public void PlayerKilled()
	{
		_titleView.HideHint();
		_titleView.ShowBackgournd();
		_titleView.ShowTitle(_deathTitle, "", OnAnimationEnd);
	}

	private void OnAnimationEnd()
	{
		_dayCounter.StartNextDay();
		_camera.Priority = 0;
	}

	public void OnAnimationPunch()
	{
		_source.Play();
		_chached.Invoke();
	}
}
