using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	public GameObject postSynaptic;
	public GameObject channelSerotonin;
	public Rigidbody rb;
	public SphereCollider postSCollider;
	public CapsuleCollider channelSCollider;
	private Vector3 entranceVelocity, velocity, exitVelocity; 
	private float speed, ballRadius, channelSHeight, postSRadius, postSAura, distance, totalRadius;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		channelSerotonin = GameObject.Find("channel_serotonin");

		ballRadius = GetComponent<SphereCollider>().radius * transform.lossyScale.x;
		channelSHeight = channelSerotonin.GetComponent<CapsuleCollider> ().bounds.size.y;

		postSynaptic = GameObject.Find("postsynaptic");
		postSRadius = postSynaptic.GetComponent<SphereCollider> ().radius * postSynaptic.transform.lossyScale.y;

		totalRadius = ballRadius + postSRadius;

		entranceVelocity = new Vector3 (0.0f,1.0f,0.0f);
		velocity = new Vector3 (Random.Range (-1.5f, 1.5f), 1.0f, 0.0f);
		exitVelocity = new Vector3 (2.0f, 1.0f, 0.0f);

		speed = 1;

	}
	// Update is called once per frame
	void Update () {
//		
		distance = Vector3.Distance(transform.position, postSynaptic.transform.position);
		postSAura = Random.Range (-2.0f,0.2f);

		if (transform.position.y <= channelSerotonin.transform.position.y + channelSHeight) {
			speed = 2;
			channelSerotonin.GetComponent<CapsuleCollider> ().enabled = false;
			rb.velocity = entranceVelocity * speed;
		}

		if (transform.position.y > channelSerotonin.transform.position.y + channelSHeight) {
			channelSerotonin.GetComponent<CapsuleCollider> ().enabled = true;
			speed = Random.Range(0.5f, 1.5f);
			rb.velocity = new Vector3 (velocity.x + Random.Range (-1.0f, 1.0f), velocity.y, velocity.z) * speed;
		}

		if (distance <= totalRadius + postSAura) {
			if (transform.position.x <= 0) {
				rb.velocity = new Vector3 (-exitVelocity.x,exitVelocity.y,exitVelocity.z);
			}
			if (transform.position.x > 0) {
				rb.velocity = exitVelocity;
			}
		}
	}
}
