using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WelcomeScript : MonoBehaviour {
	public Canvas canvas;
	private InputField inputField;
	private Button button;
	private static string playerName;
	private static int nameReceived = 0;

	void Start(){
		inputField = canvas.GetComponentInChildren<InputField> ();
		button = canvas.GetComponentInChildren<Button> ();
		button.gameObject.SetActive (false);
	}
	
	public static string returnPlayerName(){
		if (nameReceived == 1)
			return playerName;
		else
			return "";
	}
	
	public void change(){
		Application.LoadLevel (1);
	}
	
	public void nameInput(){
		playerName = inputField.text;
		Debug.Log (playerName);
		nameReceived = 1;
		inputField.gameObject.SetActive (false);
		button.gameObject.SetActive (true);
	}
	
	void Update(){
	}
}
