using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BookThrower : MonoBehaviour
{
	[SerializeField] private Transform _bookHolder;
	[SerializeField] private float _throwStrench = 1.5f;
	[Header("Position")]
	[SerializeField] private Vector3 _bookPosition;
	[SerializeField] private Vector3 _bookRotation;
	[SerializeField] private UnityEvent<Book> _throwed;
	[SerializeField] private UnityEvent<Book> _pickedUp;
	private Book _book;

	public UnityEvent<Book> Throwed => _throwed;
	public UnityEvent<Book> PickedUp => _pickedUp;
	public Book Book => _book;

	private void OnEnable()
	{
		InputSingletone.Instance.PlayerMovement.ThrowBook.started += ThrowBook;
	}

	private void OnDisable()
	{
		InputSingletone.Instance.PlayerMovement.ThrowBook.started -= ThrowBook;
	}

	[ContextMenu("Add book")]
	public void AddBook(Book book)
	{
		if (Application.isPlaying == false)
		{
			return;
		}
		_book = Instantiate(book, _bookHolder);
		_book.transform.localPosition = _bookPosition;
		_book.transform.localEulerAngles = _bookRotation;
		_pickedUp.Invoke(_book);
	}

	private void ThrowBook(InputAction.CallbackContext context)
	{
		ThrowBook();
	}
	public void ThrowBook()
	{
		if (_book == null)
		{
			return;
		}
		_book.transform.SetParent(null);
		_book.Rigidbody.isKinematic = false;
		_book.Rigidbody.AddForce(transform.forward * _throwStrench);
		_throwed.Invoke(_book);
		_book = null;
	}
}
