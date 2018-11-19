using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSphere : MonoBehaviour {
    private float radius;
    [Header("Number of buildings from N to S")]
    [SerializeField]
    private float n;
    [Header("Buildings to Spawn")]
    [SerializeField]
    private List<GameObject> buildingsPrefabsList;

    private GameObject planet;
    private GameObject buildingContainer;

    private List<GameObject> buildingsList;

    public void SpawnBuildings()
    {
        buildingsList = new List<GameObject>();
        Reset();
        buildingContainer = GameObject.Find("BuildingContainer");
        //Get sphere radius
        planet = GameObject.FindGameObjectWithTag("planet");
        radius = planet.GetComponent<SphereCollider>().radius * planet.transform.localScale.x;

        if (buildingsPrefabsList.Count == 0)
        {
            //spawn cube
            for (int i = 1; i < 2 * n - 1; i++)
            {
                float teta = i * Mathf.PI / (n - 1);
                for (int j = 1; j < n - 1; j++)
                {
                    float phi = j * Mathf.PI / (n - 1);
                    float x = radius * Mathf.Sin(teta) * Mathf.Sin(phi);
                    float y = radius * Mathf.Cos(phi);
                    float z = radius * Mathf.Cos(teta) * Mathf.Sin(phi);

                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    buildingsList.Add(cube);
                    cube.transform.SetParent(buildingContainer.transform);
                    cube.transform.position = new Vector3(x, y, z);
                    cube.transform.localScale = new Vector3(1f, 1f, 1f);
                    //cube orientation
                    Vector3 normal = cube.transform.position.normalized;
                    cube.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);

                }
            }
        }
        else
        {
            //spawn buildings
            for (int i = 1; i < 2 * n - 1; i++)
            {
                float teta = i * Mathf.PI / (n - 1);
                for (int j = 1; j < n - 1; j++)
                {
                    float phi = j * Mathf.PI / (n - 1);
                    float x = radius * Mathf.Sin(teta) * Mathf.Sin(phi);
                    float y = radius * Mathf.Cos(phi);
                    float z = radius * Mathf.Cos(teta) * Mathf.Sin(phi);

                    int index = UnityEngine.Random.Range(0, buildingsPrefabsList.Count);
                    GameObject building = Instantiate(buildingsPrefabsList[index]);
                    buildingsList.Add(building);
                    building.transform.SetParent(buildingContainer.transform);
                    building.transform.position = new Vector3(x, y, z);
                    building.transform.localScale = new Vector3(1f, 1f, 1f);
                    //building orientation
                    Vector3 normal = building.transform.position.normalized;
                    building.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
                }
            }
        }
        
    }

    public void Reset()
    {
        buildingContainer = GameObject.Find("BuildingContainer");
        
        if (buildingContainer.transform.childCount != 0)
        {
            foreach(GameObject go in buildingsList)
            {
                DestroyImmediate(go);
            }
        }
    }
}
