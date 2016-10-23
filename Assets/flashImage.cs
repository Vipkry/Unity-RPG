using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class flashImage : MonoBehaviour {


	public float duration;
	public int opacity; // between 0 and 255
	private Image image;
	private bool isFlashing;

	// Use this for initialization
	void Awake () {
		image = gameObject.GetComponent<Image> ();
		image.canvasRenderer.SetAlpha (0f);
	}

	public void Flash (){
		image.canvasRenderer.SetAlpha (1f);
		image.CrossFadeAlpha (0f, duration, false);
	}
}
