using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {
	void Start(){
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.A))
		   Application.LoadLevel(1);
	}
}