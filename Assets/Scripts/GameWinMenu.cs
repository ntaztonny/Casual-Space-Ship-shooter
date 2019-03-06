using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinMenu : MonoBehaviour {

	public Canvas gameWinCanvas;
	void Awake()
	{
		gameObject.SetActive(true);
	}

	void Start () {
		gameWinCanvas = gameObject.GetComponent<Canvas> ();
		gameWinCanvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}
}
