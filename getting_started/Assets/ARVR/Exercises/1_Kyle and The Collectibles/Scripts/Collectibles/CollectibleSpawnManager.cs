using ARVR.ScriptableTypes;
using ARVR.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectibleSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject collectiblePrefab;

    [SerializeField]
    private RuntimeVector3Array collectibleSpawnPositions;

    [SerializeField]
    [Range(1, 30)]
    private float minSpawnRateInSeconds = 1;

    [SerializeField]
    [Range(1, 30)]
    private float maxSpawnRateInSeconds = 1;

    private List<int> shufflePositions;
    private IEnumerator spawnCoroutine;

    private void Awake()
    {
        if (collectibleSpawnPositions != null)
        {
            shufflePositions = Enumerable.Range(0, collectibleSpawnPositions.Length).ToList();
            shufflePositions.Shuffle();
        }

        spawnCoroutine = Spawn();
        StartCoroutine(spawnCoroutine);
    }

    private IEnumerator Spawn()
    {
        while (shufflePositions.Count > 0)
        {
            //get random position
            int index = shufflePositions.First();
            shufflePositions.RemoveAt(0);

            //instanciate prefab at position
            Instantiate(collectiblePrefab, collectibleSpawnPositions[index], Quaternion.identity);

            //suspend this coroutine for seconds
            var suspendForSecs = Random.Range(minSpawnRateInSeconds, maxSpawnRateInSeconds);
            Debug.Log(suspendForSecs.ToString());
            yield return new WaitForSeconds(suspendForSecs);
        }

        //stop when all randomly placed
        StopCoroutine(spawnCoroutine);
    }
}