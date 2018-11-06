using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityBody : MonoBehaviour {

    private PlanetScript attractorPlanet;
    private Transform playerTransform;

    void Start()
    {
        GameObject planet = GameObject.FindGameObjectWithTag("planet");
        attractorPlanet = planet.GetComponent<PlanetScript>();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}
