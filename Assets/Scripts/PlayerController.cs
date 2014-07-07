using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public float acceleration;
	public float jumpForce;

	private Animator _animator;
	private bool _jump;

	public GameObject groundCheck;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		bool grounded = false;
		if (Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"))) {
			grounded = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) {
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
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);

			_animator.SetTrigger("Jump");

			_jump = false;
		}

		if (transform.position.y < -20) {
			transform.position = new Vector2(0, 0);
		}
	}
}
