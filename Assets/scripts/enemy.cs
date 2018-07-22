using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	[SerializeField] float speed = 0.5f;

	Rigidbody2D enemyBody;

	Animator animator;

	bool stopMovement = false;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!stopMovement) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}	
	}

	void OnTriggerEnter2D(Collider2D col) {
		switch(col.gameObject.name) {
			case "rocket":
				animator.SetBool("isDying", true);
				stopMovement = true;
				break;
			case "fort":
				Debug.Log("hit fort");
				animator.SetBool("atEnd", true);
				stopMovement = true;
				Invoke("KillEnemy", 1f);
				break;
		}
	}

	private void KillEnemy(){
		Destroy(gameObject);
	}
}
