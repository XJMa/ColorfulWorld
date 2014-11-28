using UnityEngine;
using System.Collections;
public enum LensColor { none, red, yellow, blue };
public enum Level { level0,level1, level2, higherlevels };
public class GameManager : MonoBehaviour {
	public GameObject light;

	public LensColor lens;
	public bool hasRedLens, hasYellowLens, hasBlueLens;
	public Level level;  //Change in unity inspector
	// Use this for initialization
	public Level nextLevel;
	void Start () {
		lens = LensColor.none;
		if( level == Level.level0 ){
			hasRedLens = false;//initiate all lens as true for test
			hasYellowLens = false;
			hasBlueLens = false;
			nextLevel = Level.level1;
		}
		if (level == Level.level1){
			hasRedLens = true; 
			hasYellowLens = false; 
			hasBlueLens = false;
			lens = LensColor.red;
			nextLevel = Level.level2;
		}
		if (level == Level.level2) {
			hasRedLens = true; 
			hasYellowLens = false; 
			hasBlueLens = true;
			lens = LensColor.blue;
			nextLevel = Level.higherlevels;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//switch lenses
		if(Input.GetKeyDown(KeyCode.Alpha1) && hasRedLens) lens = LensColor.red;
		if(Input.GetKeyDown(KeyCode.Alpha2) && hasBlueLens) lens = LensColor.blue;
		if(Input.GetKeyDown(KeyCode.Alpha3) && hasYellowLens) lens = LensColor.yellow;
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
