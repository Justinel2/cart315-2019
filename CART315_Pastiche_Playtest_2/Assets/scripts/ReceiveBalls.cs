using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveBalls : MonoBehaviour {

//	public GameObject ball;
//	public SphereCollider ballCollider;

	public int level = 101; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


	}

	private void OnCollisionEnter(Collision collision){ 
		if (collision.gameObject.tag == "Ball") {
			level += 10; 
		}
	}
}