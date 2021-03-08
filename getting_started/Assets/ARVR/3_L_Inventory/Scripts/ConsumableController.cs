﻿using System.Collections.Generic;
using UnityEngine;

//Can improve this code?

public class ConsumableController : MonoBehaviour
{
    //[SerializeField]
    //[Tooltip("Select consumable prefab generated by the consumables machine")]
    //private GameObject consumablePrefab;

    [SerializeField]
    private List<GameObject> consumablePrefabList;

    [SerializeField]
    [Tooltip("Select child game object to use as dispense point for consumable")]
    private Transform consumableExitTransform;

    [SerializeField]
    [Tooltip("Select audio clip played for each new consumable")]
    private AudioClip consumableAudioClip;

    [SerializeField]
    private KeyCode keyCode;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode)) //?
        {
            int randomPrefabIndex = Random.Range(0, 2); //0 - 1
            var consumable = Instantiate(consumablePrefabList[randomPrefabIndex], consumableExitTransform.position, Quaternion.Euler(90, 0, 0));
            consumable.transform.localScale *= 0.5f; //?
            var rigidBody = consumable.GetComponent<Rigidbody>();
            rigidBody.AddForce(new Vector3(10, 1, 0), //?
                                            ForceMode.Force);
            AudioSource.PlayClipAtPoint(consumableAudioClip, consumableExitTransform.position);
        }
    }
}