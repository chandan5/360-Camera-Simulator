using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapCounterScript : MonoBehaviour {
	private Text counter;
	private MapScript mapScript;

	public GameObject mainCamera;


	// Use this for initialization
	void Start () {
		counter = gameObject.GetComponent<Text> ();
		mapScript = mainCamera.GetComponent<MapScript> ();
		counter.text = "Start!";
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = "barrel No : "+mapScript.returnCount ().ToString();
	}
}
