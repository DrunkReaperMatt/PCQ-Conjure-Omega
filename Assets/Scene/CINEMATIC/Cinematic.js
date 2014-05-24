#pragma strict

var nbSlides = 6;
var compteur = 0;

var isPressed = false;

/*function Start () {


	//Destroy(GameObject.FindWithTag("s6"), timeBetween*6);
	//Debug.Log ("END");	
			
}*/

function Update (){
	if(Input.GetKeyUp(KeyCode.Space)) DestroyNextSlide();
}

function DestroyNextSlide(){
	
	Destroy(GameObject.FindWithTag("s" + (++compteur)));
	
	if(compteur == nbSlides) {
		Application.LoadLevel("Main");
	
	}
}
