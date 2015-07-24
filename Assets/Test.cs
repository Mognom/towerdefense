using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
