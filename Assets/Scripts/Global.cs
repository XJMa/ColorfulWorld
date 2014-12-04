using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

	int score; 
	int lives; 
	int level;
	public Texture2D livesImage; 
	// Use this for initialization
	void Start () {
		score = 0;
		lives = 4;
		level = 0;


		Vector2 pos = new Vector2 (Screen.width * 0.5f, Screen.height * 0.85f);
		gameObject.transform.position = Camera.main.ScreenToViewportPoint(pos);
		gameObject.transform.localScale = new Vector3 (0.0f, 0.0f, 1.0f);
		guiTexture.pixelInset = new Rect(0, 0, 50, 40);

		guiText.fontSize = 40;
		guiText.pixelOffset = new Vector2 (60, 35);
	}
	
	// Update is called once per frame
	void Update () {
		lives = PlayerPrefs.GetInt ("currentLives");
		Debug.Log (lives);
		if (lives == 4) {
			guiText.text = "4"; 
		}
		if (lives == 3) {
			guiText.text = "3"; 
		}
		if (lives == 2) {
			guiText.text = "2"; 
		}
		if (lives == 1) {
			guiText.text = "1"; 
		}
	
	}
	void OnGUI(){
		
		GUILayout.BeginArea(new Rect(20, Screen.height - 50 , 50, 90));
		
		if (GUILayout.Button("Quit"))
		{
			Application.LoadLevel("Main Menu");
		}
		
		GUILayout.EndArea ();
			
	}

}
