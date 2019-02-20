using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehavior : MonoBehaviour {

	public string button = "Flipper";

	// Use this for initialization
	void Start () {
//		BoxCollider bc = GetComponent<BoxCollider>();
		HingeJoint hinge = GetComponent<HingeJoint>();

		JointLimits limits = hinge.limits;

		limits.min = 0;
		limits.bounciness = 0.02f;
		limits.bounceMinVelocity = 0;
		limits.max = 60;
		hinge.limits = limits;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton(button)) {
			this.GetComponent<HingeJoint>().useMotor = true;
			GetComponent<BoxCollider>().enabled = true;
		}
		if (!Input.GetButton(button)) {
			this.GetComponent<HingeJoint>().useMotor = false;
			GetComponent<BoxCollider>().enabled = false;
		}
	}
}
