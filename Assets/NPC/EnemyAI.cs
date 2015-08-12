using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//Stats del enemigo
	public int speed;
	public int maxHP = 10;
	public int oro = 10;


	public GameObject popUpPrefab;
	public GameObject cadaver;

	private LevelManager levelManager;

	private int HP;
	private Transform healthBar;
	private Transform canvas;

	//Se llama una unica vez, "cachea" todas las busquedas necesarias para no tener que hacerlas nunca mais
	void Awake () {
		canvas = transform.transform.FindChild ("HealthBarCanvas");
		healthBar = transform.FindChild ("HealthBarCanvas/HealthBar");
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
	}

	//Configura el NPC para su vida actual :S
	void OnEnable(){
		//Start moving
		this.GetComponent<Rigidbody> ().velocity = new Vector3 (speed, 0, 0);
		HP = maxHP;
		canvas.gameObject.SetActive(false);
	}

	//Evento que salta cuando es dañado git
	public void damaged(int damage){
		//Si recibe daño teniendo la vida al maximo activa la barra de vida (solo sucede una vez)
		if (HP == maxHP)
			transform.transform.FindChild ("HealthBarCanvas").gameObject.SetActive (true);

		//Calcula el daño y en caso de morir pues muere
		HP -= damage;
		createPopup (damage.ToString(), Color.red, 100);

		//sa muerto -> Oro y muerte
		if (HP <= 0) {
			createPopup("+10g", Color.yellow, 130, true);
			this.gameObject.recycle();
			levelManager.sumarOro(oro);
			cadaver.spawn( this.gameObject.transform.position ,this.gameObject.transform.rotation);
			return;
		}

		//Actualiza la barra de vida
		updateHealthBar ();

	}

	//Creates a popUp text that despawns after a second
	private void createPopup(string valor, Color col, int size = 100, bool gold = false){
		GameObject temp = popUpPrefab.spawn(transform.position, Quaternion.identity);
		Text texto = temp.GetComponentInChildren<Text> ();

		//Configura el popup
		texto.color = col;
		texto.text = valor;
		texto.fontSize = size;


		//Elige la animacion a reproducir en funcion de si era para oro o no
		if (gold) {
			texto.GetComponent<Animator> ().SetTrigger ("gold");
		}
		else
			texto.GetComponent<Animator> ().SetTrigger("damage");
	}


	//Actualiza la barra de vida para reflejar la vida restante tras ser dañado
	private void updateHealthBar(){
		float health = (float)HP / maxHP;
		healthBar.localScale = new Vector3(health,healthBar.localScale.y , healthBar.localScale.z);
	}

	//Cuando rota tiene que actualizarse la barra de vida para que mire a la camara
	public void turn(){
		//canvas.LookAt(canvas.position + m_Camera.transform.rotation * Vector3.back,m_Camera.transform.rotation * Vector3.up);

	}
}
