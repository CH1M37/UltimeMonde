using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orient : MonoBehaviour {

    public void OrientBuildings()
    {
        GameObject[] buildingsArray = GameObject.FindGameObjectsWithTag("building");
        foreach(GameObject building in buildingsArray)
        {
            Vector3 normal = building.transform.position.normalized;
            building.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        }
        
    }

}
