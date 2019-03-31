using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFlipperBehavior : MonoBehaviour {

	// Button to control the flipper (space) 
	public string button = "Flipper";

	// Use this for initialization
	void Start () {
		// The hinge joint associated with the flipper
		HingeJoint hinge = GetComponent<HingeJoint>();
		// The hinge limits
		JointLimits limits = hinge.limits;
		limits.bounciness = 0.0f;
		limits.bounceMinVelocity = 0;
		hinge.limits = limits;
	}

	// Update is called once per frame
	void Update () {
		// If the space bar is down
		if (Input.GetButton(button)) {
			// Activate the flipper motor and activate the gravity
			this.GetComponent<HingeJoint>().useMotor = true;
			// Add gravity
			GetComponent<BoxCollider>().enabled = true;
		}
		// If the space bar is up
		if (!Input.GetButton(button)) {
			// Deactivate the flipper motor
			this.GetComponent<HingeJoint>().useMotor = false;
//			// Remove gravity
//			GetComponent<BoxCollider>().enabled = false;
		}
	}
}
