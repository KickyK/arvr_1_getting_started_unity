using UnityEngine.Events;

[System.Serializable]
public class DoorOpenEvent : UnityEvent<string, int>
{
    public string playName;
    public int doorID;
}