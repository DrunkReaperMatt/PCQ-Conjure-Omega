using UnityEngine;
using System.Collections;

public enum enGameState
{
	NOTSTARTED,
	INGAME,
	PAUSED
};
 

public class MainMenu : MonoBehaviour {
	private enGameState CurrentGameState;
	private GameObject BtnResumeGame;
	private GameObject BtnStartNewGame;

	private const int X_POSITION_HORS_SCENE = -1000;
	private const int X_POSITION_CENTERED_SCENE = 0;


	
	// Use this for initialization
	void Start () {
		CurrentGameState = enGameState.NOTSTARTED;

		BtnStartNewGame = GameObject.Find ("buttonStartNewGame");
		BtnResumeGame 	= GameObject.Find ("buttonResumeGame");

		if (BtnResumeGame != null) {
			BtnResumeGame.transform.position = new Vector3 (X_POSITION_HORS_SCENE, BtnStartNewGame.transform.position.y, BtnStartNewGame.transform.position.z);
		}
	}

	void MenuNewGame_onClick(){
		Debug.Log ("MenuNewGame_onClick()");


		// Hide button newgame, replace with  Resume 

		//TODO: play evil sound()

		//TODO: optional load screen? 

		//Application.LoadLevel (1);

		ChangeButtonStartResumeGame();
	}

	private void ChangeButtonStartResumeGame(){


		if (BtnStartNewGame != null){
			BtnStartNewGame.transform.position = new Vector3(X_POSITION_HORS_SCENE, BtnStartNewGame.transform.position.y, BtnStartNewGame.transform.position.z);
		}
		if (BtnResumeGame != null) 	{
			BtnResumeGame.transform.position = new Vector3(X_POSITION_CENTERED_SCENE, BtnResumeGame.transform.position.y, BtnResumeGame.transform.position.z);
		}
	}

	void MenuLoadGame_onClick(){
		Debug.Log ("MenuLoadGame_onClick()");		
	}

	void MenuSaveGame_onClick(){
		Debug.Log ("MenuSaveGame_onClick()");
	}

	void MenuConfig_onClick(){
		Debug.Log ("MenuConfig_onClick()");		
	}

	void MenuExit_onClick(){


		//TODO: demander confirmation 
		Application.Quit ();
	}
	 



	
	// Update is called once per frame
	void Update () {
		//TODO: KEYMAPPING
		
		//Pause on escape
		if (Input.GetKeyDown (KeyCode.Escape)  && CurrentGameState == enGameState.INGAME ) {
			ButtonResumeGame_onClick();
		}
		else if (Input.GetKeyDown (KeyCode.Escape)  && CurrentGameState == enGameState.PAUSED )  {
			ButtonResume_onClick();
		}
		
	}

	void ButtonResumeGame_onClick(){
	
		Time.timeScale = 0;
		CurrentGameState = enGameState.PAUSED;
	}
	
	void ButtonResume_onClick(){
		Time.timeScale = 1;
		CurrentGameState = enGameState.INGAME;
		
	}

}
