using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperGenerator : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	// Declare the game object neurotransmitter variable
	public GameObject leftFlipper;
	public GameObject rightFlipper;
	public GameObject channel;

	// Use this for initialization
	void Start () {
		// Load the prefabs as a game objects
		leftFlipper = Resources.Load ("left_flipper") as GameObject;
		rightFlipper = Resources.Load ("right_flipper") as GameObject;

		channel = GameObject.Find("channel_serotonin");
	}

	// Update is called once per frame
	void Update () {
		
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {

			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				if (hit.point.x <= 0) {
					GameObject obj = Instantiate (leftFlipper, new Vector3 (hit.point.x, hit.point.y, channel.transform.position.z), Quaternion.identity) as GameObject;
				}
				if (hit.point.x > 0) {
					GameObject obj = Instantiate (rightFlipper, new Vector3 (hit.point.x, hit.point.y, channel.transform.position.z), Quaternion.identity) as GameObject;
				}
			}
		}
	}
}

