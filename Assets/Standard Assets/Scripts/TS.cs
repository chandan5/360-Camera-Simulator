using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TS : MonoBehaviour {
	private float startTime;
	private Text text;

	private bool logTimeUp;
	private int lastMinute;
	private int lastSecond;

	// Use this for initialization
	void Start () {
		logTimeUp = false;
		text = gameObject.GetComponentInChildren<Text> ();
		startTime = Time.time;
	}

	public void returnTimeTaken(out int minute,out int second){
		minute = lastMinute;
		second = lastSecond;
	}

	public bool timeUp(){
		return logTimeUp;
	}

	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;
		float timeTaken = currentTime - startTime;

		int seconds = (int)timeTaken % 60;
		int minutes = (int)timeTaken / 60;

		text.text = minutes.ToString () + " min " + seconds.ToString () + " sec";

		lastMinute = minutes;
		lastSecond = seconds;

		if (Input.GetKeyDown (KeyCode.T)) {
			lastMinute = 12;
		}

		if (lastMinute == 12) {
			logTimeUp = true;
			Application.LoadLevel(2);
		}
	}
}