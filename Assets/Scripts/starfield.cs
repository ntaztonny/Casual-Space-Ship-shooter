using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfield : MonoBehaviour {

	Renderer planeRenderer;
	public float scrollSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		planeRenderer = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		float offSet = Time.time * scrollSpeed;
		planeRenderer.material.mainTextureOffset = new Vector2 (3.0f, offSet);
		
	}
}
