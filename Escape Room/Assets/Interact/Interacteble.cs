using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interacteble : MonoBehaviour
{
    [SerializeField] private UnityEvent<Interacteble,InteractContext> _onInteract;
    public bool CanInteract = true;

    public UnityEvent<Interacteble,InteractContext> Interacted => _onInteract;

    public void Interact(InteractContext info)
    {
        if (CanInteract == false)
        {
            return;
        }
        _onInteract.Invoke(this,info);
    }
}