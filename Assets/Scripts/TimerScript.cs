using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
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
		text.text = ((int)difference / 60).ToString () + " min " + ((int)difference % 60).ToString () + " sec ";
		if (((int)difference / 60) == 12)
			Debug.Log ("Time's up!");
	
	}
}
