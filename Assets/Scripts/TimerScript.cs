using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour {
	public GameObject camera;

	private List<Vector3> positions = new List<Vector3> ();
	private float startTime;
	private Text text;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		text = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;
		float difference = currentTime - startTime;
		int currentSecond = 0;
		text.text = ((int)difference / 60).ToString () + " min " + ((int)difference % 60).ToString () + " sec ";
		if (((int)difference % 60) == currentSecond) {
			positions.Add(camera.gameObject.transform.position);
			currentSecond = ((int)difference % 60) + 1;
		}
		if (((int)difference / 60) == 12) {
			Debug.Log ("Time's up!");
			LogScript.setStatus(1);
			Application.LoadLevel(2);
		}

		 
	}
}
