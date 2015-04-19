using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float maxSpeed;
	public float Speed= 10f;
	public float jump=3f;
	public bool Grounded;

	//Player property
	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", Grounded);
		anim.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
		//Set mirror character
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale=new Vector3(-0.2f,0.2f,1f);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale=new Vector3(0.2f,0.2f,1f);
		}
	}

	//Called per tick
	void FixedUpdate(){
		//gerak kiri kanan
		float h = Input.GetAxis("Horizontal");
		rb2d.AddForce ((Vector2.right * Speed) * h);
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed,rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed,rb2d.velocity.y);
		}
		//gerak atas bawah

		rb2d.AddForce((Vector2.up * Speed) * Input.GetAxis("Vertical"));
	}
}
