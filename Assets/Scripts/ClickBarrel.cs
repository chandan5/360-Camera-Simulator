using UnityEngine;
using System.Collections;

public class ClickBarrel : MonoBehaviour {
	private Camera camera;
	public int barrelFound = 0;
	private GameObject barrel; 
	void Start() {
		camera = gameObject.GetComponent<Camera> ();
	}

	public GameObject returnBarrel(){
		return barrel;
	}

	void Update() {
		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		var layermask = 1 << 9;
//		LayerMask barrelsLayer = 9;
//		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		if (Input.GetMouseButton (0)) {
			if( camera.pixelRect.Contains(Input.mousePosition)){
				Debug.DrawRay (ray.origin, ray.direction*999, Color.red);
				if(Physics.Raycast(ray,out hit,999,layermask)){
					Debug.DrawRay(ray.origin,ray.direction*50,Color.green);
					barrel = hit.collider.gameObject;
					barrelFound = 1;
				}
			}
		}
	}
}
