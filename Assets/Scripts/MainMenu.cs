using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Font font;
	public GUIStyle style;
	// Use this for initialization
	void Start () {
		Vector2 pos = new Vector2 (Screen.width * 0.3f, Screen.height * 0.83f);
		gameObject.transform.position = Camera.main.ScreenToViewportPoint(pos);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI (){
		style.font = font;
		style.fontSize = 30;
		
		GUILayout.BeginArea(new Rect(0.3f * Screen.width, Screen.height / 2 , Screen.width /2, 200));

		if (GUILayout.Button("New Game", style))
		{
			PlayerPrefs.SetInt("currentLives", 4);
			PlayerPrefs.SetInt("currentLevel", 0);
			PlayerPrefs.SetInt("spiked", 0);
			Application.LoadLevel("Level0");
		}
		if (GUILayout.Button("Select Level", style))
		{
			//Application.LoadLevel ("select_level_scene");
		}
	/*	if (GUILayout.Button("High Score", style))
		{
			//Application.LoadLevel ("high_score_scene");
		}
*/
		if (GUILayout.Button("Exit", style))
		{
			Application.Quit();
			Debug.Log ("Application.Quit() only works in build, not in editor");
		}
		
		GUILayout.EndArea();
	}
}
