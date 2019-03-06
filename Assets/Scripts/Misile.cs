using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misile : MonoBehaviour {
	public float misileSpeed = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f, misileSpeed*Time.deltaTime, 0.0f);
		if (transform.position.y > 6.5f)
		{
			Destroy (gameObject);
		}
	}
}
