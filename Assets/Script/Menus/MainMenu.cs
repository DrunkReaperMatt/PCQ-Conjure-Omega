using UnityEngine;
using System.Collections;

public enum enGameState
{
	MAIN_MENU,
	CONFIG_MENU,
	INGAME,
	PAUSED
};
 

public class MainMenu : MonoBehaviour {
	private enGameState CurrentGameState;
	private GameObject BtnResumeGame;
	private GameObject BtnStartNewGame;
	private GameObject panelMenuConfig;
	private GameObject panelMenuPrincipal;

	private const int X_POSITION_HORS_SCENE = -100000;
	private const int X_POSITION_CENTERED_SCENE = 0;


	
	// Use this for initialization
	void Start () {
		CurrentGameState = enGameState.MAIN_MENU;

		BtnStartNewGame = GameObject.Find ("buttonStartNewGame");
		BtnResumeGame 	= GameObject.Find ("buttonResumeGame");
		panelMenuConfig = GameObject.Find ("panelMenuConfig");
		panelMenuPrincipal= GameObject.Find ("panelMenuPrincipal");

		if (BtnResumeGame != null) {
			BtnResumeGame.transform.position = new Vector3 (X_POSITION_HORS_SCENE, BtnStartNewGame.transform.position.y, BtnStartNewGame.transform.position.z);
		}
		if (panelMenuConfig != null) {
			panelMenuConfig.transform.position = new Vector3 (X_POSITION_HORS_SCENE, panelMenuConfig.transform.position.y, panelMenuConfig.transform.position.z);
		}
	}

	void MenuNewGame_onClick(){
		Debug.Log ("MenuNewGame_onClick()");


		// Hide button newgame, replace with  Resume 

		//TODO: play evil sound()

		//TODO: optional load screen? 

		Application.LoadLevel ("scene");
		CurrentGameState = enGameState.INGAME;

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

		CurrentGameState = enGameState.CONFIG_MENU;

		if (panelMenuPrincipal != null) {
			panelMenuPrincipal.transform.position = new Vector3 (X_POSITION_HORS_SCENE, panelMenuPrincipal.transform.position.y, panelMenuPrincipal.transform.position.z);
		}

		//TODO:animation transition 
		if (panelMenuConfig != null) {
			panelMenuConfig.transform.position = new Vector3 (X_POSITION_CENTERED_SCENE, panelMenuConfig.transform.position.y, panelMenuConfig.transform.position.z);
		}

	
	
	}


	
	void MenuExit_onClick(){
		
		
		//TODO: demander confirmation 
		Application.Quit ();
	}



	void MenuConfigInput_onClick(){


	}

	void MenuConfigGraphic_onClick(){
	
	}

	
	void MenuRetourMainMenu_onClick(){

		CurrentGameState = enGameState.MAIN_MENU;

		if (panelMenuPrincipal != null) {
			panelMenuPrincipal.transform.position = new Vector3 (X_POSITION_CENTERED_SCENE, panelMenuPrincipal.transform.position.y, panelMenuPrincipal.transform.position.z);
		}
		
		//TODO:animation transition 
		if (panelMenuConfig != null) {
			panelMenuConfig.transform.position = new Vector3 (X_POSITION_HORS_SCENE, panelMenuConfig.transform.position.y, panelMenuConfig.transform.position.z);
		}
	} 



	
	// Update is called once per frame
	void Update () {
		//TODO: KEYMAPPING
		
		//Pause on escape
		if (Input.GetKeyDown (KeyCode.Escape)  && CurrentGameState == enGameState.INGAME ) {
			ChangeButtonStartResumeGame();
			PauseGameAndShowMainMenu();
		}
		else if (Input.GetKeyDown(KeyCode.Escape)  && CurrentGameState == enGameState.PAUSED )  {
			ButtonResume_onClick();
		}
		else if (Input.GetKeyDown(KeyCode.Escape)  && CurrentGameState == enGameState.CONFIG_MENU )  {
			MenuRetourMainMenu_onClick();
		}
		else if (Input.GetKeyDown(KeyCode.Escape)  && CurrentGameState == enGameState.MAIN_MENU )  {
			MenuExit_onClick();
		}

		
	}

	void MenuShowCredits_onClick() {

		Application.LoadLevel ("Credits");
	}



	void PauseGameAndShowMainMenu(){
	
		Time.timeScale = 0;
		CurrentGameState = enGameState.PAUSED;
	}
	
	void ButtonResume_onClick(){
		Time.timeScale = 1;
		CurrentGameState = enGameState.INGAME;
		
	}

}
