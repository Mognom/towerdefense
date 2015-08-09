using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*IDs
 * 0 = Mininos Normales
 * 1 = Minions Rapidos
 * 2 = Minions Gordos
 */

public class SpawnManager : MonoBehaviour
{

	public GameObject minionN;
	public GameObject minionR;
	public GameObject minionG;

	private Text waveText;

	private XMLReader xml;
	private float spawnWait = 0.25f;
	private int minionsVivos, minionsSpawneables = 1;
	private int totMN = 3, totMR = 1, totMG = 0, wave = 0;
	private bool noWave = true, startWave = false;
	private int[] patronMinions;
	private Vector3 spawnPosition;

	// Use this for initialization
	void Start ()
	{
		//CACHEEE FTW
		waveText = GameObject.Find("HUD").GetComponentsInChildren<Text>()[2];
		xml = this.GetComponentInChildren<XMLReader> ();


		print (minionsVivos);
		print (minionsSpawneables);
		StartCoroutine ("SpawnWaves");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.G)) {
			startWave = true;
			print ("Pulsado G");
		}

	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (0.1f);
		waveText.text = xml.getNuevaOleada();
		waveText.enabled = true;
		print ("He entrado en la corrutina");
		patronMinions = prepararWave ();
		while (true) {
			if (startWave && noWave) {
				print ("Spawneando");
				noWave = false;

				StartCoroutine (cuentaAtras (5));
				yield return new WaitForSeconds (5); //Espera a que se ejecute la corrutina de cuenta atras
				for (int i = 0; i < patronMinions.Length; i++) {
					switch (patronMinions [i]) {
					case 0:
						minionN.spawn (spawnPosition);
						print ("Normal");
						break;
					case 1:
						minionR.spawn (spawnPosition);
						print ("Rapido");
						break;
					case 2:
						minionG.spawn(spawnPosition);
						print ("Gordo");
						break;
					case 3:
						print ("Tiempo");
						yield return new WaitForSeconds(2f);
						minionsVivos--;
						minionsSpawneables++;
						break;
					default:
						print ("ID del minion no valida");
						minionsVivos--;
						minionsSpawneables++;
						break; //Si meten una ID mala se incrementan las variables para que al salir del switch queden como estaban
					}
					minionsVivos++;
					minionsSpawneables--;
					yield return new WaitForSeconds (spawnWait);
				}

			}
			finWave ();
			yield return null;
		}
//		yield break;
	}

	void finWave ()
	{
		if (minionsVivos == 0 && minionsSpawneables == 0) {
			noWave = true;
			print (noWave);
			startWave = false;
			print (startWave);
			waveText.text = xml.getNuevaOleada();
			waveText.enabled = true;
			totMN = totMN * 3;
			totMR = totMR + wave * 3;
			totMG = totMG + 2;
			patronMinions = prepararWave ();
		}
	}

	int[] prepararWave ()
	{
		print ("Preparando oleada");
//		texto.enabled = false;
		spawnPosition = spawnPositionSelect ();
		wave++;
		int i;
		minionsSpawneables = totMN + totMR + totMG;
		List<int> premade = new List<int> ();
		for (i = 0; i < totMN; i++)
			premade.Add (0);
		for (i = 0; i < totMR; i++)
			premade.Add (1);
		for (i = 0; i < totMG; i++)
			premade.Add (2);
		for (i = 0; i < minionsSpawneables/6 - 1; i++)
			premade.Add (3);
		return premade.OrderBy (n => Guid.NewGuid ()).ToArray ();
	}

	public void saMorio ()
	{
		minionsVivos--;
	}

	public void saMorio (int ID)
	{
		/*switch (ID) {
		case 0:
			minionN--;
			break;
		case 1:
			minionR--;
			break;
		case 2:
			minionG--;
			break;
		default:
			break;
		}*/
		minionsVivos--;
	}

	Vector3 spawnPositionSelect ()
	{
		return new Vector3 (4, 0.3f, 10);
	}

	IEnumerator cuentaAtras (int veces)
	{
		waveText.enabled = true;
		for (int i = 0; i<veces; i++) {
			waveText.text = (veces - i).ToString ();
			yield return new WaitForSeconds (1);
		}
		waveText.enabled = false;
		yield return null;
	}
}
