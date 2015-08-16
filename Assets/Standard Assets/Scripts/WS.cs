using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WS : MonoBehaviour {

	private static string player;
	private InputField nameInput;
	private Button readyButton;
	// Use this for initialization
	void Start () {
		readyButton = gameObject.GetComponentInChildren<Button> ();
		nameInput = gameObject.GetComponentInChildren<InputField> ();

		nameInput.gameObject.SetActive (true);
		readyButton.gameObject.SetActive (false);
	}

	public static string returnPlayerName(){
		return player;
	}

	public void nameAcquired(){
		player = nameInput.text;
		nameInput.gameObject.SetActive (false);
		readyButton.gameObject.SetActive (true);
	}

	public void readyButtonPress(){
		gameObject.GetComponent<Canvas> ().enabled = false;
		Application.LoadLevel (1);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
