using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public Rigidbody rb;
	public SphereCollider postSCollider;
	public GameObject postSynaptic;
	private Vector3 velocity, exitVelocity; 
	private float ballRadius, postSRadius, postSAura, distance, totalRadius;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ballRadius = GetComponent<SphereCollider>().radius * transform.lossyScale.x;

		postSynaptic = GameObject.Find("postsynaptic");
		postSRadius = postSynaptic.GetComponent<SphereCollider> ().radius * postSynaptic.transform.lossyScale.y;

		totalRadius = ballRadius + postSRadius;
	
		velocity = new Vector3 (Random.Range (-1.5f, 1.5f), 1.0f, 0.0f);
		exitVelocity = new Vector3 (2.0f, 1.0f, 0.0f);
	}
	// Update is called once per frame
	void Update () {
//		
		rb.velocity = new Vector3 (velocity.x + Random.Range (-1.0f, 1.0f), velocity.y, velocity.z);
		distance = Vector3.Distance(transform.position, postSynaptic.transform.position);
		print (postSynaptic.transform.position);
		postSAura = Random.Range (-2.0f,0.2f);

		if (distance <= totalRadius + postSAura) {
			print ("yepyep");
			if (transform.position.x <= 0) {
				rb.velocity = new Vector3 (-exitVelocity.x,exitVelocity.y,exitVelocity.z);
			}
			if (transform.position.x > 0) {
				rb.velocity = exitVelocity;
			}
		}
	}
}
