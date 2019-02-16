using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Generate : MonoBehaviour {

	int totalAmount = 20;

	// Use this for initialization
	void Start () {
		GameObject prefab = Resources.Load ("neurotransmitter") as GameObject;
		for (int i = 0; i < 20; i++) {
			GameObject go = Instantiate (prefab) as GameObject;
			go.transform.position = new Vector3 (Random.Range(-10.0f,10.0f), -4, 0);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
