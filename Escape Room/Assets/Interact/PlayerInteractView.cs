using UnityEngine;

public class PlayerInteractView : MonoBehaviour
{
    public bool ShowAlways;
    [SerializeField] private GameObject _interactIdicator;
    [SerializeField] private PlayerInteract _playerInteract;
    
    public bool CanInteract
    {
        get
        {
			Ray ray = new(_playerInteract.CameraTransform.position, _playerInteract.CameraTransform.forward);

			return Physics.Raycast(ray, out RaycastHit hit, _playerInteract.InteractDistance) && hit.collider.TryGetComponent(out Interacteble interacteble);
        }
    }


	private void Update()
    {
        _interactIdicator.SetActive(CanInteract || ShowAlways);
    }
}
