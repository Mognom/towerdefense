using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Cadaver : MonoBehaviour {

	private GameObject gM;
	private SpawnManager spawnM;
	private GameManager gameM;
	private AudioSource muerte;

	// Use this for initialization
	void Start () {
		gM = GameObject.Find ("GameManager");
		spawnM = gM.GetComponent<SpawnManager> ();
		spawnM.saMorio();
		gameM = gM.GetComponent<GameManager> ();
		gameM.sumarOro (10);
		muerte = this.GetComponentInParent<AudioSource> ();
		muerte.Play ();
		Invoke ("destructor", 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void destructor(){
		Destroy (this.gameObject);
	}
}
