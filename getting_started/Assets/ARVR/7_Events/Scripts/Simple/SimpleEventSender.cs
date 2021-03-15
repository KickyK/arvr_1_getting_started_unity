using UnityEngine;
using UnityEngine.Events;

public class SimpleEventSender : MonoBehaviour
{
    public DoorOpenEvent OnDoorToggle;
    //   public UnityEvent OnRequestDoorOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //  OnRequestDoorOpen?.Invoke();

            OnDoorToggle?.Invoke("door name", 1);
        }
    }
}