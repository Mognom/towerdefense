using UnityEngine;
using System.Collections;
using System;

public class SpawnManager : MonoBehaviour {

	public GameObject minionN;
	public GameObject minionR;
	public GameObject minionG;
	public float spawnWait = 2, startWait = 1, waveWait = 4;
	public int totMinions, totMN = 2, totMR = 1, totMG = 0;


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnWaves () {
		System.Random rnd = new System.Random();
		//double[] valoresSpawn = {0.5, 0.3, 0.2};
		yield return new WaitForSeconds(startWait);
		while (true) {
			totMinions = totMG + totMN + totMR;
			//var Spawn = generatePattern(valoresSpawn, totMinions);
			for (int i = 0; i < totMinions; i++){
				Vector3 spawnPosition = new Vector3 (4, 0.3f, 10);
				switch(rnd.Next(10)){
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
				yield return new WaitForSeconds(spawnWait);
			}
			totMG = totMG + 2;
			totMN = totMN * 4;
			totMR = totMR * 2;
			yield return new WaitForSeconds(waveWait);
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
