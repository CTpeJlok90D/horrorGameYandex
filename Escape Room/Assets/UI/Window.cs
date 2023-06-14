using UnityEngine;

public class Window : MonoBehaviour
{
	[SerializeField] private PlayerMovement _movement;
	
	public void Open()
	{
		_movement.DisableControl();
		gameObject.SetActive(true);
	}

	public void Close()
	{
		_movement.EnableControl();
		gameObject.SetActive(false);
	}
}
