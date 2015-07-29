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
	public Text texto;
	private float spawnWait = 0.25f;
	private int totMN = 3, totMR = 1, totMG = 0, minionsVivos, minionsSpawneables = 1, wave = 0;
	private bool noWave = true, startWave = false;
	private int[] patronMinions;
	private Vector3 spawnPosition;

	// Use this for initialization
	void Start ()
	{
		texto.text = "Pulsa G para spawnear una nueva oleada";
		texto.enabled = true;
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
		print ("He entrado en la corrutina");

		while (true) {
			if (startWave && noWave) {
				print ("Spawneando");
				noWave = false;
				patronMinions = prepararWave ();
				StartCoroutine (cuentaAtras (10));
				yield return new WaitForSeconds (10); //Espera a que se ejecute la corrutina de cuenta atras
				for (int i = 0; i < patronMinions.Length; i++) {
					switch (patronMinions [i]) {
					case 0:
						Instantiate (minionN, spawnPosition, minionN.transform.rotation);
						print ("Normal");
						break;
					case 1:
						Instantiate (minionR, spawnPosition, minionR.transform.rotation);
						print ("Rapido");
						break;
					case 2:
						Instantiate (minionG, spawnPosition, minionG.transform.rotation);
						print ("Gordo");
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
		yield break;
	}

	void finWave ()
	{
		if (minionsVivos == 0 && minionsSpawneables == 0) {
			noWave = true;
			print (noWave);
			startWave = false;
			print (startWave);
			texto.text = "Pulsa G para spawnear una nueva oleada";
			texto.enabled = true;
			totMN = totMN * 3;
			totMR = totMR + wave * 3;
			totMG = totMG + 2;
		}
	}

	int[] prepararWave ()
	{
		print ("Preparando oleada");
		texto.enabled = false;
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
		texto.enabled = true;
		for (int i = 0; i<veces; i++) {
			texto.text = (veces - i).ToString ();
			yield return new WaitForSeconds (1);
		}
		texto.enabled = false;
		yield return null;
	}
}