using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipperGenerator : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	// Declare the game object neurotransmitter variable
	public GameObject leftFlipper;
	public GameObject rightFlipper;
	public GameObject channel;
	public GameObject postSynaptic;

	// Declare the variables linked to the mouse actions
	private bool firstClick = false;
	private Vector3 startPoint;
	private Vector3 endPoint;
	private Vector3 middle;

	// Declare the variables that computes the angle of the flippers
	private Vector3 angleReference;
	private float limitMinAngle;
	private float limitMaxAngle;

	// Declare the variables of the List containing the flippers
	List <GameObject> flippersList;
	int amountFlippers = -1; 
	int indexSelected;

	// Button to toggle the flippers to the left (left arrow) 
	public string toggleLeft = "Left";
	// Button to toggle the flippers to the right (right arrow) 
	public string toggleRight = "Right";
	// Button to destroy an Active flipper
	public string buttonDelete = "Delete";

	// Use this for initialization
	void Start () {
//		// Create the line for the flippers
//		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
//		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
//		lineRenderer.widthMultiplier = 0.2f;
		
		// Load the prefabs as a game objects
		leftFlipper = Resources.Load ("left_flipper") as GameObject;
		rightFlipper = Resources.Load ("right_flipper") as GameObject;

		// Find the channel
		channel = GameObject.Find("channel_serotonin");

		postSynaptic = GameObject.Find ("postsynaptic");

		// Use a vertical vector for the angle
		angleReference = new Vector3 (0.0f,100.0f,0.0f);

		// Create a new List for the flippers
		flippersList = new List<GameObject> ();

		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.widthMultiplier = 0.01f;
		lineRenderer.positionCount = 1;

	}

	// Update is called once per frame
	void Update () {

		// Define the raycast for mouse position
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			Generate ();
			Toggle ();	
			Destroy ();
		}
	}

	//
	void Generate() {

		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition (0, Camera.main.ScreenToWorldPoint (Input.mousePosition));

		// If the left mouse button is clicked for the first time
		if (Input.GetKeyUp (KeyCode.Mouse0) && firstClick == false) {
			lineRenderer.positionCount = 2;
//			print ("enters loop start");
			// Store the position as the start point
			startPoint = hit.point;
//			print (startPoint + " " + hit.point);
			lineRenderer.SetPosition (1, startPoint);
			firstClick = true;
			return;
		}
//
//		// If the left mouse button is clicked a second time
		if (Input.GetKeyUp (KeyCode.Mouse0) && firstClick == true) {
			lineRenderer.SetPosition (0, endPoint);
			lineRenderer.positionCount = 1;
//			print ("enters loop second");
			// Store the mouse position as the end point
			endPoint = hit.point;
//			print (endPoint + " " + hit.point);
			// Calculate the distance between the two points
			middle = (startPoint - endPoint) /2;
			print (middle);
			// Calculate the vector from start point to end point
			Vector3 direction = endPoint - startPoint;
			// Calculate the angle of the direction vector by comparing it to our reference vector
			float angle = Vector3.Angle(direction, angleReference);

//			// If the horizontal position of the start point is smaller than the one of the end point
			if (startPoint.x < endPoint.x) {
				// If the angle of the vector is less than 90degrees
				if (angle < 90) {
					// Modify the Hingejoints limits values
					limitMinAngle = -90;
					limitMaxAngle = 0;
				}
				// If the angle of the vector is more or equal than 90degrees
				if (angle >= 90) {
					// Modify the Hingejoints limits values
					angle = -angle;
					limitMinAngle = 0;
					limitMaxAngle = 90;
				}
				// Instantiate in the Flippers List a left Flipper object at the click position, with the angle of the vector 
				flippersList.Add((GameObject)Instantiate (leftFlipper, new Vector3 (hit.point.x + 2*middle.x, hit.point.y + middle.y, channel.transform.position.z),   Quaternion.Euler(0, 0, angle)));
				// Add one to the amount of Flippers
				amountFlippers++;
				// Modify the HingeJoint values to the correct ones
				HingeJoint hj = flippersList[amountFlippers].GetComponent<HingeJoint>();
				JointLimits limits = hj.limits;
				limits.min = limitMinAngle;
				limits.max = limitMaxAngle;
				hj.limits = limits;

			}

			// If the horizontal position of the start point is bigger than the one of the end point
			if (startPoint.x > endPoint.x) {
				// Instantiate in the Flippers List a right Flipper object at the click position, with the angle of the vector 
				flippersList.Add((GameObject)Instantiate (rightFlipper, new Vector3 (hit.point.x + 2*middle.x, hit.point.y + middle.y, channel.transform.position.z), Quaternion.Euler(0,0, angle)));
				amountFlippers++;
			}


			// Put the new instantiation as the selected flipper index
			indexSelected = amountFlippers;
			// Reset the active flipper
			ResetActive (indexSelected);

			// Ignore collision with the postsynaptic neuron
			Physics.IgnoreCollision(postSynaptic.GetComponent<Collider>(), flippersList[amountFlippers].GetComponent<Collider>());

			//Put back the firstClick to false
			firstClick = false;
			return;
		}
	}

	//
	void Toggle() {
		// If the left arrow button is down
		if (Input.GetButtonUp(toggleLeft) && indexSelected > 0) {
			// Change the index to the previous one in the list
			indexSelected--;
			// Reset the active flipper
			ResetActive (indexSelected);
//			print (indexSelected);
		}
		// If the right arrow button is down
		if (Input.GetButtonUp(toggleRight) && indexSelected < amountFlippers) {
			// Change the index to the next one in the list
			indexSelected++;
			// Reset the active flipper
			ResetActive (indexSelected);
//			print (indexSelected);
		}
	}

	//
	void Destroy() {
		for (int i = 0; i <= amountFlippers; i++) {
			if (flippersList[i].tag == "Active" && Input.GetButtonDown(buttonDelete)) {
				if (i > 0) {
					ResetActive (i-1);
				}
				if (i <= 0 && amountFlippers > 0) {
					ResetActive (i+1);
				}
				amountFlippers -= 1; 
				Destroy (flippersList[i].gameObject);
				flippersList.RemoveAt(i);
			}
		}
	}

	// Void function that resets the active flipper tag by toggling tags
	void ResetActive(int iSelected) {
		for (int i = 0; i <= amountFlippers; i++) {
			flippersList[i].tag = "Untagged";
		}
		flippersList[iSelected].tag = "Active";
	}
}