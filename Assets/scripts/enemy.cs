using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	[SerializeField] float speed = 0.5f;
	Rigidbody2D enemyBody;

	Animator animator;

	bool isDead = false;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isDead) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}	
	}

	void OnTriggerEnter2D(Collider2D col) {
		switch(col.gameObject.name) {
			case "rocket":
				animator.SetBool("isDying", true);
				isDead = true;
				break;
			case "crate":
				break;
		}
	}
}
