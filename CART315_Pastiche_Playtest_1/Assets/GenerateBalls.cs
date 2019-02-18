using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers; 

public class GenerateBalls : MonoBehaviour {

	public GameObject neurotransmitter;
	int totalAmount = 20;

	// Use this for initialization
	void Start () {
		neurotransmitter = Resources.Load ("neurotransmitter") as GameObject;
		InvokeRepeating("generateGroup", 0.0f, 8.0f);
//		for (int i = 0; i < 5; i++) {
//			GameObject ball = Instantiate (neurotransmitter) as GameObject;
//			ball.transform.position = transform.position;
//		}

	}

	// Update is called once per frame
	void Update () {
	}

	void generateGroup() {
		for (int i = 0; i < 5; i++) {
			Invoke("generateInd", i*1.5f);
		}
	}

	void generateInd() {
		GameObject ball = Instantiate (neurotransmitter) as GameObject;
		ball.transform.position = transform.position;
	}
}
