using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

	// Other game objects
	public GameObject postSynaptic;
	public GameObject channelSerotonin;
	// Rigid body of the neurotransmitter
	public Rigidbody rb;
	// Colliders of the other game objects
	public SphereCollider postSCollider;
	public CapsuleCollider channelSCollider;
	// Different velocities
	private Vector3 entranceVelocity, velocity, exitVelocity; 
	// Different float values
	private float speed, ballRadius, channelSHeight, postSRadius, postSAura, distance, totalRadius;
	private bool touchedByFlipper;

	// Start()
	//
	// Use this for initialization
	//
	void Start () {

		// Find the other game objects
		channelSerotonin = GameObject.Find("channel_serotonin");
		postSynaptic = GameObject.Find("postsynaptic");

		// Get the rigid body of the neurotransmitter
		rb = GetComponent<Rigidbody> ();

		// Get the height of the pre synaptic channel
		channelSHeight = channelSerotonin.GetComponent<CapsuleCollider> ().bounds.size.y;

		// Get the radius of the neurotransmitter
		ballRadius = GetComponent<SphereCollider>().radius * transform.lossyScale.x;
		// Get the radius of the post synaptic neuron collider
		postSRadius = postSynaptic.GetComponent<SphereCollider> ().radius * postSynaptic.transform.lossyScale.y;
		// Add the neurotransmitter radius to the post synaptic collider one
		totalRadius = ballRadius + postSRadius;

		// Define the diffent velocities
		entranceVelocity = new Vector3 (0.0f,1.0f,0.0f);
		velocity = new Vector3 (Random.Range (-1.5f, 1.5f), 1.0f, 0.0f);
		exitVelocity = new Vector3 (2.0f, 1.0f, 0.0f);

		// Define the default speed
		speed = 1;

		// Define the starting state of the neurotransmitter to untouched by a flipper
		touchedByFlipper = false;

		// Define the default gravity to be false
		rb.useGravity = false;

	}

	// Update()
	//
	// Update is called once per frame
	//
	void Update () {
		// Call functions
		calculateDistanceBallToPostS();
		// If the flipper has not yet touched the neurotransmitter
		if (!touchedByFlipper) {
			handleBallMovements ();
		}
		// If the flipper has touched the neurotransmitter
		if (touchedByFlipper) {
			handleFlipperCollision ();
		}
	}

	// calculateDistanceBallToPostS
	//
	// Function that calculates the distance between the ball and the postsynaptic area and
	// its particular aura (adds realism - acts like an error gap)
	//
	void calculateDistanceBallToPostS() {
		// the distance is the one between the neurotransmitter and the postSynaptic collider
		distance = Vector3.Distance(transform.position, postSynaptic.transform.position);
		// the aura randomly generated between -2 and 2
		postSAura = Random.Range (-2.0f,0.2f);
	}

	// OnCollisionEnter(collision)
	//
	// A function that verifies if the ball collided with a flipper
	//
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Flipper") {
			touchedByFlipper = true;
		}
	}

	// handleBallMovements()
	//
	// Function that calculates the velocity and speed of each ball/neurotransmitter according
	// to its position
	//
	void handleBallMovements () {
		// if the neurotransmitter y position is less or equal to the channel + 1 
		// (if the neurotransmitter just got generated from the channel)
		if (transform.position.y <= channelSerotonin.transform.position.y + channelSHeight) {
			// double the value of the speed
			speed = 2;
			// remove the channel collider
			channelSerotonin.GetComponent<CapsuleCollider> ().enabled = false;
			// adjust the velocity and speed 
			rb.velocity = entranceVelocity * speed;
		}
		// if the neurotransmitter y position is more than the channel + 1
		// (if the neurotransmitter is well in the synapse)
		if (transform.position.y > channelSerotonin.transform.position.y + channelSHeight) {
			// enable the channel collider
			channelSerotonin.GetComponent<CapsuleCollider> ().enabled = true;
			// randomize the value of the speed 
			speed = Random.Range(0.5f, 1.5f);
			// adjust the velocity and speed 
			rb.velocity = new Vector3 (velocity.x + Random.Range (-1.0f, 1.0f), velocity.y, velocity.z) * speed;
		}
		// if the neurotransmitter approaches the aura of the postsynaptic neuron
		if (distance <= totalRadius + postSAura) {
			// if the neurotransmitter is at the middle or the left of the screen
			if (transform.position.x <= 0) {
				// adjust the velocity and speed
				rb.velocity = new Vector3 (-exitVelocity.x,exitVelocity.y,exitVelocity.z);
			}
			// if the neurotransmitter is at the right side of the screen
			if (transform.position.x > 0) {
				// adjust the velocity and speed
				rb.velocity = exitVelocity;
			}
		}
	}
	// handleFlipperCollision()
	//
	// A function that adds gravity to the balls that have been in contact with a flipper
	//
	void handleFlipperCollision () {
		// Define the gravity to be true
		rb.useGravity = true;
	}


}
