using UnityEngine;
using System.Collections;

public class YellowLensGui : MonoBehaviour {

	public Texture yellowLensImage;
	
	// Use this for initialization
	void Start () {
		guiTexture.enabled = false;
		Vector2 pos = new Vector2 (Screen.width * 0.21f, Screen.height * 0.83f);
		gameObject.transform.position = Camera.main.ScreenToViewportPoint(pos);
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gm = GameObject.Find("GameManager"); 
		GameManager g = gm.GetComponent<GameManager>(); 
		if(g.hasYellowLens == true){
			showImage ();
		}	
		
	}
	
	public void showImage(){
		guiTexture.enabled = true;
	}
}
