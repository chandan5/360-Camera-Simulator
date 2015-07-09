using UnityEngine;
using System.Collections;

public class Angle : MonoBehaviour {
	private Canvas canvas;
	public GameObject image;
	private RectTransform rectangle;
	
	void Start() {
		rectangle = image.GetComponent<RectTransform> ();
		canvas = gameObject.GetComponent<Canvas> ();
		//		gameObject.SetActive (false);
		Debug.Log ("World cooridinate of canvas "+gameObject.transform.position);
		Debug.Log ("World coordinate of image " + image.transform.position);
	}
	
	void FixedUpdate() {
		Vector2 newPt;

		if (Input.GetKey (KeyCode.P)) {
			Debug.Log(Input.mousePosition);
			RectTransformUtility.ScreenPointToLocalPointInRectangle (rectangle, Input.mousePosition, null,out newPt);
			Debug.Log ("Screen Point of image " + newPt);
			newPt = newPt - new Vector2(0f,0f);
			Debug.Log(Vector2.Angle(reference,newPt));

		}
	}
}