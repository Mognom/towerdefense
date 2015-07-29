using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	/*
	 * 0 -> nada 
	 * 1 -> arquero
	 * ...
	 * 
	 */
	private int selected;
	public GameObject arqueros, ballesta, pinchos, lava, mortero;
	public Text Oro, Mana;
	private string mMax = "/100";
	private int o = 0, m = 0;
	
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = 300;
		selected = 0;
		Oro.text = o.ToString();
		Mana.text = m.ToString() + mMax;
		StartCoroutine (manaTemporal ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sumarOro(int o){
		this.o += o;
		Oro.text = this.o.ToString ();
	}

	public void sumarMana(int m){
		if (this.m < 100) {
			this.m += m;
			Mana.text = this.m.ToString () + mMax;
		}
	}

	public void restarMana(int m){
		if (this.m > 0) {
			this.m -= m;
			Mana.text = this.m.ToString () + mMax;
		}
	}

	IEnumerator manaTemporal (){
		while (true) {
			yield return new WaitForSeconds (1);
			sumarMana (1);
		}
	}

	public bool interaccionBloque(Vector3 pos){
		
		bool res = false;
		//DETECTAR SI CONSTRUIR O NO
		switch (selected) {

		//Construir torre de arqueros
		case 1:
			Instantiate (arqueros, pos + new Vector3(0f,0.3f,0f) , arqueros.transform.rotation);
			selected = 0;
			res = true;
			break;
		
		case 2:
			Instantiate (ballesta, pos + new Vector3(0f,0.3f,0f) , ballesta.transform.rotation);
			selected = 0;
			res = true;
			break;
		case 4:
			Instantiate (lava, pos + new Vector3(0f,0.3f,0f) , lava.transform.rotation);
			selected = 0;
			res = true;
			break;
		case 5:
			Instantiate (mortero, pos + new Vector3(0f,0.3f,0f) , mortero.transform.rotation);
			selected = 0;
			res = true;
			break;
		
			//No se que me ha llegado -> ignore
		default: break;
		}
		
		return res;
		
		
	}

	public void setSelected(int id){
		selected = id;
	}
}
