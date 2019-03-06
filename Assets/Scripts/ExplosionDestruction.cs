using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("Destroy", 30);
	}

	void DestroyExplosion()
	{
		Destroy (gameObject);
	}
}
