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
	private float distance;

	private Vector3 angleReference;
	private float limitMinAngle;
	private float limitMaxAngle;


	// Use this for initialization
	void Start () {
		// Load the prefabs as a game objects
		leftFlipper = Resources.Load ("left_flipper") as GameObject;
		rightFlipper = Resources.Load ("right_flipper") as GameObject;

		channel = GameObject.Find("channel_serotonin");

		angleReference = new Vector3 (0.0f,100.0f,0.0f);
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
				distance = Vector3.Distance (startPoint, endPoint);

				Vector3 direction = endPoint - startPoint;
				float angle = Vector3.Angle(direction, angleReference);
				print (angle);

				if (angle < 90) {
					limitMinAngle = -90;
					limitMaxAngle = 0;
				}
				if (angle >= 90) {
					angle = -angle;
					limitMinAngle = 0;
					limitMaxAngle = 90;
				}

				if (startPoint.x < endPoint.x) {
					GameObject obj = Instantiate (leftFlipper, new Vector3 (hit.point.x, hit.point.y, channel.transform.position.z),   Quaternion.Euler(0, 0, angle)) as GameObject;
					HingeJoint hj = obj.GetComponent<HingeJoint>();
					JointLimits limits = hj.limits;
					limits.min = limitMinAngle;
					limits.max = limitMaxAngle;
					print (limits.min);
					hj.limits = limits;
				}
				if (startPoint.x > endPoint.x) {
					GameObject obj = Instantiate (rightFlipper, new Vector3 (hit.point.x, hit.point.y, channel.transform.position.z), Quaternion.Euler(0,0, angle)) as GameObject;
				}
			}
		}
	}
}