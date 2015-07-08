using UnityEngine;
using System.Collections;

public class BehaviourScript : MonoBehaviour {
	public float horizontalSpeed = 2.0F;
	public float speed = 10.0F;
	void Update() {
		float verticalTranslation = Input.GetAxis("Vertical") * speed;
		float horizontalTranslation = Input.GetAxis("Horizontal") * speed;
		
		verticalTranslation *= Time.deltaTime;
		horizontalTranslation *= Time.deltaTime;
		
		transform.Translate(0, 0, verticalTranslation);
		transform.Translate(horizontalTranslation, 0, 0);
//		float h = horizontalSpeed * Input.GetAxis("Mouse X");
//		transform.Rotate(0, h, 0);
	}
}
