using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveBalls : MonoBehaviour {

	public float level = 101.000f; 
	public static float timer;
	public AudioClip gobSoundFX; 
	public float scaleX = 3.0f;
	public float decay = 0.05f;

	public GameObject panel;

	// Use this for initialization
	void Start () {

		panel = GameObject.Find("death_panel");

		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = gobSoundFX;
	}
	
	// Update is called once per frame
	void Update () {
		if (level > 50 && level < 300) {
			timer += Time.deltaTime;
			HandleDecay ();
		}
	}

	private void OnCollisionEnter(Collision collision){ 
		if (collision.gameObject.tag == "Ball") {
			level += 10; 
			GetComponent<AudioSource> ().Play ();
		}
	}
	private void HandleDecay(){
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		if (seconds % 5 == 0 && seconds > 0) {
			level -= decay;
		}
		if (seconds % 59 == 0 && seconds > 0) {
			scaleX -= 0.01f;
			decay += 0.02f;
			if (scaleX >= 0.5f) {
				transform.localScale = new Vector3 (scaleX, 1.0f, 1.0f);
			}
		}
	}
}