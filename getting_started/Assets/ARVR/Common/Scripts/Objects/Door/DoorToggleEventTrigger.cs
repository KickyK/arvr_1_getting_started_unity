using ARVR.Events;
using UnityEngine;

public class DoorToggleEventTrigger : MonoBehaviour
{
    public string targetTag;
    public GameEvent OnDoorToggle;

    private void Awake()
    {
        targetTag = targetTag.Trim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            OnDoorToggle?.Raise();
        }
    }
}