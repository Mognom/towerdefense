using UnityEngine;
using System.Collections;

public class TowerTargetBehaviour : MonoBehaviour {
	
	//Detection
	public string enemiesTag = "Enemy";
	public float range = 6;
	
	//Attack speed
	public float attackSecCD = 2;
	private float elapsedCD;
	
	//Projectile
	private GameObject target;
	private Vector2 pos;
	public GameObject projectile;
	private GameObject actual;
	
	
	//Inicializa cosas para no tener que hacerlo siempre e_e
	void Start () {
		pos = new Vector2(transform.position.x,transform.position.z);
		elapsedCD = attackSecCD;
	}
	
	// Update is called once per frame
	void Update () {
		//Search for a new target
		if (target == null) 
			target = findClosest ();
		
		//Pierde el objetivo -> Busca uno nuevo
		else if (Vector2.Distance (new Vector2 (target.transform.position.x, target.transform.position.z), pos) > range) {
			target.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 1);
			target = findClosest ();
		}
		//No pierde el objetivo -> Ataca
		else {
			//Comprueba si puede atacar
			if(elapsedCD >= attackSecCD){
				//Crea el projectil asociado al tipo de torre y le da su objetivo
				actual = (GameObject) Instantiate(projectile,transform.position+ new Vector3(0,1,0), projectile.transform.rotation);
				actual.GetComponent<Projectile>().setObjective(target);
				//Empieza el CoolDown
				elapsedCD = 0;
			}
			
			//Rayas de objetivo por los loles debugger
			Debug.DrawLine(target.transform.position, transform.position + new Vector3(0,1,0));
		}
		
		//Refresh attack
		if(elapsedCD < attackSecCD)
			elapsedCD += Time.deltaTime;
	}
	
	
	
	
	private GameObject findClosest(){
		GameObject result = null;
		GameObject[] list = GameObject.FindGameObjectsWithTag (enemiesTag);
		
		double distancia;
		double menorActual = range+1;
		
		
		foreach (GameObject enemy in list) {
			distancia = Vector2.Distance(new Vector2(enemy.transform.position.x,enemy.transform.position.z), pos);
			if( distancia <= range && distancia < menorActual){
				result = enemy;
				menorActual = distancia;
			}
		}
		return result;
	}
}