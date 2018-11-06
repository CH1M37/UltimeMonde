using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
    [SerializeField]
    private Rigidbody ball;
    [SerializeField]
    private float attractorCoeff;

    public float attractionRadius;

    private Vector3 ballPos;
    private Vector3 attractorPos;

	void Start () {
        attractorPos = this.transform.position;
	}
	
	void FixedUpdate () {

        ballPos = ball.transform.position;
        Vector3 direction = attractorPos - ballPos;
        float distanceToBall = Vector3.Magnitude(direction);
        Vector3 attractorForce = (attractorCoeff / Mathf.Pow(distanceToBall, 2)) * Vector3.Normalize(direction);
        //Debug.Log("Attractor : " + this.name + "Drection : "+ direction);
        //Debug.Log("Attractor : " + this.name + "Distance to ball : " + distanceToBall);
        if (distanceToBall<= 5f* attractionRadius)
        {
            ball.AddForce(attractorForce);
        }

	}
}
