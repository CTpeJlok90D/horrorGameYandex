using TMPro;
using UnityEngine;

public class DifficultListElement : MonoBehaviour
{
	[SerializeField] private PlayerData.Difficult _difficult;
	[SerializeField] private TMP_Text _caption;

	protected PlayerData.Difficult Difficult => _difficult;

	public virtual void Init(string caption, PlayerData.Difficult difficult)
	{
		_caption.text = caption;
		_difficult = difficult;
	}
}
