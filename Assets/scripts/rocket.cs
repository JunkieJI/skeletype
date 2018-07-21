using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

	[SerializeField] float speed = -0.5f;


	// Use this for initialization
	void Start () {
		Debug.Log("start rocket");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime);		
	}

	void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("OnTriggerEnter2D");
	}
}
