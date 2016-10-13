using UnityEngine;
using System.Collections;

public class FloorTrapTrigger : MonoBehaviour {

	public LayerMask whatIsPlayer;
	public Transform initialPosition;
	public Transform finalPosition;
	public GameObject shootPreFab;
	private SpriteRenderer spriteRenderer;
	public float forceShoot;
	private bool triggered;
	private int interval;
	private float deltaHeight;
	private float extentY;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		interval = 7;
		extentY = spriteRenderer.bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Check if player stepped on the trap

		if (Physics2D.Raycast(new Vector2 (transform.position.x - spriteRenderer.bounds.extents.x, transform.position.y + deltaHeight), Vector2.right, spriteRenderer.bounds.extents.x * 2, whatIsPlayer.value)){
			
			// Activate trap
				// Summon laser prefab
				// add velocity
				// direction = finalPosition - initialPosition
			if (interval >= 6){
				interval = 0;
				Vector2 dir = finalPosition.position - initialPosition.position;
				GameObject projectile = (GameObject)Instantiate (shootPreFab);
				Rigidbody2D shootRigidibody = projectile.GetComponent<Rigidbody2D> ();
				shootRigidibody.velocity = dir * forceShoot;	
			}
			interval++;
			// "Triggered animation"
			if (!triggered){
				triggered = true;
				Vector3 aux = transform.position;
				aux.y -= extentY;
				transform.position = aux;	
			}

		}else {
			if (triggered){
				Vector3 aux = transform.position;
				aux.y += extentY;
				transform.position = aux;
			}

			triggered = false;
		}

		if (!triggered){
			deltaHeight = 0;
		}else {
			deltaHeight = extentY;
		}

	}
}
