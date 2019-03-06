using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireScript : MonoBehaviour {

	public GameObject misileFire;
	private float lastTime;
	public float firefrequency = 1.0f;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space") && Time.time > (lastTime + firefrequency))
		{	
			lastTime = Time.time;
			GameController.numBullets -= 1;
			if (GameController.numBullets > 0) {	
				Instantiate (misileFire, transform.position, transform.rotation);
			} else 
			{
				GameController.hasLost = true;
				GameController.numBullets = 0;
			}

		}
		
	}
}
