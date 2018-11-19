using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSphere : MonoBehaviour {
    private float radius;
    [Header("Number of buildings from N to S")]
    [SerializeField]
    private float n;
    [Header("Buildings Parameters")]
    [SerializeField]
    private List<GameObject> buildingsPrefabsList;
    [SerializeField]
    private bool useBuildings = false;
    [SerializeField]
    private GameObject cubePrefab;
    [SerializeField]
    private bool useCubes = true;
    [SerializeField]
    private float buildingsScale = 1f;

    private GameObject planet;
    private GameObject buildingContainer;

    private List<GameObject> buildingsList;

    public void SpawnBuildings()
    {
        Reset();

        buildingContainer = GameObject.Find("BuildingContainer");
        planet = GameObject.FindGameObjectWithTag("planet");
        radius = planet.GetComponent<SphereCollider>().radius * planet.transform.localScale.x;

        if (useCubes)
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

                    GameObject cube = Instantiate(cubePrefab);
                    cube.transform.SetParent(buildingContainer.transform);
                    cube.transform.position = new Vector3(x, y, z);
                    cube.transform.localScale = new Vector3(buildingsScale, buildingsScale, buildingsScale);
                    //cube orientation
                    Vector3 forward = new Vector3(x, 0, z).normalized ;
                    cube.transform.rotation = Quaternion.FromToRotation(cube.transform.forward, forward);
                    Vector3 normal = cube.transform.position.normalized;
                    float angle = Vector3.SignedAngle(cube.transform.forward, normal, cube.transform.right);
                    cube.transform.RotateAround(cube.transform.position, cube.transform.right, angle);
                }
            }
        }
        else if (useBuildings)
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
                    building.transform.SetParent(buildingContainer.transform);
                    building.transform.position = new Vector3(x, y, z);
                    building.transform.localScale = new Vector3(buildingsScale, buildingsScale, buildingsScale);
                    //building orientation
                    Vector3 forward = new Vector3(x, 0, z).normalized;
                    building.transform.rotation = Quaternion.FromToRotation(building.transform.forward, forward);
                    Vector3 normal = building.transform.position.normalized;
                    float angle = Vector3.SignedAngle(building.transform.forward, normal, building.transform.right);
                    building.transform.RotateAround(building.transform.position, building.transform.right, angle);
                }
            }
        }
        
    }

    public void Reset()
    {
        GameObject[] buildingsArray = GameObject.FindGameObjectsWithTag("building");
        foreach(GameObject go in buildingsArray)
        {
            DestroyImmediate(go);
        }
    }
}
