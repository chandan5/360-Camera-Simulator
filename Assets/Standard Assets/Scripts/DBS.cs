using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DBS : MonoBehaviour
{
	public GameObject mapCam;
	private Text barrelsCounter;
	private Canvas dialogCanvas;
	private MP mpScript;
	private bool placeNow;
	// Use this for initialization
	void Start ()
	{
		placeNow = true;
		barrelsCounter = gameObject.GetComponentsInChildren<Text> ()[3];
		mpScript = mapCam.GetComponent<MP> ();
		dialogCanvas = gameObject.GetComponent<Canvas> ();
		dialogCanvas.enabled = false;
	}

	public bool canPlaceBarrel(){
		return placeNow;
	}

	public void confirmPosition (string reply)
	{
		if (reply == "Y") {
			mpScript.changePlacedBarrelColor ();
			mpScript.SetEnableDialog (false);
			dialogCanvas.enabled = false;
			placeNow = true;
		} else if (reply == "N") {
			mpScript.cancelPrevPlacement ();
			mpScript.SetEnableDialog (false);
			dialogCanvas.enabled = false;
			placeNow = true;
		}
		if (mpScript.returnPlacedCount () == BS.returnCount()) {
//		if (mpScript.returnPlacedCount () == 12) {
			Debug.Log("Application Quittting!");
			mpScript.MapLog();
			Application.Quit();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		barrelsCounter.text = mpScript.returnPlacedCount ().ToString ();
		if (mpScript.enableDialogBox ()) {
			dialogCanvas.enabled = true;
			placeNow = false;
		}
	}
}
