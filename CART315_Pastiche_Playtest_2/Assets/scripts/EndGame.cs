using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Image image;
	public float alpha = 0.0f;

	public GameObject receptor;
	private float level;
	private int color;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
//		//Assign Alpha to transparent
//		image.color = new Color (0.0f,0.0f,0.0f,0.0f);

		receptor = GameObject.Find("receptor_serotonin");
	}

	void Update () {
		level = receptor.GetComponent<ReceiveBalls>().level;
//		print (level);

		if (level < 100) {
			alpha = 2*(1.000f - (level / 100.000f));
			color = 0;
		}
		if (level >= 100 && level <= 200) {
			alpha = 0;
			color = 0;
		}
		if (level > 200) {
			alpha = 2*((level / 200.000f) - 1);
			color = 255;
		}

		if (level <= 50 || level >= 300) {
			Time.timeScale = 0;
		}

		image.color = new Color (color,color,color,alpha);
	}
}
