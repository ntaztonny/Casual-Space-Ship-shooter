using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballAndEnemyCollision : MonoBehaviour {

	// Use this for initialization
	public GameObject Enemyexplosion;
	public GameObject Recharge;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyMisile")
		{
			if (col.gameObject.tag == "Enemy") 
			{	
				GameController.score += 50;
				Instantiate (Enemyexplosion, col.transform.position, transform.rotation) ;
				Instantiate (Recharge, col.transform.position, Quaternion.Euler(90,0,0)) ;
				GameController.numEnemies -= 1;
			}
			
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}
}
