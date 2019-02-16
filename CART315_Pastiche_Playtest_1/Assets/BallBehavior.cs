using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public Rigidbody rb;
	public Vector3 antiGravity = new Vector3(0,1,0);
	public Vector3 currentLeft = new Vector3(-1,antiGravity.y/2,0);
	public Vector3 currentRight = new Vector3(1,antiGravity.y/2,0)

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>()
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y <= 0) {
			rb.useGravity = false;
			rb.velocity = antiGravity;
		}
		if (transform.position.y > 0 && transform.position.y <= 1.5) {
			rb.useGravity = false;
			if (transform.position.x < 0) {
				rb.velocity = currentLeft;
			} else {
				rb.velocity = currentRight;
			}
		} 
		if (transform.position.y > 1.5) {
			rb.useGravity = true;
		}
	}
}
