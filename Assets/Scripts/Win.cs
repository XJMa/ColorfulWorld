using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public Font font;
	public GUIStyle style;
	public Level nextLevel;
	// Use this for initialization
	void Start () {
		Vector2 pos = new Vector2 (Screen.width * 0.1f, Screen.height * 0.83f);
		gameObject.transform.position = Camera.main.ScreenToViewportPoint(pos);
		guiText.text = "\t\tCongrats! \nYou made it to the next level!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		style.font = font;
		style.fontSize = 30;
		
		GUILayout.BeginArea(new Rect(0.3f * Screen.width, 3.0f * Screen.height / 4.0f , Screen.width /2, 200));

		if (GUILayout.Button("Next Level", style))
		{
			switch(PlayerPrefs.GetInt("currentLevel")){
			case 0:
				Application.LoadLevel("Level1");
				break;
			case 1:
				Application.LoadLevel("Level2");
				break;
			case 2:
				Application.LoadLevel("HigherLevel");
				break;
			case 3:
				Application.LoadLevel("Main Menu");
				break;
			default:
				break;
			}
		}
		/*
		if (GUILayout.Button("Main Menu", style))
		{
			Application.LoadLevel("Main Menu");
		}

		if(GUILayout.Button("Level0", style))
		{
			Application.LoadLevel("Level0");
		}
		
		if(GUILayout.Button("Level1", style))
		{
			Application.LoadLevel("Level1");
		}
		
		if(GUILayout.Button("Level2", style))
		{
			Application.LoadLevel("Level2");
		}
		*/
		GUILayout.EndArea ();
	}
}
