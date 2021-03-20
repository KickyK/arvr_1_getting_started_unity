using System.Collections;
using System.Collections.Generic;
using ARVR.Events;
using Assets.ARVR.Common.Scripts.Demo;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    //  public FileManager manager;

    // Start is called before the first frame update
    private void Start()
    {
        //       FileManager.GetInstance("save.json").Save("my data....");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.Raise("OnNewPlayer");
        }
    }
}