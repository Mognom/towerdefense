using UnityEngine;
using System.Collections;

public class CornerTurn : MonoBehaviour {

	// Use this for initialization

	private int direction = 1; // 1 = 90; -1 = -90
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		//Destroy (other.gameObject);
		Vector3 actual = other.attachedRigidbody.velocity;
		print (actual.ToString());
		other.attachedRigidbody.velocity = Vector3.zero;
		//other.attachedRigidbody.AddForce(new Vector3 (0, 0, 1));

		
	}

	public void setDirection (int dir){
		direction = dir;


	}
}
