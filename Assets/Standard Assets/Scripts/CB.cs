using UnityEngine;
using System.Collections;

public class CB : MonoBehaviour {

	private Camera cameraSmall;
	private Ray cameraRay;
	private RaycastHit rayHit;
	private int layerMask = 1 << 9;
	private GameObject hitObject;
	private bool hit;

	// Use this for initialization
	void Start () {
		hit = false;
		cameraSmall = gameObject.GetComponent<Camera> ();
	}

	public bool objectHit(){
		if (hit == true) {
			hit = false;
			return true;
		} else
			return hit;

	}



	public GameObject returnHitObject(){
		Debug.Log ("return " + hitObject.name + " object from " + gameObject.name + ", the object at position "+hitObject.transform.position);
		return hitObject;
	}

	// Update is called once per frame
	void Update () {
		cameraRay = cameraSmall.ScreenPointToRay(Input.mousePosition);


		if (Input.GetMouseButtonDown (0)) {
			Debug.DrawRay(cameraRay.origin,cameraRay.direction*999,Color.red);
			if(cameraSmall.pixelRect.Contains(Input.mousePosition)){
				if(Physics.Raycast(cameraRay,out rayHit,999f,layerMask)){
					hit = true;
					hitObject = rayHit.collider.gameObject;
					Debug.DrawRay(cameraRay.origin,cameraRay.direction*999,Color.green);
//					Debug.Log("HIT "+hitObject.name);
				}
			}
		}

	
	}
}
