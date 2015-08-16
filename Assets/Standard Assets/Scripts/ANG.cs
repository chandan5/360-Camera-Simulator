using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ANG : MonoBehaviour {

	public GameObject gameCamera;


	private Image compassImage;
	private BS bsInAng;
	private float angle;
	private RectTransform compassRectangle;
	private bool angleCalculated;

	// Use this for initialization
	void Start () {
		compassImage = gameObject.GetComponentInChildren<Image> ();
		compassImage.enabled = false;
		angleCalculated = false;

		bsInAng = gameCamera.GetComponent<BS> ();
		compassRectangle = gameObject.GetComponentsInChildren<RectTransform> ()[1];
		angle = 999f;
	}

	public bool IsAngleCalculated(){
		return angleCalculated;	
	}

	public float getAngle(){
		float returnValue = angle;

		return returnValue;
	}

	public void CalculateAngle(){

		Vector2 rectangleTransformOfPoint;
		Vector2 reference = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);

		if (RectTransformUtility.RectangleContainsScreenPoint (compassRectangle, Input.mousePosition, null) == true && Input.GetMouseButtonDown(0) && compassImage.enabled == true) {
			RectTransformUtility.ScreenPointToLocalPointInRectangle (compassRectangle, Input.mousePosition, null, out rectangleTransformOfPoint);
			if(rectangleTransformOfPoint.x < 0)
				angle = -(Vector2.Angle (reference, rectangleTransformOfPoint));
			else 
				angle = Vector2.Angle (reference, rectangleTransformOfPoint);
			Debug.Log("The estimated angle is "+angle);
			angleCalculated = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (bsInAng.returnEnableCompass () == true) {
			compassImage.enabled = true;
			if (Input.GetMouseButtonDown (0))
				CalculateAngle ();
		} else if (bsInAng.returnEnableCompass () == false) {
			angle = 999f;
			compassImage.enabled = false;
			angleCalculated = false;
		}
			
	}
}
