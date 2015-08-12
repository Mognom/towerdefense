using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	// Use this for initialization
	public float time;

	//Despues de ser activado el objeto asociado, lo destruye al cabo de t tiempo
	void OnEnable () {
		Invoke ("destruir", time);
	}


	private void destruir (){
		this.gameObject.recycle ();

	}

}
