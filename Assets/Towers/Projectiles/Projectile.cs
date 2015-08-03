using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	// Use this for initialization
	protected GameObject objective;
	protected int damage;
	public float speed;

	void Start (){}
	
	// Update is called once per frame
	void Update (){}

	public abstract void setObjective(GameObject o);

	public void setDamage(int dmg){
		damage = dmg;

	}
}
