using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fort : MonoBehaviour {

	[SerializeField] int healthPoints = 1;
	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;


	ParticleSystem explosion;

	float explosion1PositionOffset = 0.9f;
	float explosion2PositionOffset = -2.3f;
	float explosion3PositionOffset = -5.5f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("OnTriggerEnter2D fort " + col);
		switch(col.gameObject.name) {
			case "zombie":
				Invoke("KillFort", 1f);
				break;
		}
	}

	private void KillFort() {
		SendToRuntimeHandler(Instantiate(deathFX, calcExplosionPosition(explosion1PositionOffset), Quaternion.identity));
		SendToRuntimeHandler(Instantiate(deathFX, calcExplosionPosition(explosion2PositionOffset), Quaternion.identity));
		SendToRuntimeHandler(Instantiate(deathFX, calcExplosionPosition(explosion3PositionOffset), Quaternion.identity));		
		// Destroy(gameObject);
	}

	private Vector3 calcExplosionPosition(float explosionPositionOffset) {
		Vector3 newPosition = new Vector3(transform.position.x + explosionPositionOffset, transform.position.y, transform.position.z); 
		return newPosition;
	}

	private void SendToRuntimeHandler(GameObject fx) {
		fx.transform.parent = parent;

	}
}
