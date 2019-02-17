using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public Rigidbody rb;
	public Vector3 velocity; 
//	public Vector3 current = new Vector3 (1, 0, 0);
//	public float middleY = 0f;
//	public float maxMiddleY = 2f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		velocity = new Vector3 (Random.Range (-1.0f, 1.0f), 1.0f, 0.0f);
	}
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3 (velocity.x + Random.Range (-1.0f, 1.0f), velocity.y, velocity.z);
	}
}
