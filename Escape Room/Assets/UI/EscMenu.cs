using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EscMenu : MonoBehaviour
{
	[SerializeField] private GameObject _menu;

	private void OnEnable()
	{
		InputSingletone.Instance.PlayerMovement.OpenEscMenu.started += OpenEscMenu;
		InputSingletone.Instance.EscMenu.Close.started += CloseEscMenu;
	}

	private void OnDisable()
	{
		InputSingletone.Instance.PlayerMovement.OpenEscMenu.started -= OpenEscMenu;
		InputSingletone.Instance.EscMenu.Close.started -= CloseEscMenu;
	}

	private void OpenEscMenu(InputAction.CallbackContext context) => OpenEscMenu();
	public void OpenEscMenu()
	{
		Time.timeScale = 0f;
		InputSingletone.Instance.PlayerMovement.Disable();
		InputSingletone.Instance.EscMenu.Enable();
		Cursor.lockState = CursorLockMode.None;
		_menu.SetActive(true);
	}
	private void CloseEscMenu(InputAction.CallbackContext context) => CloseEscMenu();
	public void CloseEscMenu()
	{
		Time.timeScale = 1f;
		InputSingletone.Instance.PlayerMovement.Enable();
		InputSingletone.Instance.EscMenu.Disable();
		Cursor.lockState = CursorLockMode.Locked;
		_menu.SetActive(false);
	}

	public void OnMenuLoad()
	{
		Time.timeScale = 1f;
		InputSingletone.Instance.EscMenu.Disable();
	}
}
