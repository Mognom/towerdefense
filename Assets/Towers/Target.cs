using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization
	public string enemiesTag;
	public double range;

	private GameObject target;
	private Vector2 pos;
	void Start () {
		pos = new Vector2(transform.position.x,transform.position.z);
		findClosest ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) 
			target = findClosest ();
		else if (Vector2.Distance (new Vector2 (target.transform.position.x, target.transform.position.z), pos) > range) {
			target.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 1);
			target = null;
		}
		else {
				print ("tiene objetivo");
				target.GetComponent<MeshRenderer> ().material.color = new Color (1, 0, 1, 1);

		}
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
