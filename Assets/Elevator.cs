using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public float speed;
	public Transform initialPosition;
	public Transform finalPosition;
	private Vector2 dir;

	// Use this for initialization
	void Start () {
		dir = finalPosition.position - initialPosition.position;
		speed = speed / 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 aux = transform.position;
		// Impedir precisão evitando erros
		aux.x = (dir.x > 0.1f) ? aux.x + (dir.x * speed) : aux.x;
		aux.y = (dir.y > 0.1f) ? aux.y + (dir.y * speed) : aux.y;
		transform.position = aux;
	}

	void OnTriggerEnter2D(Collider2D col){
		// Ifs para garantir que não vai colidir com o inital/final mais de uma vez
		if (speed > 0 && col.gameObject.tag == "finalTrigger"){
			speed *= -1;
		}else if (speed < 0 && col.gameObject.tag == "initialTrigger") {
			speed *= -1;
		}

	}
}
