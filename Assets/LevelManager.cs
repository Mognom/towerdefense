using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	/*
	 * 0 -> nada 
	 * 1 -> arquero
	 * 2 -> ballesta
	 * 3 -> spikes
	 * 4 -> lava
	 * 5 -> mortero
	 * 
	 */
	private int selected;

	//Variables que dependen del nivel actual
	public int oroInicial;
	

	//Torres y sus respectivos precios
	public GameObject arqueros, ballesta, pinchos, lava, mortero;
	private int precioArqueros = 100, precioBallesta = 150, precioPinchos = 50, precioLava = 500, precioMortero = 150;

	private Text oroText, manaText;

	private string mMax = "/100";
	private int oro = 0, mana = 0;


	//Time speed control
	private bool paused, fastFoward;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = 300;

		//Puntero a los textos del HUD
		GameObject hud = GameObject.Find ("HUD");
		Text[] textos = hud.GetComponentsInChildren<Text> ();
		oroText = textos[0];
		manaText = textos [1];

		selected = 0;

		//Da el oro inicial
		oro = oroInicial;

		//Escribe los textos iniciales de recursos y comienza a añadir mana por tiempo
		oroText.text = oro.ToString();
		manaText.text = mana.ToString() + mMax;
		StartCoroutine (manaTemporal ());

		//Configura los flags de control de tiempo
		fastFoward = false;
		paused = false;
	}
	

	//Se ha hecho click en un bloque
	public bool interaccionBloque(Vector3 pos){
		
		bool res = false;
		//DETECTAR SI CONSTRUIR O NO
		switch (selected) {

		//Construir torre de arqueros
		case 1:
			if(oro < precioArqueros)
				break;
			restarOro(precioArqueros);
			Instantiate (arqueros, pos + new Vector3(0f,0.3f,0f) , arqueros.transform.rotation);
			selected = 0;
			res = true;
			break;
		
		case 2:
			print (oro +"vs " +precioBallesta);
			if(oro < precioBallesta)
				break;
			restarOro(precioBallesta);
			Instantiate (ballesta, pos + new Vector3(0f,0.3f,0f) , ballesta.transform.rotation);
			selected = 0;
			res = true;
			break;
		case 4:
			if(oro < precioLava)
				break;
			restarOro(precioLava);
			Instantiate (lava, pos + new Vector3(0f,0.3f,0f) , lava.transform.rotation);
			selected = 0;
			res = true;
			break;
		case 5:
			if(oro < precioMortero)
				break;
			restarOro(precioMortero);
			Instantiate (mortero, pos + new Vector3(0f,0.3f,0f) , mortero.transform.rotation);
			selected = 0;
			res = true;
			break;
		
			//No se que me ha llegado -> ignore
		default: break;
		}
		
		return res;
	}

	//Se ha hecho click en un path
	public bool interaccionPath(Vector3 pos){

		if (selected == 3) {
			if(oro < precioPinchos)
				return false;
			restarOro(precioPinchos);
			Instantiate (pinchos, pos + new Vector3 (0f, 0.0f, 0f), pinchos.transform.rotation);
			selected = 0;
			return true;
		}
		return false;
	}

	public void setSelected(int id){
		print (oro + "orooooooasdas");
		selected = id;
	}

	//Modificacion del oro
	public void sumarOro(int o){
		oro += o;
		oroText.text = oro.ToString ();
	}
	public void restarOro(int o){
		print ("resta por algun motivo");
		oro -= o;
		oroText.text = oro.ToString ();
	}


	//Modificacion del mana
	public void sumarMana(int m){
		if (mana < 100) {
			mana += m;
			manaText.text = mana.ToString () + mMax;
		}
	}
	public void restarMana(int m){
		if (mana > 0) {
			mana -= m;
			manaText.text = this.mana.ToString () + mMax;
		}
	}
	IEnumerator manaTemporal (){
		while (true) {
			yield return new WaitForSeconds (1);
			sumarMana (1);
		}
	}

	//Control sobre la velocidad actual
	public void toggleFastFoward(){
		fastFoward = !fastFoward;

		//Si esta pausado solo cambia la configuracion, sin afectar a la velocidad hasta quitar el pause
		if (!paused)
			return;
		if(!fastFoward)
			Time.timeScale = 1f;
		else
			Time.timeScale = 2f;
	}
	//Control sobre el pause
	public void togglePause(){
		paused = !paused;
		if (paused)
			Time.timeScale = 0f;
		//Al quitar el pause vuelve a la velocidad que hay seleccionada
		else {
			if (fastFoward)
				Time.timeScale = 2f;
			else
				Time.timeScale = 1f;
		}
	}

}
