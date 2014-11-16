using UnityEngine;
using System.Collections;
public enum LensColor { none, red, yellow, blue };
public class GameManager : MonoBehaviour {
	public GameObject light;

	public LensColor lens;
	public bool hasRedLens, hasYellowLens, hsBlueLens;
	// Use this for initialization
	void Start () {
		lens = LensColor.none;
		hasRedLens = true;//initiate all lens as true for test
		hasYellowLens = true;
		hasRedLens = true;
	}
	
	// Update is called once per frame
	void Update () {
		//switch lenses
		if(Input.GetKeyDown(KeyCode.Alpha1) && hasRedLens) lens = LensColor.red;
		if(Input.GetKeyDown(KeyCode.Alpha2) && hasRedLens) lens = LensColor.yellow;
		if(Input.GetKeyDown(KeyCode.Alpha3) && hasRedLens) lens = LensColor.blue;
		if(lens == LensColor.red){
			light.light.color = Color.Lerp(Color.red, Color.white, 0.5f);
		}
		if(lens == LensColor.yellow){
			light.light.color = Color.Lerp(Color.yellow, Color.white, 0.5f);
		}
		if(lens == LensColor.blue){
			light.light.color = Color.Lerp(Color.blue, Color.white, 0.5f);
		}
		
	}
}