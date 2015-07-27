using UnityEngine;
using System.Collections;

public class projectileArrow : Projectile {//Projectile {
	
	// Use this for initialization
	private int i =0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (objective == null) {
			Destroy (this.gameObject);
			return;
		}

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, objective.transform.position, step);

	}
	
	public override void setObjective(GameObject o){
		objective = o;
		transform.LookAt (o.transform.position);

		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == objective) {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}

	}
}