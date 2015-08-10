using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Cadaver : MonoBehaviour {



	private GameObject levelManager;
	private SpawnManager spawnM;
	private AudioSource muerte;

	// Se llama una unica vez al ser creado, 'cacheo' las busquedas
	void Awake () {
		//this.transform.Rotate (new Vector3 (90, 90));
		levelManager = GameObject.Find ("LevelManager");
		spawnM = levelManager.GetComponent<SpawnManager> ();
		muerte = this.GetComponentInParent<AudioSource> ();
	}

	//Se llama cada vez que se usa desde la pool
	void OnEnable(){
		spawnM.saMorio();
		muerte.Play ();
		Invoke ("destructor", 2f); //Desctructor llamado a los 2 segundos para que de tiempo a terminar todo
	}

	//Recicla el cadaver
	void destructor(){
		this.gameObject.recycle();
	}
}
