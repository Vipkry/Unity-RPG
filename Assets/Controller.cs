using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public menuController menuController;
	private Tiro playerTiro;

	// Use this for initialization
	void Start () {
		playerTiro = gameObject.GetComponent<Tiro> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			playerTiro.atira();
		}
		if (Input.GetKeyDown("escape")){
			if (!menuController.isPaused()) {
				menuController.pause (); 
			}else {
				menuController.unpause ();
			}
		}
	}
}
