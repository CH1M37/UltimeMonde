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
    private float buildingsXZScale = 0.03f;
    [SerializeField]
    private float buildingsYScale = 0.02f;
    [SerializeField]
    private float cubeScale = 0.3f;

    private GameObject planet;
    private GameObject buildingContainer;

    private List<Vector3> posDir;

    public void SpawnBuildings()
    {
        Reset();

        posDir = new List<Vector3>();

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
                    cube.transform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
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
                    Vector3 position = new Vector3(x, y, z);

                    Vector3 ePhi = Mathf.Cos(phi)*Mathf.Sin(teta)*Vector3.right - Mathf.Sin(phi) * Vector3.up + Mathf.Cos(phi) * Mathf.Cos(teta) * Vector3.forward;
                    posDir.Add(position);
                    posDir.Add(ePhi);

                    int index = UnityEngine.Random.Range(0, buildingsPrefabsList.Count);
                    GameObject building = Instantiate(buildingsPrefabsList[index]);
                    building.transform.SetParent(buildingContainer.transform);
                    building.transform.position = position;
                    building.transform.localScale = new Vector3(buildingsXZScale, buildingsYScale, buildingsXZScale);
                    
                    //building orientation
                    Vector3 forward = new Vector3(x, 0, z).normalized;
                    Vector3 normal = building.transform.position.normalized;
                    building.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
                    float angle = Vector3.SignedAngle(building.transform.right, ePhi, normal);
                    building.transform.RotateAround(building.transform.position, building.transform.up, angle);
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
    /*
     * Draw ePhi vector (spherical coordinates)
    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        buildingContainer = GameObject.Find("BuildingContainer");

        if(posDir.Count > 0)
        {
             for (int i=0; i < buildingContainer.transform.childCount-1; i+=2)
             {
                Vector3 position = posDir[i];
                Vector3 dir = posDir[i+1];

                Gizmos.DrawRay(position, dir * 10f);
             }
        }
       
    }
    */
}
