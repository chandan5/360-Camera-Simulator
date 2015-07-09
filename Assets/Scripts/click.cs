using UnityEngine;
using System.Collections;

public class click : MonoBehaviour {
	private Camera camera;
	
	void Start() {
		camera = gameObject.GetComponent<Camera> ();
		Rect r = camera.pixelRect;
//		Debug.Log (gameObject.name);
//		print(gameObject.name+" displays from " + r.xMin + ","+ r.yMin + " to " + r.xMax + ","+ r.yMax);
	}
	
	void Update() {
		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		GameObject cube;
		LayerMask barrelsLayer = 9;
		//		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		if (Input.GetMouseButton (0)) {
			if( camera.pixelRect.Contains(Input.mousePosition)){
//				Debug.Log(gameObject.name);
				Debug.DrawRay (ray.origin, ray.direction*999, Color.red);
				if(Physics.Raycast(ray,out hit,999,8)){
					Debug.DrawRay(ray.origin,ray.direction*50,Color.green);
					cube = hit.collider.gameObject;
//					Debug.Log(cube.name);
				}
			}
		}
	}
}
