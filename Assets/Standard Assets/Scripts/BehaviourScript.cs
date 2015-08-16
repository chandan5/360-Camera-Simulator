using UnityEngine;
using System.Collections;

public class BehaviourScript : MonoBehaviour {
	public float speed = 10.0F;
	void Update() {
		float verticalTranslation = Input.GetAxis("Vertical") * speed;
		float horizontalTranslation = Input.GetAxis("Horizontal") * speed;
		
		verticalTranslation *= Time.deltaTime;
		horizontalTranslation *= Time.deltaTime;
		transform.Translate(0, 0, verticalTranslation*20);
		transform.Translate(horizontalTranslation*20, 0, 0);

	}
}
