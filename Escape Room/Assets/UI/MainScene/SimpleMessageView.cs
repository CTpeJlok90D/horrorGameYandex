using UnityEngine;

public class SimpleMessageView : MonoBehaviour
{
	[SerializeField] private PlayerMessageView _messageView;
	[SerializeField] private string _message;

	public void ShowMessage()
	{
		_messageView.ShowMessage(_message);
	}
}
