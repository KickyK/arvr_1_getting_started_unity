using ARVR.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEventSender : MonoBehaviour
{
    public GameEvent OnDoorToggle;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Raising the event....");
            OnDoorToggle?.Raise();
        }
    }
}