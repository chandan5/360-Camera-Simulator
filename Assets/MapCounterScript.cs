using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapCounterScript : MonoBehaviour {
	private Text counter;
	MapScript mapScript;
	GameObject camera;
	// Use this for initialization
	void Start () {
		counter = gameObject.GetComponent<Text> ();
		mapScript = camera.GetComponent<MapScript> ();
		counter.text = "Start!";
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = mapScript.returnCount ().ToString();
	}
}
