using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthController : MonoBehaviour {

	public int initialHealth;
	public Text texto;
	// Use this for initialization
	void Start () {
		texto.text = initialHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
