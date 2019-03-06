using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesMenu : MonoBehaviour {

	public Canvas livesCanvas;
	void Awake()
	{
		gameObject.SetActive (true);
	}
	void Start () {
		livesCanvas = gameObject.GetComponent<Canvas> ();
		livesCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
