using UnityEngine;

public class ThrowButton : MonoBehaviour
{
	[SerializeField] private BookThrower _thrower;
	[SerializeField] private GameObject _throwButton;

	private void Awake()
	{
		_throwButton.SetActive(false);
	}

	private void OnEnable()
	{
		if (PlayerDataContainer.Instance.IsMobileDevise)
		{
			_thrower.PickedUp.AddListener(OnPickedUp);
			_thrower.Throwed.AddListener(OnThrow);
		}
	}

	private void OnThrow(Book book) => OnThrow();
	private void OnThrow()
	{
		_throwButton.SetActive(false);
	}

	private void OnPickedUp(Book book) => OnPickedUp();
	private void OnPickedUp()
	{
		_throwButton.SetActive(true);
	}
}
