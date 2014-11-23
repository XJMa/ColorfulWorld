using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	int score; 
	int lives; 
	int level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		
		GUILayout.BeginArea(new Rect(20, Screen.height - 50 , 50, 90));
		
		if (GUILayout.Button("Quit"))
		{
			Application.LoadLevel("Main Menu");
		}
		
		GUILayout.EndArea (); 
		
		if (lives == 4) {
			GUI.backgroundColor = Color.green; 
		}
		if (lives == 3) {
			GUI.backgroundColor = new Color(0.6f, 0.6f, 0.0f); 
		}
		if (lives == 2) {
			GUI.backgroundColor = new Color(1.0f, 0.4f, 0.0f); 
		}
		if (lives == 1) {
			GUI.backgroundColor = Color.red; 
		}
		GUI.HorizontalScrollbar (new Rect (Screen.width * (0.2f), 7, 90, 200), 0, PlayerPrefs.GetInt ("currentLives") * 25, 0, 100); 
		

			
	}

}
