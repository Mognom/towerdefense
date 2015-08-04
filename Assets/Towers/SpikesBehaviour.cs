using UnityEngine;
using System.Collections.Generic;

public class SpikesBehaviour : MonoBehaviour {

	public int damage = 1;
	public float attackSecCD = 2;

	private float elapsedCD = 0;

	//Lista de los objetivos que se encuentran sobre los pinchos
	private List<EnemyAI> targets;


	void Start () {
		targets = new List<EnemyAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Si es el momento ataca
		if (targets.Count > 0 && elapsedCD >= attackSecCD) {
			for(int i = 0; i< targets.Count; i++){
				if(targets[i] == null)
					targets.Remove(targets[i--]);
				else
					targets[i].damaged(damage);
			}
			elapsedCD = 0;
		}
		//Refresh attack
		if(elapsedCD < attackSecCD)
			elapsedCD += Time.deltaTime;
	}


	//Añade o quita de la lista de objetivos segun entran o salen del area que cubre los pinchos
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy")
			targets.Add (other.gameObject.GetComponent<EnemyAI>());
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Enemy")
			targets.Remove (other.gameObject.GetComponent<EnemyAI>());
		
	}
}
