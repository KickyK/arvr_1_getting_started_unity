using UnityEngine.Events;

public class DoorOpenEvent : UnityEvent<string, int>
{
    public string playName;
    public int doorID;
}