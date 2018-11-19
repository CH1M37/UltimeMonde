using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLegs : MonoBehaviour {

    public HingeJoint hj;
    public Transform objective;
    public bool inverted;
    
	
	// Update is called once per frame
	void Update () {

        JointSpring js = hj.spring;

        js.targetPosition = objective.localEulerAngles.x;

        if (js.targetPosition > 180)
        {
            js.targetPosition = js.targetPosition - 360;
        }

        js.targetPosition = Mathf.Clamp(js.targetPosition, hj.limits.min + 5, hj.limits.max - 5); //Dans le if précédent ?

        if (inverted)
        {
            js.targetPosition = js.targetPosition * -1;
        }
        hj.spring = js;

	}
}
