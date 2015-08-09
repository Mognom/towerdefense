using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Singleton powa
	private static GameManager instance;

	private int currentScene;

	void Start () {
		//SOLO PUEDE QUEDAR UNO
		if (instance == null) {
			instance = this;
			//No se destruye jamas de los jamases
			DontDestroyOnLoad (this.gameObject);

		}
		else
			Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void play(){
		print ("hola");
		currentScene = 1;
		Application.LoadLevel (1);
	}

	//Cierra el juego ?
	public void exit(){
		print ("Hola mundo");
		Application.Quit ();


	}

}
