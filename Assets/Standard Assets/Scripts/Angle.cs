using UnityEngine;
using System.Collections;

public class Angle : MonoBehaviour {

	public GameObject image;
	private RectTransform rectangle;
//	private Canvas canvas;
	
	void Start() {
		rectangle = image.GetComponent<RectTransform> ();
//		canvas = gameObject.GetComponent<Canvas> ();
//		gameObject.SetActive (false);
		Debug.Log ("World cooridinate of canvas "+gameObject.transform.position);
		Debug.Log ("World coordinate of image " + image.transform.position);
	}
	
	void FixedUpdate() {
		Vector2 newPt;
		Vector2 reference = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		if (Input.GetKey (KeyCode.P)) {
			Debug.Log(Input.mousePosition);
			RectTransformUtility.ScreenPointToLocalPointInRectangle (rectangle, Input.mousePosition, null,out newPt);
			Debug.Log ("Screen Point of image " + newPt);
			newPt = newPt - new Vector2(0f,0f);
			Debug.Log(Vector2.Angle(reference,newPt));
		}
	}
}