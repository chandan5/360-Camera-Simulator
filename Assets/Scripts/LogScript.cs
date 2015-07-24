using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LogScript : MonoBehaviour {
	private GameObject WelcomeCam;
	private static int  allDone = 0;
	private BarrelsScript barrelsScript;
	private List<float> estimatedAngles = new List<float>();
	private List<float> actualAngles = new List<float>();
	private List<string> orderOfSelection = new List<string> ();
	private GameObject[] barrels = new GameObject[12];

	// Use this for initialization
	void Start () {
		barrelsScript = gameObject.GetComponent<BarrelsScript> ();
		barrelsScript.returnLists (out estimatedAngles,out actualAngles,out orderOfSelection);
		barrels = barrelsScript.returnBarrelsArray ();
		WelcomeCam = GameObject.Find ("Welcome Camera");


	}
	public static void setStatus(int status){
		allDone = status;
	}
	
	// Update is called once per frame
	void Update () {
		FileStream fs;
		if (allDone == 1) {
			if(Directory.Exists("./GAMELOGS"))
				Debug.Log("Directory already exits!");
			else 
				Directory.CreateDirectory("./GAMELOGS");

			StreamWriter sw = new StreamWriter("./GAMELOGS/"+WelcomeCam.name+"Angles.txt",false);
			sw.WriteLine("ESTIMATED ANGLES\tACTUAL ANGLES\tBARREL ID");
			for(int i=0; i < estimatedAngles.Count ; i++ ){
				sw.WriteLine(estimatedAngles[i]+" \t"+actualAngles[i]+"\t"+orderOfSelection[i]);
			}
			sw.WriteLine("\n");
			sw.WriteLine("---------------------------------------------------------------------");
			sw.WriteLine("---------------------------------------------------------------------");
			sw.WriteLine("\n");
			sw.WriteLine("BARREL ID\tLOCATION (IN WORLD COORDS)");
			for(int i = 0 ; i< 12 ; i++){
				sw.WriteLine(barrels[i].name+" \t"+barrels[i].transform.position);
			}
			sw.Close();

		}
	}
}
