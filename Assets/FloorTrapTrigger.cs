using UnityEngine;
using System.Collections;

public class FloorTrapTrigger : MonoBehaviour {

	public LayerMask whatIsPlayer;
	public Transform initialPosition;
	public Transform finalPosition;
	public GameObject shootPreFab;
	public int interval;
	private int actualInterval;
	private SpriteRenderer spriteRenderer;
	public float forceShoot;
	private bool triggered;
	private float deltaHeight;
	private float extentY;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		actualInterval = interval;
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
			if (actualInterval >= interval){
				
				actualInterval = 0;
				Vector2 dir = finalPosition.position - initialPosition.position;
				GameObject projectile = (GameObject)Instantiate (shootPreFab);
				Vector3 aux = initialPosition.position;
				aux.x -= 0.2f;
				projectile.transform.position = aux;

				Rigidbody2D shootRigidibody = projectile.GetComponent<Rigidbody2D> ();
				// Condições para evitar erro de alinhamento (tais como verticais ou horizontais)
				dir.x = (Mathf.Abs(dir.x) > 0.01f) ? dir.x * forceShoot : 0;
				dir.y = (Mathf.Abs(dir.y) > 0.01f) ? dir.y * forceShoot : 0;
				shootRigidibody.velocity = dir;	
				Debug.Log (dir);
			}
			actualInterval++;
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
				Debug.Log ("TRIGGERED");
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
