using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class rocket : MonoBehaviour {

	[SerializeField] float speed = -0.5f;

	public bool correctFiringSequence = false;

	Animator animator;
	BoxCollider2D boxCollider2D;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		boxCollider2D = GetComponent<BoxCollider2D>();
		boxCollider2D.enabled = false; // disable box collider so that zombie doesn't die when no rocket launched
	}
	
	// Update is called once per frame
	void Update () {
		ProcessFiring();
		if (correctFiringSequence) {
			transform.Translate(Vector2.right * speed * Time.deltaTime);		
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		switch(col.gameObject.name) {
			case "zombie":
				Destroy(gameObject);
				break;
		}
	}

	private void ProcessFiring() {
		if(CrossPlatformInputManager.GetButton("Fire")) {
			boxCollider2D.enabled = true; // reenable box collider since rocket is launched
			correctFiringSequence = true;
			animator.SetBool("fireRocket", true);
		}
	}
}
