using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

	public GameObject tiroPreFab;
	public float forceShoot;
	public float LASER_SHOOT_POSITION_Z;

	public void atira(){
		GameObject tiro = GameObject.Instantiate (tiroPreFab);
		Vector3 aux = new Vector3 (transform.position.x, transform.position.y, LASER_SHOOT_POSITION_Z);
		aux.x += 0.35f * (transform.localScale.x / Mathf.Abs(transform.localScale.x));
		tiro.transform.position = aux;

		Rigidbody2D shootRigidibody = tiro.GetComponent<Rigidbody2D> ();
		// Condições para evitar erro de alinhamento (tais como verticais ou horizontais)
		Vector2 dir = Vector2.right;
		dir.x *= (transform.localScale.x / Mathf.Abs (transform.localScale.x));
		shootRigidibody.velocity = forceShoot * dir;	

	}
}
