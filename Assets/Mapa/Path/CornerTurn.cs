using UnityEngine;
using System.Collections;

public class CornerTurn : MonoBehaviour {

	// Use this for initialization

	private int direction = 1; // 1 = 90; -1 = -90

	//Cambia la direccion de movimiento de los npcs
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag != "Enemy")
			return;
		Vector3 actual = other.attachedRigidbody.velocity;
		other.attachedRigidbody.velocity = new Vector3 (actual.z *direction, 0, actual.x * direction * -1);

	}

	//Configura el giro a 90 o -90 grados
	public void setDirection (int dir){
		direction = dir;


	}
}
