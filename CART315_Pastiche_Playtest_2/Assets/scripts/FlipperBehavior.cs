using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehavior : MonoBehaviour {

	// Button to control the flipper (space) 
	public string buttonGenerate = "Flipper";
	public string buttonDelete = "Delete";
	Material stateColor;

	// Use this for initialization
	void Start () {
		
		stateColor = GetComponent<Renderer>().material;

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

		// Add collider
		GetComponent<BoxCollider>().enabled = true;

		// If the flipper is tagged "Active"
		if (this.tag == "Active") {
			// Change the color to red
			stateColor.color = Color.red;
			// If the space bar is down
			if (Input.GetButton(buttonGenerate)) {
				// Activate the flipper motor and activate the gravity
				this.GetComponent<HingeJoint>().useMotor = true;
			}
		}
		if (this.tag != "Active") {
			stateColor.color = Color.white;
		}
		// If the space bar is up
		if (!Input.GetButton(buttonGenerate)) {
			// Deactivate the flipper motor
			this.GetComponent<HingeJoint>().useMotor = false;
		}
	}
}
