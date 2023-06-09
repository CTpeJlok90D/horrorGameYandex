using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _interactDistance = 2;
    [Header("Interact reousres")]
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private ExmindedObjectShower _noteView;
    [SerializeField] private Container _container;
    [SerializeField] private PlayerMessageView _playerMessageView;
    [SerializeField] private CharacterController _character;
    [SerializeField] private BookThrower _bookThrower;

	public Transform CameraTransform => _camera;
    public float InteractDistance => _interactDistance;

	private void Awake()
	{
        InputSingletone.Instance.Interact.Enable();
	}

	private void OnEnable()
    {
        InputSingletone.Instance.Interact.Interact.started += OnInteract;
    }

    private void OnDisable()
    {
        InputSingletone.Instance.Interact.Interact.started -= OnInteract;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Ray ray = new(_camera.position, _camera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance) && hit.collider.TryGetComponent(out Interacteble interacteble))
        {
            InteractContext info = new InteractContext()
            {
                PlayerMovement = _movement,
                NoteView = _noteView,
                Container = _container,
                PlayerMessageView = _playerMessageView,
                Character = _character,
                BookThower = _bookThrower
			};
            interacteble.Interact(info);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_camera.position, _camera.position + _camera.forward * _interactDistance);
    }
}

public struct InteractContext
{
	public PlayerMovement PlayerMovement;
	public ExmindedObjectShower NoteView;
	public Container Container;
    public PlayerMessageView PlayerMessageView;
    public CharacterController Character;
    public BookThrower BookThower;
}
