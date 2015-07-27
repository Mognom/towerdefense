using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

	public GameObject minionN;
	public GameObject minionR;
	public GameObject minionG;

	public Text texto;

	public float spawnWait = 2, startWait = 1, waveWait = 4;
	public int totMinions, totMN = 2, totMR = 1, totMG = 0;
	public bool noWave = true;


	// Use this for initialization
	void Start () {
		texto.text = "Pulsa G para spawnear una nueva oleada";
		texto.enabled = true;
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
		//GUIText tC = GameObject.FindWithTag("WText").GetComponent<GUIText>() as GUIText;
				if (noWave) {
					texto.enabled = true;
		
				}
				else
					texto.enabled = false;

	}

	void onGUI(){

	}

	IEnumerator SpawnWaves () {

				System.Random rnd = new System.Random ();
				//double[] valoresSpawn = {0.5, 0.3, 0.2};
			yield return new WaitForSeconds (startWait);
			noWave = false;
		while (true) {
			totMinions = totMG + totMN + totMR;
				//var Spawn = generatePattern(valoresSpawn, totMinions);
				for (int i = 0; i < totMinions; i++) {
					Vector3 spawnPosition = new Vector3 (4, 0.3f, 10);
					switch (rnd.Next (10)) {
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						Instantiate (minionN, spawnPosition, minionN.transform.rotation);
						break;
					case 6:
					case 7:
					case 8:
						Instantiate (minionR, spawnPosition, minionN.transform.rotation);
						break;
					case 9:
					case 10:
						Instantiate (minionG, spawnPosition, minionN.transform.rotation);
						break;
					default:
						break;
					}
					yield return new WaitForSeconds (spawnWait);
				}
				totMG = totMG + 2;
				totMN = totMN * 4;
				totMR = totMR * 2;
				noWave = true;
				yield return new WaitForSeconds (waveWait);
			noWave = false;


			}
		}


	/*int[] generatePattern(double[] ratios, int length) { //He gitaneado la funcion, vale? NAZIS
		int[] pattern = new int[length];
		for (int i=0; i < ratios.Length; i++) {
			double ratio = ratios[i];
			double step = 1 / ratio;
			for (double j=0; j < length; j+=step) {
				int ind = (int) Math.Floor(j);
				while (pattern[ind] > -1.0) 
					ind++;
				pattern[ind] = i; // element for which the ratio stands
			}
		}
		return pattern;
	}*/
}
