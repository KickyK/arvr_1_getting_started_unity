using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventSender : MonoBehaviour
{
    public DoorOpenEvent OnDoor;
    public UnityEvent OnRequestDoorOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //  if()
            OnRequestDoorOpen?.Invoke();
        }
    }
}