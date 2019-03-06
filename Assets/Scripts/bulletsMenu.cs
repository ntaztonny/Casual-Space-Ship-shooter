using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsMenu : MonoBehaviour {

	public Canvas bulletsCanvas;
	void Awake()
	{
		gameObject.SetActive(true);
	}

	void Start () {
		bulletsCanvas = gameObject.GetComponent<Canvas> ();
		bulletsCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
