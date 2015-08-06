using UnityEngine;
using System.Collections;

public class projectileBallesta : Projectile {

	// Use this for initialization
	private Vector3 destino;
	
	// Update is called once per frame
	void Update () {
		if (transform.position.Equals(destino)) {
			this.gameObject.recycle();
			return;
		}
		
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, destino, step);
		
	}
	
	public override void setObjective(GameObject o){
		objective = o;
		Vector3 dir = (o.transform.position - transform.position).normalized;
		print (dir.ToString());

		transform.LookAt (o.transform.position);
		destino = dir * 6 + transform.position;//o.transform.position;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyAI>().damaged(damage);
			//this.gameObject.recycle();
		}
		
	}
}
