using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehavior : MonoBehaviour {


	// Use this for initialization
	void Start () {
		HingeJoint hinge = GetComponent<HingeJoint>();

		JointLimits limits = hinge.limits;


		limits.min = 90;
		limits.bounciness = 0;
		limits.bounceMinVelocity = 0;
		limits.max = 0;
		hinge.limits = limits;
		hinge.useLimits = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
