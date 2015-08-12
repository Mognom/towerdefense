using UnityEngine;
using System.Collections;

public class cameraMov : MonoBehaviour {

	//Variables a asignar al script al darselo a un objeto
	public int boundary = 50;
	public int movSpeed = 5;

	private int width, height;

	//Obtiene las dimensiones de la pantalla utilizada
	void Start () {
		width = Screen.width;
		height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = Input.mousePosition;

		if(pos.x > width - boundary)
			transform.position += Vector3.right * movSpeed * Time.unscaledDeltaTime;

		if(pos.x < boundary)
			transform.position += Vector3.left * movSpeed * Time.unscaledDeltaTime;

		if(pos.y > height - boundary)
			transform.position += Vector3.forward * movSpeed * Time.unscaledDeltaTime;

		if(pos.y < boundary)
			transform.position += Vector3.back * movSpeed * Time.unscaledDeltaTime;



	}
}
