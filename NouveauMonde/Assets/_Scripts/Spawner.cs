using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Transform> spawnPointsList;
    [SerializeField]
    private GameObject victoryPrefab;
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject planet;
    private int victorySpawnIndex;
    private Transform victorySpawnPoint;

    // Use this for initialization
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("planet");
        spawnPointsList = new List<Transform>();
        //Initialize List
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPointsList.Add(transform.GetChild(i));
        }

        SpawnVictory();
        SpawnPlayer();

    }

    private void SpawnVictory()
    {
        victorySpawnIndex = Random.Range(0, 6);

        victorySpawnPoint = transform.GetChild(victorySpawnIndex);
        Instantiate(victoryPrefab, victorySpawnPoint.position, victorySpawnPoint.rotation);
    }

    private void SpawnPlayer()
    {
        foreach (Transform spawnPoint in spawnPointsList)
        {
            float distanceToVictory = (victorySpawnPoint.position - spawnPoint.position).magnitude;

            if (Mathf.Abs(distanceToVictory - planet.transform.lossyScale.x) < 1f)
            {
                Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

}
