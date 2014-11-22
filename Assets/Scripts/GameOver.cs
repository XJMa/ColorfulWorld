using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Font font;
	public GUIStyle style;
	public Level level;

	// Use this for initialization
	void Start () {
		guiText.text = "Game Over";
		guiText.fontSize = 50;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		style.font = font;
		style.fontSize = 30;
		
		GUILayout.BeginArea(new Rect(0.9f * Screen.width / 2, 3.0f * Screen.height / 4.0f , Screen.width /2, 200));
		

		if (GUILayout.Button("Main Menu", style))
		{
			Application.LoadLevel("Main Menu");
		}
		
		GUILayout.EndArea ();
	}
}
