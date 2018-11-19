using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnSphere : MonoBehaviour {
    private float radius;
    [Header("Number of buildings from N to S")]
    [SerializeField]
    private float n;

    // Use this for initialization
    void Start () {
        //Get sphere radius
        radius = this.GetComponent<SphereCollider>().radius * transform.localScale.x;

        SpawnBuildings();
       
    }

    private void SpawnBuildings()
    {
        for (int i = 1; i < 2*n - 1; i++)
        {
            float teta = i * Mathf.PI / (n - 1);
            for(int j=1; j<n-1; j++)
            {
                float phi = j * Mathf.PI / (n - 1);
                float x = radius * Mathf.Sin(teta) * Mathf.Sin(phi);
                float y = radius * Mathf.Cos(phi);
                float z = radius * Mathf.Cos(teta) * Mathf.Sin(phi);

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x, y, z);
                //cube orientation
                Vector3 normal = cube.transform.position.normalized;
                cube.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            }
        }
    }
}
