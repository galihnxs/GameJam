using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	private Player player;
	// Use this for initialization
	void Start () {
		player = gameObject.GetComponentInParent<Player>();
	}
	//groundcheck collide with something
	void OnTriggerEnter2D(Collider2D col){
		player.Grounded = true;
	}
	void OnTriggerExit2D(Collider2D col){
		player.Grounded = false;
	}
}
