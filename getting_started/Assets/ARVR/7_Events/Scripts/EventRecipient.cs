using UnityEngine;

public class EventRecipient : MonoBehaviour
{
    private bool bRequestOpen;
    private bool isOpen;

    private void Update()
    {
        if (bRequestOpen && !isOpen)
        {
            OpenDoor();
            isOpen = true;
        }
        else if (bRequestOpen && isOpen)
        {
            CloseDoor();
            isOpen = false;
        }
    }

    public void SetIsOpen()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        Debug.Log("CloseDoor");
    }

    public void OpenDoor()
    {
        Debug.Log("OpenDoor");
    }
}