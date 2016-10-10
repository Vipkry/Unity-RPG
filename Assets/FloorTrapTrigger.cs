using UnityEngine;
using System.Collections;

public class FloorTrapTrigger : MonoBehaviour {

	public LayerMask whatIsPlayer;
	private SpriteRenderer spriteRenderer;
	private bool triggered;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if player stepped on the trap
		if (!triggered && Physics2D.Raycast(new Vector2 (transform.position.x - spriteRenderer.bounds.extents.x, transform.position.y), Vector2.right, spriteRenderer.bounds.extents.x * 2)){
			triggered = true;
			// Activate trap
				// Summon laser prefab and add velocity
			// "Triggered"
			Vector3 aux = transform.position;
			aux.y -= spriteRenderer.bounds.extents.y;
			transform.position = aux;
		}

	}
}
