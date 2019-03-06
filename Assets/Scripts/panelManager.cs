using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
	using UnityEditor;
#endif

public class panelManager : MonoBehaviour {


	// Use this for initialization

	Canvas settingsCanvas;

	void Start () {

		settingsCanvas = gameObject.GetComponent<Canvas> ();
		settingsCanvas.enabled = false;
	}  
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			gamePause();
		}
	}

	public void gamePause()
	{
		settingsCanvas.enabled = !settingsCanvas.enabled;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void quit()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif

	}

	public void restart()
	{
		//SceneManager.LoadScene ();
	}

	public void gameStart()
	{
		SceneManager.LoadScene ("Welcome");

	}

	public void playGame()
	{
		Invoke ("callGameStart", 2);
	}

	void callGameStart()
	{
		SceneManager.LoadScene("GamePlay");
	}

}
