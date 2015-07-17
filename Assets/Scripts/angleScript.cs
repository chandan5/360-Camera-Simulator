using UnityEngine;
using System.Collections;

public class angleScript : MonoBehaviour {
	private RectTransform rectangle;
	public float angle = new float();

	// Use this for initialization
	void Start () {
		rectangle = gameObject.GetComponent<RectTransform> ();
		angle = 9999f;
	}


	public void CalculateAngle(){
		Debug.Log ("I'm in Calculate Angle now!");
		Canvas canvas;
		Vector2 mousePositon;
		Vector2 rectangleTransformOfPoint;
		Vector2 clickVector;
		Vector2 reference = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		Vector2 forwardAngle = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		mousePositon = Input.mousePosition;

		RectTransformUtility.ScreenPointToLocalPointInRectangle (rectangle, mousePositon, null, out rectangleTransformOfPoint);

		if (RectTransformUtility.RectangleContainsScreenPoint (rectangle, mousePositon, null) == true) {
			clickVector = rectangleTransformOfPoint - new Vector2 (0f, 0f);
			angle = Vector2.Angle (reference, clickVector);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CalculateAngle ();
		}
	}
}