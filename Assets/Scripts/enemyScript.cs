using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

	public GameObject enemyMisile;
	Vector3 initPos;

	public float enemyfireFrequency = 0;
	float lastTime;
	// Use this for initialization
	void Start () {
		initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.PingPong(Time.time, 5)+initPos.x, Mathf.Clamp ((Mathf.PingPong(Time.time, 1.0f)+initPos.y),2,3), transform.position.z);

		float randomFire = Random.Range (0.0f, 0.5f);
		if (Time.time > (lastTime + enemyfireFrequency)) 
		{
			lastTime = Time.time+randomFire;
			Instantiate (enemyMisile, transform.position, transform.rotation);
		}
	}
}
