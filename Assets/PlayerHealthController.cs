using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthController : MonoBehaviour {

	public int health;
	public Text texto;
	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate() {
		texto.text = health.ToString();
	}

	public bool takeDamage(int dmg){
		if (health > 0){
			health -= dmg;
			return true;
		}else {
			Application.LoadLevel("cena2");
			return false;
		}
	}
}
