using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rechargePlayer : MonoBehaviour {
	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate (0,0,speed*Time.deltaTime);
		if (transform.position.y < -3.0f)
		{
			Destroy (gameObject);
		}

	}
}
