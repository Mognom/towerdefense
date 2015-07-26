using UnityEngine;
using System.Collections;

public class projectileBehaviour : Projectile {//Projectile {

	// Use this for initialization

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void setObjective(GameObject o){
		objective = o;

		Rigidbody rb = this.GetComponent<Rigidbody> ();

		Vector3 dir = (o.transform.position - transform.position).normalized;

		rb.velocity = dir * speed;

		print ("Fijado");

	}
}
