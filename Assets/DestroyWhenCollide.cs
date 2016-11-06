using UnityEngine;
using System.Collections;

public class DestroyWhenCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// 10 is the player layer
		if (coll.gameObject.layer == 10){
			coll.gameObject.GetComponent<PlayerHealthController>().takeDamage(5);
			GameObject.Find ("DamageImage").GetComponent<flashImage> ().Flash ();
		}

		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "limiter") {
			Destroy (gameObject);
		}
	}
}
