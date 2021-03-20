using ARVR.Events;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        EventManager.RegisterListener("OnNewPlayer", HandleNewPlayer);
    }

    private void OnDestroy()
    {
        EventManager.UnregisterListener("OnNewPlayer", HandleNewPlayer);
    }

    private void HandleNewPlayer()
    {
        Debug.Log("New player has arrived at " + Time.timeSinceLevelLoad);
    }
}