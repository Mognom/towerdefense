using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	private Rigidbody rb;
	private Collider col;
	private int i = 0;
	public int speed;
	void Start () {
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider> ();
		rb.velocity = new Vector3 (speed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(col.enabled == false)
			i++;
		if (i > 200){
			print ("enabled");
			i = 0;
			col.enabled = true;
		}
	}
}
