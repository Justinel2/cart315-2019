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


	private Vector3 startPoint;
	private Vector3 endPoint;


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

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				startPoint = Input.mousePosition;
			}
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				endPoint = Input.mousePosition;

				if (startPoint.x < endPoint.x) {
					GameObject obj = Instantiate (leftFlipper, new Vector3 (hit.point.x, hit.point.y, channel.transform.position.z), Quaternion.identity) as GameObject;
				}
				if (startPoint.x > endPoint.x) {
					GameObject obj = Instantiate (rightFlipper, new Vector3 (hit.point.x, hit.point.y, channel.transform.position.z), Quaternion.identity) as GameObject;
				}
			}
		}
	}
}
