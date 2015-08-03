using UnityEngine;
using System.Collections;

public class BallestaLookTarget : MonoBehaviour {

	// Use this for initialization

	private TowerTargetBehaviour targetBehaviour;

	void Start () {
		targetBehaviour = this.gameObject.GetComponent<TowerTargetBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject target = targetBehaviour.getTarget ();
		if (target != null)
			transform.GetChild(1).transform.LookAt (target.transform);
	}
}
