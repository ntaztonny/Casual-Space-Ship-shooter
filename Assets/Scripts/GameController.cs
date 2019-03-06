using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameController : MonoBehaviour {

	// Use this for initialization
	public static int Lives;
	public static int numBullets;
	public static int score;
	public Slider healthIndicator;
	public Slider bulletsIndicator;
	public Text livesText;
	public Text bulletsText;
	public Text scoreValue;
	public Text LevelText;
	public static int levelValue;
	public static int numEnemies;
	public static bool hasWon;
	public static bool hasLost;
	public GameObject [] enemy = new GameObject [2];
	AudioSource fewBullets;
	public GameObject player;
	public bulletsMenu bulletsmenu;
	public livesMenu livesmenu;
	public GameWinMenu gamewinmenu;

		  
	void Awake () {
		levelValue = 0;
		Lives = 2;
		score = 0;
		numBullets = 6;
		numEnemies = 0;
		hasWon = false;
		hasLost = false;
		Instantiate (player, new Vector3 (0.76f, -0.57f, 3.31f), transform.rotation);
		fewBullets = gameObject.GetComponent<AudioSource> ();
		fewBullets.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		healthIndicator.value = Lives;
		bulletsIndicator.value = numBullets;
		livesText.text = "Lives: " + Lives.ToString ();
		bulletsText.text = "Bullets: " + numBullets.ToString();
		scoreValue.text = "Score:        " + score.ToString ();
		LevelText.text = "Level: " + levelValue.ToString ();

		if (numEnemies == 0 && (hasWon == false))
		 {	
			Lives += 1;
			level ();
		}

		if (numBullets > 0 && numBullets < 4) {
			fewBullets.enabled = true;
			//bulletsIndicator.fill
		} else
			fewBullets.enabled = false;

		if (hasLost)
			Invoke ("gameOver", 2);
		if (hasWon)
			Invoke ("youWon", 2);

	}

	void level()
	{	
		
		 levelValue +=1;
		 
		if (levelValue == 1) 
		{	
			Debug.Log ("level 1");
			numEnemies = 5;
			numBullets = 6;
			bulletsIndicator.maxValue = 6;
			Instantiate (enemy[0], new Vector3(-5.15f, 3.28f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(-4.074f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(-2.23f, 3.28f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(-0.765f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(0.86f, 3.23f, 0.0f), Quaternion.Euler(-180,0,0));

		} 
		else if (levelValue == 2) 
		{	Debug.Log ("level 2");
			score += 50;
			numEnemies = 6;
			numBullets = 7;
			bulletsIndicator.maxValue = 7;
			Instantiate (enemy[0], new Vector3(-5.15f, 3.28f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(-4.074f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(-2.23f, 3.28f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(-0.765f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(0.86f, 3.23f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(2.4f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));

		}
		else if (levelValue == 3) 
		{	Debug.Log ("level 3");
			numEnemies = 7;
			score += 100;
			numBullets = 8;
			bulletsIndicator.maxValue = 8;
			Instantiate (enemy[0], new Vector3(-5.15f, 3.28f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(-4.074f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(-2.23f, 3.28f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(-0.765f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(0.86f, 3.23f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[1], new Vector3(2.4f, 2.04f, 0.0f), Quaternion.Euler(-180,0,0));
			Instantiate (enemy[0], new Vector3(3.8f, 3.23f, 0.0f), Quaternion.Euler(-180,0,0));
		} 

		else if(levelValue > 3)
		{	score += 200;
			levelValue = 3;
			hasWon = true;
			hasLost = false;
			//SceneManager.LoadScene ();
		}
	}

	public void playerReset()
	{
		Invoke ("Reset", 3.0f);
	}


	void Reset()
	{

		if (levelValue == 1)
			GameController.numBullets = 6;
		else if (levelValue == 2)
			GameController.numBullets = 7;
		else if (levelValue == 3)
			GameController.numBullets = 8;
			
		Instantiate (player, new Vector3 (0.76f, -0.57f, 3.31f), transform.rotation);
	}

	void gameOver()
	{	
		//EditorApplication.isPaused = true;
		Debug.Log ("You lost the game");
		if (numBullets == 0) {
			Debug.Log ("You ran out of bullets and couldn't defeat the enemy! Learn how to properly use your resources!");
			bulletsmenu.bulletsCanvas.enabled = true;

		}

		if (Lives == 0 && !bulletsmenu.bulletsCanvas.enabled)
		{
			Debug.Log ("You ran out of chances! Use your chances wisely!");
			livesmenu.livesCanvas.enabled = true;
		}
			
	}

	void youWon()
	{	
		EditorApplication.isPaused = true;
		Debug.Log ("Bravo!, You Won the game");
		gamewinmenu.gameWinCanvas.enabled = true;
	}


}
