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
    [SerializeField]
    private bool isRandom = false;
    [Header("Spherical Angles")]
    [SerializeField]
    private float teta = 0f;
    [SerializeField]
    private float phi = 0f;

    private GameObject planet;
    private int victorySpawnIndex;
    private Transform victorySpawnPoint;
    private float radius;

    // Use this for initialization
    void Start()
    {
        planet = GameObject.FindGameObjectWithTag("planet");
        radius = planet.GetComponent<SphereCollider>().radius * planet.transform.localScale.x;
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
        if (!isRandom)
        {
            float x = radius * Mathf.Sin(teta) * Mathf.Sin(phi);
            float y = radius * Mathf.Cos(phi);
            float z = radius * Mathf.Cos(teta) * Mathf.Sin(phi);

            Vector3 startPos = new Vector3(x, y, z);
            Instantiate(playerPrefab, startPos, Quaternion.identity);
        }

        if (isRandom)
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

}
