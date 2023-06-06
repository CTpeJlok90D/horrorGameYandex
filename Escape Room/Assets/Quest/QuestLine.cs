using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class QuestLine : MonoBehaviour
{
#if UNITY_EDITOR
	[SerializeField]
	private bool _autoFill = true;
#endif
	[SerializeField] private List<Quest> _quests = new();
	[SerializeField] private UnityEvent _complited = new();
	[SerializeField] private UnityEvent<Quest> _questChanged = new();
	[SerializeField] private int _currentQuestIndex = 0;
	private bool _isStarted = false;
	public Quest CurrentQuest => _quests[_currentQuestIndex];
	public UnityEvent Complited => _complited;
	public UnityEvent<Quest> QuestChanged => _questChanged;
	public bool IsStarted => _isStarted;

	public void StartLine()
	{
		_isStarted = true;
		BeginQuest(0);
	}

	private void OnCurrentQuestComplete()
	{
		StartNextQuest();
	}

	private void BeginQuest(int questID)
	{
		_currentQuestIndex = questID;
		CurrentQuest.QuestEnded.AddListener(OnCurrentQuestComplete);
		CurrentQuest.OnBegin();
		_questChanged.Invoke(CurrentQuest);
	}

	public void StartNextQuest()
	{
		CurrentQuest?.QuestEnded.RemoveListener(OnCurrentQuestComplete);
		_currentQuestIndex++;
		if (_currentQuestIndex >= _quests.Count)
		{
			CompleteLine();
			return;
		}
		BeginQuest(_currentQuestIndex);
	}

	public void CompleteLine()
	{
		_complited.Invoke();
		_isStarted = false;
		gameObject.SetActive(false);
	}

#if UNITY_EDITOR
	public void OnValidate()
	{
		if (_autoFill == false)
		{
			return;
		}
		_quests.Clear();
		foreach (Transform transform in transform)
		{
			if (transform.TryGetComponent(out Quest quest))
			{
				_quests.Add(quest);
			}
		}
	}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(QuestLine))]
public class QuestLineEditor : Editor
{
	private new QuestLine target => base.target as QuestLine;

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		target.OnValidate();
		if (Application.isPlaying == false || target.IsStarted == false)
		{
			return;
		}
		if (GUILayout.Button("Complite line"))
		{
			target.CompleteLine();
		}
		if (GUILayout.Button("Complete currentQuest"))
		{
			target.StartNextQuest();
		}
	}
}
#endif