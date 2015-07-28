using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public int speed;
	public int maxHP;

	private GameObject m_Camera;
	private int HP;
	private Transform healthBar;
	private Transform canvas;

	void Start () {
		HP = maxHP;
		canvas = transform.FindChild ("CanvasHealthBar");
		healthBar = canvas.FindChild ("HealthBar");
		m_Camera = GameObject.FindGameObjectWithTag ("MainCamera");

		this.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0, 0);

		updateHealthBar ();
	}

	//Evento que salta cuando es dañado 
	public void damaged(int damage){
		//Calcula el daño y en caso de morir pues muere
		HP -= damage;
		if (HP < 0) {
			Destroy (this.gameObject);
			return;
		}

		//Actualiza la barra de vida
		updateHealthBar ();

	}

	//Actualiza la barra de vida para reflejar la vida restante tras ser dañado
	private void updateHealthBar(){
		float health = (float)HP / maxHP;
		print (health);
		healthBar.localScale = new Vector3(health,healthBar.localScale.y , healthBar.localScale.z);

	}

	//Cuando rota tiene que actualizarse la barra de vida para que mire a la camara
	public void turn(){
		canvas.LookAt(canvas.position + m_Camera.transform.rotation * Vector3.back,m_Camera.transform.rotation * Vector3.up);

	}
}
