using UnityEngine;
using System.Collections;



/*
 * Genera el mapa a partir de un matriz de ids que representan los tipos de bloques que componen el nivel
 * 
 * IDS:
 * 
 * 0 = SUELO
 * 1 = CAMINO
 * 
 */
public class mapGen : MonoBehaviour {

	private int[,] map = {{0,0,0,0},
						  {0,0,1,0},
						  {0,0,1,0},
						  {0,1,1,0},
						  {0,0,0,0}};
	public GameObject suelo;
	public GameObject path;

	//Genera el mapa nada mas empezar
	void Start () {
		GameObject actual;

		//Recorre el mapa a usar
		for (int z = 0; z < map.GetLength(0); z++)
			for (int x = 0; x< map.GetLength(1); x++) 

				//Crea los objetos en funcion del id de la casilla. 
				//La Z posiciones del gameObject creado es invertida y las x y z intercambiadas para que se corresponda a la matriz
				switch(map[z,x]){
					//Suelo normal
					case 0:
						actual = (GameObject) Instantiate (suelo,new Vector3(x,0,map.GetLength(0)-z -1),suelo.transform.rotation);
						actual.name = suelo.name; //Odio el (clone) =3
						break;

					//Camino enemigos
					case 1:
						actual = (GameObject) Instantiate (path,new Vector3(x,0,map.GetLength(0)-z -1),path.transform.rotation);
						actual.name = path.name; //Odio el (clone) =3
						break;
					
					//Whateva is this s***
					default: break;

				}

	}
}
