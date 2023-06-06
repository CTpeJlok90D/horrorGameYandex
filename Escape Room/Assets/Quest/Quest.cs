using UnityEngine;
using UnityEngine.Events;

public abstract class Quest : MonoBehaviour
{
	[SerializeField] private string _title = "<quest header>";
	[SerializeField] private string _subtitle = "<quest caption>";
	[SerializeField] private string _announceTitle = "<announce title>";
	[TextArea(3,5)]
	[SerializeField] private string _announceSubtitle = "<announce hint>";
	[SerializeField] private UnityEvent _questStarted;
	[SerializeField] private UnityEvent _questEnded;
	[Header("Hint")]
	[SerializeField] private int _hintLayerMask = 12;
	[SerializeField] private int _defualtLayerMask = 0;
	[SerializeField] private GameObject[] _hintedObjects;

	private bool _questIsStarted;

	public string Subtitle => _subtitle;
	public string Title => _title;
	public string AnnounceTitle => _announceTitle;
	public string AnnounceSubtitle => _announceSubtitle;
	public UnityEvent QuestStarted => _questStarted;
	public UnityEvent QuestEnded => _questEnded;
	public bool QuestIsStarted => _questIsStarted;

	public virtual void OnQuestStart() { }
	public virtual void OnQuestFinish() { }
	public virtual void OnBegin()
	{
		_questIsStarted = true;
		_questStarted.Invoke();
	}
	public void Complete()
	{
		OnQuestFinish();
		_questIsStarted = false;
		_questEnded.Invoke();

		foreach (GameObject mesh in _hintedObjects)
		{
			if (mesh != null)
			{
				mesh.layer = _defualtLayerMask;
			}
		}
	}

	[ContextMenu("Show hint")]
	public void ShowHint()
	{
		foreach (GameObject mesh in _hintedObjects)
		{
			if (mesh != null)
			{
				mesh.layer = _hintLayerMask;
			}
		}
	}
}