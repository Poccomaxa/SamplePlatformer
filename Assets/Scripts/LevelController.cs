using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public TextMesh gameWinLabel;
	public BoxCollider2D winCollider;

	// Use this for initialization
	void Start () {
		GameManager.currentLevel = this;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
