using UnityEngine;
using System.Collections;
public enum LensColor { none, red, yellow, blue };
public enum Level { level0,level1, level2, higherlevels };
public class GameManager : MonoBehaviour {
	public GameObject light;

	public LensColor lens;
	public bool hasRedLens, hasYellowLens, hasBlueLens;
	public Level level;  //Change in unity inspector
	public Texture2D redImage; 
	public Texture2D blueImage; 
	public Texture2D yellowImage; 
	public Font font; 
	public GUIStyle style; 

	bool stopRoutine;

	int i = 0; 
	// Use this for initialization
	public Level nextLevel; 

	void Start () {

		lens = LensColor.none;
		if( level == Level.level0 ){
			hasRedLens = false;//initiate all lens as true for test
			hasYellowLens = false;
			hasBlueLens = false;
			nextLevel = Level.level1;
			PlayerPrefs.SetInt ("currentLevel", 0);
		}
		if (level == Level.level1){
			hasRedLens = true; 
			hasYellowLens = false; 
			hasBlueLens = false;
			lens = LensColor.red;
			nextLevel = Level.level2;
			PlayerPrefs.SetInt ("currentLevel", 1);
		}
		if (level == Level.level2) {
			hasRedLens = true; 
			hasYellowLens = false; 
			hasBlueLens = true;
			lens = LensColor.blue;
			nextLevel = Level.higherlevels;
			PlayerPrefs.SetInt ("currentLevel", 2);
		}

		gameObject.transform.position = new Vector3 (0.0f, 0.0f, 0.0f); 
		gameObject.transform.localScale = new Vector3 (0.01f, 0.01f, 1.0f);

		guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height); 


		style.font = font;
		style.normal.textColor = Color.white;

		stopRoutine = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		//switch lenses
		if(Input.GetKeyDown(KeyCode.Alpha1) && hasRedLens) lens = LensColor.red;
		if(Input.GetKeyDown(KeyCode.Alpha2) && hasBlueLens) lens = LensColor.blue;
		if(Input.GetKeyDown(KeyCode.Alpha3) && hasYellowLens) lens = LensColor.yellow;
		if(lens == LensColor.red){
			light.light.color = Color.Lerp(Color.red, Color.white, 0.3f);
			guiTexture.texture = redImage;
		}
		if(lens == LensColor.yellow){
			light.light.color = Color.Lerp(Color.yellow, Color.white, 0.3f);
			guiTexture.texture = yellowImage;
		}
		if(lens == LensColor.blue){
			light.light.color = Color.Lerp(Color.blue, Color.white, 0.3f);
			guiTexture.texture = blueImage;
		}

		if(level == Level.level0){
			if(stopRoutine == false){
				StartCoroutine(Sequence(ShowMessage("WELCOME TO THE FIRST TUTORIAL LEVEL", 2),
		               			ShowMessage("Grab the Red Lens to interact with the environment", 2),
		                        ShowMessage("When you use a lens, you can see everything but the objects of that color", 2)));
			
				stopRoutine = true;
			}	
		
		}

		if(level == Level.level1){
			if(stopRoutine == false){
				StartCoroutine(Sequence(ShowMessage("Grab the Blue Lens", 2),
			                        ShowMessage("Remember, you can see everything except the \nobjects of the color of the lens you are using", 2)));
				stopRoutine = true;
			}
		}
		if(level == Level.level2){
			if(stopRoutine == false){
			StartCoroutine(Sequence(ShowMessage("Grab the Yellow Lens", 2),
			                        ShowMessage("Play with the three lenses to alternate the obstacles you can see. \nHave fun!", 2)));
			

				stopRoutine = true;
			}
			
		}
		Player player = GameObject.Find("Player").GetComponent<Player>();
		if (player.win){
			StartCoroutine(WinMessage ("CONGRATS! You made it!", 1));
		}



	}
	void OnGUI(){
		if(level == Level.level0){
			if(hasRedLens){

				GUILayout.BeginArea(new Rect(Screen.width * 0.01f, Screen.width * 0.05f, 1000, 1000));
				GUILayout.Label("Shows you what lenses you have", style);
				GUILayout.EndArea ();

				GUILayout.BeginArea(new Rect(Screen.width * 0.5f, Screen.width * 0.05f, 1000, 1000));
				GUILayout.Label("The frame tells you which lens is activated", style);
				GUILayout.EndArea ();
			}
		}
	}


	public static IEnumerator Sequence(params IEnumerator[] sequence)
	{
		for(int i = 0 ; i < sequence.Length; ++i)
		{
			while(sequence[i].MoveNext())
				yield return sequence[i].Current;
		}
	}

	IEnumerator ShowMessage (string message, float delay) {
		guiText.text = message;
		guiText.font = font;
		guiText.pixelOffset = new Vector2 (-120, -300);
		guiText.enabled = true;
		yield return new WaitForSeconds(delay);
		guiText.enabled = false;
	}

	IEnumerator WinMessage (string message, float delay) {
		guiText.text = message;
		guiText.font = font;
		guiText.fontSize = 30; 
		guiText.pixelOffset = new Vector2 (-120, -300);
		guiText.enabled = true;
		yield return new WaitForSeconds(delay);
		Application.LoadLevel("Win");
	}
}
