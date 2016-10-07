using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	public float distGroundCheckDisc; // variável que bota uma discrepância horizontal pra checar se tá no chão
	public float distToGround; // variável pra saber a distancia até o chão do collider do personagem, usada para o raycast para checar se está no chão
	public float auxiliarDistance; // Distância auxiliar na hora do rayxast para ver o chão
	public LayerMask whatIsFloor;
	public float forceJump; 	// Força do pulo
	public float forceMove; // Velocidade do movimento horizontal
	public Rigidbody2D playerRigidbody;
	public BoxCollider2D playerBoxCollider;
	public Animator playerAnimator;

	private int counter;
	private bool jumpKeyIsDown; // Variável auxiliar pra impedir bugs ao segurar o 'space'
	private float axis;
	private bool hasJumped;
	private Vector2 beforeJumpVelocity; // Vetor auxiliar para manter o movimento durante o pulo

	// Use this for initialization
	void Start () {
		axis = 0;
		distToGround = playerBoxCollider.bounds.extents.y;
	}

	void Update () {
		playerAnimator.SetBool ("MovingHorizontal", false);
		if (axis != 0){
			Vector3 newScale = transform.localScale;
			newScale.x = Mathf.Abs(newScale.x);
			playerAnimator.SetBool ("MovingHorizontal", true);
			// Movimentos horizontais 
			if (axis > 0) {
				playerRigidbody.velocity = new Vector2 (forceMove, playerRigidbody.velocity.y);
				transform.localScale = newScale;
			} else if (axis < 0) {
				playerRigidbody.velocity = new Vector2 (-forceMove, playerRigidbody.velocity.y);
				newScale.x *= -1;
				transform.localScale = newScale;
			}
		}


		// Checa se está no chão. Se estiver, deixa pular, caso contrário, pula mantendo a velocidade de quando pulou.
		if (isGrounded ()) {
			if (!hasJumped){
				if (Input.GetKeyDown ("space")) {
					hasJumped = true;
					beforeJumpVelocity = playerRigidbody.velocity;
					beforeJumpVelocity.x *= 0.85f;
					jumpKeyIsDown = true;
					playerRigidbody.AddForce (new Vector2 (0, forceJump));
				}
			}else {
				if (counter >= 1){
					hasJumped = false;
					counter = 0;
				}else {
					counter++;	
				}

			}
		} else {
			if (hasJumped)
				playerRigidbody.velocity = new Vector2 (beforeJumpVelocity.x, playerRigidbody.velocity.y);	
			else {
				beforeJumpVelocity = playerRigidbody.velocity;
				playerRigidbody.velocity = new Vector2 (beforeJumpVelocity.x, playerRigidbody.velocity.y);
			}
		}
	}

	void FixedUpdate (){
		if (jumpKeyIsDown) {
			if (Input.GetKeyUp ("space"))
				jumpKeyIsDown = false;
		}

		playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x * 0.82f, playerRigidbody.velocity.y);
		axis = Input.GetAxis ("Horizontal");


	}

	bool isGrounded(){
		Vector3 aux = transform.position;
		Vector3 aux2 = transform.position;
		// Checa se o personagem olha pra direita ou pra esquerda, posiciona no pé do lado oposto
		// A segunda parte da conta "normaliza" o transform.localscale.x preservando o sinal
		aux.x += distGroundCheckDisc * (transform.localScale.x/Mathf.Abs(transform.localScale.x)) * -1;
		aux2.x += distGroundCheckDisc * (transform.localScale.x/Mathf.Abs(transform.localScale.x));

		// Not Grounded
		if (!Physics2D.Raycast (aux, -Vector2.up, distToGround + auxiliarDistance, whatIsFloor.value) && !Physics2D.Raycast (aux2, -Vector2.up, distToGround + auxiliarDistance, whatIsFloor.value)){
			if (playerRigidbody.velocity.y > 0){
				playerAnimator.SetInteger ("Jumping", 1);
			}else {
				playerAnimator.SetInteger ("Jumping", -1);
			}
			return false;
		}else {
			playerAnimator.SetInteger ("Jumping", 0);
			return true;
		}

	}

}



