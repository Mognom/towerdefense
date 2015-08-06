using UnityEngine;
using System.Collections;

public class ProjectileMortero : Projectile {
	

	//Malditos tiros parabolicos

	private Vector3 etapa;
	private bool subiendo;
	private bool boom= false;
	private float actualY;

	//Limpia las variables para el siguiente proyectil
	void OnEnable(){
		subiendo = false;
		boom = false;
	}

	void OnDisable(){


	}

	// Update is called once per frame
	void Update () {
		if (subiendo) {
			transform.position = Vector3.MoveTowards (transform.position, etapa, speed * Time.deltaTime);
			if (transform.position.Equals (etapa)){
				subiendo = false;
				actualY = transform.position.y;
			}
		}
		else {
			if (objective == null || boom){
				this.gameObject.recycle();
				return;
			}
			Vector3 pos = objective.transform.position;
			actualY -= speed * Time.deltaTime;
			transform.position = new Vector3 (pos.x,actualY, pos.z);
		}
	}
	
	public override void setObjective(GameObject o){
		objective = o;
		etapa = transform.position + Vector3.up * 6;
		subiendo = true;
	}

	//KABOOOOOM
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyAI>().damaged(damage);
			boom = true;
		}
	}
}