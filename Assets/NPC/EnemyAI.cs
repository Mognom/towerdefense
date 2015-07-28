using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	public int speed;
	public int maxHP;

	public GameObject damagePopup;

	private GameObject m_Camera;
	private int HP;
	private Transform healthBar;
	private Transform canvas;

	void Start () {
		HP = maxHP;
		healthBar = transform.FindChild ("EnemyCanvas/HealthBG/HealthBar");
		//healthBar = transform.Find ("HealthBar");
		m_Camera = GameObject.FindGameObjectWithTag ("MainCamera");

		this.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0, 0);

		updateHealthBar ();
	}

	//Evento que salta cuando es dañado 
	public void damaged(int damage){
		//Calcula el daño y en caso de morir pues muere
		HP -= damage;
		createDamagePopup (damage);

		if (HP < 0) {
			Destroy (this.gameObject);
			return;
		}

		//Actualiza la barra de vida
		updateHealthBar ();

	}

	private void createDamagePopup(int damage){
		GameObject temp = (GameObject)Instantiate (damagePopup);
		RectTransform tempRect = temp.GetComponent<RectTransform> ();
		temp.transform.SetParent(transform.FindChild("EnemyCanvas"));

		tempRect.transform.localPosition = damagePopup.transform.localPosition;
		tempRect.transform.localScale = damagePopup.transform.localScale;
		tempRect.transform.localRotation = damagePopup.transform.localRotation;

	//	temp.GetComponent<Animator> ().Play (0);

		Destroy (temp, 1);

	}


	//Actualiza la barra de vida para reflejar la vida restante tras ser dañado
	private void updateHealthBar(){
		float health = (float)HP / maxHP;
		print (health);
		healthBar.localScale = new Vector3(health,healthBar.localScale.y , healthBar.localScale.z);

	}

	//Cuando rota tiene que actualizarse la barra de vida para que mire a la camara
	public void turn(){
		//canvas.LookAt(canvas.position + m_Camera.transform.rotation * Vector3.back,m_Camera.transform.rotation * Vector3.up);

	}
}
