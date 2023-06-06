using Cinemachine;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class DayCounter : MonoBehaviour
{
	[SerializeField] private TitleView _titleView;
	[SerializeField] private GameEnder _gameEnder;
	[Header("Enemy")]
	[SerializeField] private CinemachineVirtualCamera _deathCamera;
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Transform _enemySpawnPoint;
	[SerializeField] private AIDifficultLoader _loader; 
	[Header("Player")]
	[SerializeField] private CharacterController _player;
	[SerializeField] private Transform _playerSpawnPoint;
	[SerializeField] private Transform _camera;
	[SerializeField] private int _daysToLose = 6;
	[SerializeField] private int _currentDay = 1;
	[Header("Title")]
	[SerializeField] private string _nextDayTitleCaption = "Day ";
	[SerializeField] private string _nextDaySubtitleCaption = "Run away!";
	[SerializeField] private float _showDelay = 0.5f;
	[Header("Events")]
	[SerializeField] private UnityEvent _dayEnded;

	public UnityEvent DayEnded => _dayEnded;

	public void StartNextDay()
	{
		_currentDay++;
		_loader.CurrentBrain.ClearMemorys();
		if (_daysToLose <= _currentDay)
		{
			Lose();
			return;
		}

		ResetPlayerPosition();
		ResetEnemyPosition();
		StartCoroutine(ShowTitleWithDelay(_showDelay));
		_dayEnded.Invoke();
	}

	public void Lose()
	{
		_gameEnder.LaunchEnd();
	}

	private IEnumerator ShowTitleWithDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		ShowNextDayTitle();
	}

	public void ShowNextDayTitle()
	{
		_titleView.HideBackground();
		_player.enabled = false;
		_deathCamera.Priority = 0;
		_titleView.ShowTitle(_nextDayTitleCaption + _currentDay, _nextDaySubtitleCaption, () =>
		{
			_titleView.ShowHint();
			_player.enabled = true;
		});
	}

	public void ResetPlayerPosition()
	{
		_player.enabled = false;
		_player.transform.position = _playerSpawnPoint.position;
		_player.transform.rotation = _playerSpawnPoint.rotation;
		_camera.transform.rotation = Quaternion.identity;
		_player.enabled = true;
		_agent.isStopped = false;
	}

	public void ResetEnemyPosition()
	{
		_agent.isStopped = true;
		_agent.velocity = Vector3.zero;
		_agent.updatePosition = false;
		_agent.Warp(_enemySpawnPoint.position);
		_agent.updatePosition = true;
		_agent.isStopped = false;
	}
}

#if UNITY_EDITOR
[CustomEditor(typeof(DayCounter))]
public class DayCounterEditor : Editor
{
	private new DayCounter target => base.target as DayCounter;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (Application.isPlaying == false)
		{
			return;
		}
		if (GUILayout.Button("Start next day"))
		{
			target.StartNextDay();
		}
		if (GUILayout.Button("Lose"))
		{
			target.Lose();
		}
	}
}
#endif