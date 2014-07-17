using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static LevelController currentLevel;
	public LevelController[] levels;
	public GameObject player;

	// Use this for initialization
	void Start () {
		currentLevel = (LevelController)Instantiate(levels[0]);
		GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<FollowPlayer>().player = (GameObject)Instantiate(player);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
