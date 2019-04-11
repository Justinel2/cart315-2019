using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	GameObject start;
	GameObject restart;

	// Use this for initialization
	void Start () {
		start = GameObject.FindGameObjectWithTag ("Start");

		Time.timeScale = 0;
		start.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			PauseGame ();
		}	
		if (Input.GetKeyDown(KeyCode.S))
		{
			StartGame ();
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			RestartGame ();
		}
	}

	public void PauseGame() {
		Time.timeScale = 0;
		start.SetActive (true);
	}

	public void StartGame() {
		Time.timeScale = 1;
		start.SetActive (false);
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
	}
}
