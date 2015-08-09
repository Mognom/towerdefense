using UnityEngine;
using System.Collections;

public class TowerTargetBehaviour : MonoBehaviour {
	
	//Detection
	public string enemiesTag = "Enemy";
	public float range = 6;
	public int damage;
	
	//Attack speed
	public float attackSecCD = 2;
	private float elapsedCD;
	
	//Projectile
	private GameObject target;
	private Vector2 pos;
	public GameObject projectile;
	private GameObject actual;

	//Attack range
	private Projector projector;
	
	
	//Inicializa cosas para no tener que hacerlo siempre e_e
	void Start () {
		pos = new Vector2(transform.position.x,transform.position.z);
		elapsedCD = attackSecCD;

		//Display del area de ataque
		projector = this.GetComponentInChildren<Projector> ();
		projector.enabled = false;
		projector.orthographicSize = range;
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
				actual = projectile.spawn(transform.position+ new Vector3(0,1,0));
				Projectile pro = actual.GetComponent<Projectile>();
				pro.setObjective(target);
				pro.setDamage(damage);
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

	//Encuentra el enemigo mas cercano dentro del rango de ataque y lo elige como objetivo.
	private GameObject findClosest(){
		GameObject result = null;
		//Obtiene una lista de los enemigos actuales
		GameObject[] list = GameObject.FindGameObjectsWithTag (enemiesTag);
		double distancia;
		double menorActual = range+1;
	
		//Busca el enemigo mas cercano dentro del rango
		foreach (GameObject enemy in list) {
			distancia = Vector2.Distance(new Vector2(enemy.transform.position.x,enemy.transform.position.z), pos);
			if( distancia <= range && distancia < menorActual){
				result = enemy;
				menorActual = distancia;
			}
		}
		//Devuelve el enemigo mas cercano o null si ninguno cumple las condiciones
		return result;
	}
	
	//Enciende y apaga el proyector del area de ataque al poner el raton encima
	void OnMouseEnter () {
		projector.enabled = true;
	}
	void OnMouseExit(){
		projector.enabled = false;
	}

	//Getter de target (usado para el aim de la ballesta)
	public GameObject getTarget(){
		return target;
	}




}