using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class testScript : MonoBehaviour {
	
	private float angle;
	private RectTransform compassRectangle;
	private Vector2 rectangleTransformOfPoint;
	// Use this for initialization
	void Start () {
		compassRectangle = gameObject.GetComponentInChildren<RectTransform> ();
		angle = 999f;
	}
	
	public void CalculateAngle(){
		Vector2 mousePositon;
//		Vector2 rectangleTransformOfPoint;
		Vector2 clickVector;
		Vector2 reference = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		
		mousePositon = Input.mousePosition;

		if (RectTransformUtility.RectangleContainsScreenPoint (compassRectangle, mousePositon, null) == true) {
			RectTransformUtility.ScreenPointToLocalPointInRectangle (compassRectangle, mousePositon, null, out rectangleTransformOfPoint);
			Debug.Log(rectangleTransformOfPoint);
			clickVector = rectangleTransformOfPoint - new Vector2 (0f, 0f);
			if(rectangleTransformOfPoint.x < 0){
				angle = -(Vector2.Angle (reference, clickVector));
			}
			else 
				angle = Vector2.Angle (reference, clickVector);
			Debug.Log("The estimated angle is "+angle);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		Vector2 reference = new Vector2(0f,1f) - new Vector2(0f,0f);
		if (Input.GetMouseButtonDown (0)) {

			if(gameObject.GetComponent<Canvas>().enabled == false)
				gameObject.GetComponent<Canvas>().enabled = true;
			else
				gameObject.GetComponent<Canvas>().enabled = false;
		}
	}
}
