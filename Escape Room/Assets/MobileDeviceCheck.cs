using UnityEngine;

public class MobileDeviceCheck : MonoBehaviour
{
	[SerializeField] private bool _useMobileControl = false;

	public bool UseMobileControl => _useMobileControl;
}
