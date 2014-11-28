using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public Font font;
	public GUIStyle style;
	public Level nextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		style.font = font;
		style.fontSize = 30;
		
		GUILayout.BeginArea(new Rect(0.9f * Screen.width / 2, 3.0f * Screen.height / 4.0f , Screen.width /2, 200));
		
		/*
		if (GUILayout.Button("Next Level", style))
		{
			GameObject gm = GameObject.Find("GameManager"); 
			GameManager g = gm.GetComponent<GameManager>();
			switch(g.nextLevel) {
			case Level.level0:
				Application.LoadLevel("Level1");
				break;
			case Level.level1:
				Application.LoadLevel("Level2");
				break;
			case Level.level2:
				Application.LoadLevel("Main Menu");
				break;
			default:
				break;
			}
		}
		*/

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
		
		GUILayout.EndArea ();
	}
}
