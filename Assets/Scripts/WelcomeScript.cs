using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WelcomeScript : MonoBehaviour {
	public Canvas canvas;
	private InputField inputField;
	private Button button;
	private string name;
	private int nameReceived = 0;
	void Start(){
		inputField = canvas.GetComponentInChildren<InputField> ();
		button = canvas.GetComponentInChildren<Button> ();
		button.gameObject.SetActive (false);
		DontDestroyOnLoad (gameObject);
	}
	
	public string returnName(){
		if (nameReceived == 1)
			return name;
		else
			return "";
	}
	
	public void change(){
		Application.LoadLevel (1);
	}
	
	public void nameInput(){
		name = inputField.text;
		Debug.Log (name);
		nameReceived = 1;
		inputField.gameObject.SetActive (false);
		button.gameObject.SetActive (true);
	}
	
	void Update(){
	}
}
