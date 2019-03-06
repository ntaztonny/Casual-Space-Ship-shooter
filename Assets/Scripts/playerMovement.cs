using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour {

	public float playerSpeed = 0.0f;
	public GameObject explosion;
	public GameController reference;
	public AudioSource BulletRecharge;
	GameObject  Control;
	public float freedomTime = 0.0f;
	public playerMovement script;
	// Use this for initialization

	void start()
	{	
		//Control = GameObject.FindWithTag ("Controller");
		script = gameObject.GetComponent<playerMovement>();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxisRaw("Horizontal")*Time.deltaTime*-playerSpeed, Input.GetAxisRaw("Vertical")*Time.deltaTime*playerSpeed, 0);
		transform.position = new Vector3 ( Mathf.Clamp(transform.position.x, -6.0f, 6.4f), Mathf.Clamp (transform.position.y, -3.0f, 3.0f), 0.0f);
		//transform.position.z = Mathf.Clamp (transform.position.z, -1.4f, 2.0f);

		if (GameController.numBullets == 0)
			script.enabled = false;

	}
	void OnTriggerEnter(Collider col)
	{	
		if (col.gameObject.tag == "Recharge") 
		{	
			BulletRecharge.Play ();
			GameController.score += 2;
			if ((GameController.levelValue == 1 && GameController.numBullets < 6) || (GameController.levelValue == 2 && GameController.numBullets < 7) || (GameController.levelValue == 3 && GameController.numBullets < 8)) 
			{	
				GameController.numBullets += 1;
			}
			Destroy (col.gameObject);
		} 
		if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyMisile")
		{		
			Instantiate (explosion, transform.position, transform.rotation) ;
			GameController.Lives -= 1;

			if (GameController.Lives > 0 && GameController.hasLost == false) {	
				reference.playerReset ();
			} else
				GameController.hasLost = true;
			
			Destroy(gameObject);
				

		}
	}


}
