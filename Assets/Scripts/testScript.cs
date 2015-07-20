using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testScript : MonoBehaviour {
	public Text text; 
	private int count;
	void Start(){
		text.text = "Hello";
		count = 0;
	}

	void Update(){
		count = count + 1;
//		text.text = count.ToString ();

	}
}