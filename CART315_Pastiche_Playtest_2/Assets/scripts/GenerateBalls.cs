using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBalls : MonoBehaviour {

	// Declare the game object neurotransmitter variable
	public GameObject neurotransmitter;
	// Declare the variable that defines the total amount of neurotransmitter per group to 5
	int groupAmount = 5;
	// Declare the variable that defines the total amount of neurotransmitter for the level to 20
	int totalAmount = 20;

	// Start() 
	// 
	// Use this for initialization
	//
	void Start () {
		// Load the prefabs "neurotransmitter" as a game object
		neurotransmitter = Resources.Load ("neurotransmitter") as GameObject;
		// Invoke the function generateGroup() at the start of the program and repeat each 8 seconds 
		InvokeRepeating("generateGroup", 0.0f, 8.0f);
	}

	// Update()
	//
	// Update is called once per frame
	//
	void Update () {
	}

	// generateGroup()
	//
	// A function that activates the generation of a group of neurotransmitter in the synapse 
	//
	void generateGroup() {
		for (int i = 0; i < 5; i++) {
			Invoke("generateInd", i*1.5f);
		}
	}

	// generateInd()
	//
	// A function that defines the generation of the neurotransmitters
	//
	void generateInd() {
		// Instantiate a new neurotransmitter as game object
		GameObject ball = Instantiate (neurotransmitter) as GameObject;
		// Place it at the same position than the channel
		ball.transform.position = transform.position;
		// Tag the object "Ball"
		ball.tag = "Ball";
	}
}
