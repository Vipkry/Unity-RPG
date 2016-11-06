using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

	public GameObject cursor;
	public Transform []  options;
	public bool paused;
	public GameObject menuStuff;
	private int atual;



	// Use this for initialization
	void Start () {
		atual = 0;
	}



	// Update is called once per frame
	void Update () {
		if (paused) {
			if (Input.GetKeyDown ("up")) {
				Vector3 aux = cursor.transform.position;
				//atual--;
				if (atual == 0)
					atual = options.Length - 1;
				else
					atual--;
				aux.y = options [atual].position.y;
				cursor.transform.position = aux;
			} else if (Input.GetKeyDown ("down")) {
				Vector3 aux = cursor.transform.position;
				if (atual == options.Length - 1)
					atual = 0;
				else
					atual++;
				aux.y = options [atual].position.y;
				cursor.transform.position = aux;
			}	

		}
	}

	public bool isPaused(){
		return paused; 
	}

	public void pause(){
		paused = true;
		menuStuff.SetActive (true);
		Time.timeScale = 0;
	}

	public void unpause(){
		paused = false;
		menuStuff.SetActive (false);
		Time.timeScale = 1;
	}
}
