using UnityEngine;

public class SimpleEventRecipient : MonoBehaviour
{
    private bool bRequestOpen;
    private bool isOpen;

    private void Update()
    {
        if (bRequestOpen && !isOpen)
        {
            //open the door

            //set to open and set request to false to prevent processing in the next update
            isOpen = true;
            bRequestOpen = false;
        }
        else if (bRequestOpen && isOpen)
        {
            //close the door

            //set to closed and set request to false to prevent processing in the next update
            isOpen = false;
            bRequestOpen = false;
        }
    }

    /// <summary>
    /// Attached to the sender event OnRequestDoorOpen which has no parameters
    /// </summary>
    public void HandleDoorOpen()
    {
        //remember to wrap your Debug messages as they swallow CPU cycles with garbage collection
#if UNITY_EDITOR
        Debug.Log("HandleDoorOpen");
#endif

        if (isOpen)
            bRequestOpen = false;
        else
            bRequestOpen = true;
    }

    /// <summary>
    /// Attached to the sender event OnDoorToggle which has parametersn(string, int)
    /// </summary>
    public void HandleDoorToggle(string id, int number)
    {
        //remember to wrap your Debug messages as they swallow CPU cycles with garbage collection
#if UNITY_EDITOR
        Debug.Log($"HandleDoorToggle({id},{number})");
#endif

        if (isOpen)
            bRequestOpen = false;
        else
            bRequestOpen = true;
    }
}