using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TimerScript : MonoBehaviour {
	public GameObject gameCamera;

	private static List<Vector3> positions = new List<Vector3> ();
	private float startTime;
	private Text text;

	private static int lastMinute;
	private static int lastSecond;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		text = gameObject.GetComponent<Text> ();
	}

	public static void returnAllPositions(out List<Vector3> allPositions){
		allPositions = positions;
	} 
	public static void returnTimeTaken(out int minute,out int second){
		minute = lastMinute;
		second = lastSecond;
	}

	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;
		float difference = currentTime - startTime;
		int secondsCounter = 0;
		text.text = ((int)difference / 60).ToString () + " min " + ((int)difference % 60).ToString () + " sec ";

		lastMinute = ((int)difference / 60);
		lastSecond = ((int)difference % 60);

		if (((int)difference % 60) == secondsCounter) {
			positions.Add(gameCamera.gameObject.transform.position);
			secondsCounter = ((int)difference % 60) + 1;
		}
		if (((int)difference / 60) == 12) {
			Debug.Log ("Time's up!");
			LogScript.setStatus(1);
			Application.LoadLevel(2);
		}

		 
	}
}
