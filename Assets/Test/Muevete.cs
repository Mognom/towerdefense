using UnityEngine;
using System.Collections;

public class Muevete : MonoBehaviour {

	// Use this for initializationç
	public int speed;
	void Start () {
		this.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
