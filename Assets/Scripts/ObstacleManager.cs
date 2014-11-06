using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

	private GameManager gameManager;
	
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Transform child in this.transform){//check if obstacle has the same color as lens color
			Obstacle childObstacle = child.GetComponent<Obstacle>();
			if(childObstacle.color == gameManager.lens) child.gameObject.SetActive(false);
			else child.gameObject.SetActive(true);
		}
		
	}
}
