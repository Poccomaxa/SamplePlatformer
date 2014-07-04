using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	public float snapDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 distance = (player.transform.position - this.transform.position);
		if (distance.magnitude > snapDistance) {
			distance = distance * ((distance.magnitude - snapDistance) / distance.magnitude);
			transform.position = transform.position + (Vector3)distance;
		}
	
	}
}
