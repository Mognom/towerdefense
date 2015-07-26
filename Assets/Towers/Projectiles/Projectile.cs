using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

	// Use this for initialization
	protected GameObject objective;
	public float speed;

	void Start (){}
	
	// Update is called once per frame
	void Update (){}

	public abstract void setObjective(GameObject o);
}
