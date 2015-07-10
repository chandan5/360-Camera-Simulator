using UnityEngine;
using System.Collections;

public class angleScript : MonoBehaviour {
	private RectTransform rectangle;
	public float angle;
	// Use this for initialization
	void Start () {
//		Debug.Log ("The gameobject coordinates are " + gameObject.transform.position);
		rectangle = gameObject.GetComponent<RectTransform> ();
		angle = 9999f;
	}
	
	// Update is called once per frame
	void Update () {
		Canvas canvas;
		Vector2 mousePositon;
		Vector2 rectangleTransformOfPoint;
		Vector2 clickVector;
		Vector2 reference = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		Vector2 forwardAngle = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		if (Input.GetMouseButtonDown (0)) {
			mousePositon = Input.mousePosition;
			RectTransformUtility.ScreenPointToLocalPointInRectangle( rectangle, mousePositon , null,out rectangleTransformOfPoint);
//			Debug.Log("The rect corrdinates are " + rectangleTransformOfPoint);
			clickVector = rectangleTransformOfPoint - new Vector2(0f,0f);
			angle = Vector2.Angle(reference,clickVector);
			Debug.Log("The angle is " + angle);
			canvas = GetComponentInParent<Canvas>();
			canvas.enabled = false;
		}
	
	}
}
