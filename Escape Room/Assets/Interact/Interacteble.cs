using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interacteble : MonoBehaviour
{
    [SerializeField] private UnityEvent<Interacteble,PlayerInfo> _onInteract;
    public bool CanInteract = true;

    public UnityEvent<Interacteble,PlayerInfo> Interacted => _onInteract;

    public void Interact(PlayerInfo info)
    {
        if (CanInteract == false)
        {
            return;
        }
        _onInteract.Invoke(this,info);
    }
}