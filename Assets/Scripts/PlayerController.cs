using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public float acceleration;
	public float jumpForce;

	private Animator _animator;
	private bool _jump;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			_jump = true;
		}	
	}

	void FixedUpdate() {
		int h = 0;
		if (Input.GetKey(KeyCode.LeftArrow)) {
			h = -1;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			h = 1;
		}

		rigidbody2D.AddForce(Vector2.right * h * acceleration);

		if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed) {
			rigidbody2D.velocity = new Vector2(maxSpeed * Mathf.Sign(rigidbody2D.velocity.x), rigidbody2D.velocity.y);
		}

		_animator.SetFloat("Speed", Mathf.Abs(h));

		if (_jump) {
			rigidbody2D.AddForce(Vector2.up * jumpForce);

			_animator.SetTrigger("Jump");

			_jump = false;
		}

	}
}
