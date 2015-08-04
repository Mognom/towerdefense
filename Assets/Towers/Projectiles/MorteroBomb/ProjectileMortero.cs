using UnityEngine;
using System.Collections;

public class ProjectileMortero : Projectile {

	// Use this for initialization
	private Vector2 destino;
	private Vector3 subida;

	//Malditos tiros parabolicos
	private float time;
	private float y0;

	void Start () {
	}

	// Update is called once per frame
	void Update () {

		Vector2 posXZ;
		float posY;
		float step = speed * Time.deltaTime;
		time += Time.deltaTime;
		//x = x0 + v0*t + 1/2 * g *t --> posicion lanzamiento vertical
		posY = y0 + speed * time - 0.5f * Physics.gravity.magnitude * time * time;

		posXZ = Vector2.MoveTowards (new Vector2(transform.position.x, transform.position.z), new Vector2(objective.transform.position.x, objective.transform.position.z), step);

		//Avanza siguiendo la parabola planteada
		transform.position = new Vector3 (posXZ.x, posY, posXZ.y);
		//transform.position = Vector3.MoveTowards (transform.position, destino, step);
		
	}
	
	public override void setObjective(GameObject o){
		objective = o;
		time = 0;
		y0 = transform.position.y;
		destino = new Vector2 (o.transform.position.x, o.transform.position.z);

	}

	//KABOOOOOM
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyAI>().damaged(damage);
			//this.gameObject.recycle();
		}
		
	}
}