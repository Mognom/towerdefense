using UnityEngine;
using System.Collections;

public class projectileArrow : Projectile {//Projectile {
	
	// Use this for initialization
	private int i =0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		i++;
		if(i == 200);
			//Destroy (this.gameObject);

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, objective.transform.position, step);

	}
	
	public override void setObjective(GameObject o){
		objective = o;
		
		Rigidbody rb = this.GetComponent<Rigidbody> ();
		
		Vector3 dir = (o.transform.position - transform.position).normalized;
		
	//	rb.velocity = dir * speed;
		
		print ("Fijado");
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}

	}
}