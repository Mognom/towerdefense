using UnityEngine;
using System.Collections;



/*
 * Genera el mapa a partir de un matriz de ids que representan los tipos de bloques que componen el nivel
 * 
 * IDS:
 * 
 * 0 = BLOQUE BASE
 * 1 = PATH
 * 2 = BLOQUE BLOQUEADO
 * 3 = BORDE VERTICAL
 * 4 = BORDE HORIZONTAL
 * 5 = BORDE EXTERIOR
 * 6 = BORDE INTERIOR
 * 
 */
public class mapGen : MonoBehaviour {

	//Definicion del mapa
	private int[,] map = {{0,5,4,5},
						  {0,3,1,3},
						  {5,6,1,3},
						  {3,1,1,3},
						  {5,4,4,5}};

	//Bloques del mapa
	public GameObject block, bloquedBlock;
	public GameObject path;
	public GameObject border, interiorBorder, exteriorBorder;

	//Genera el mapa nada mas empezar
	void Start () {
		GameObject actual;
		Quaternion rotation;
		//Recorre el mapa a usar
		for (int z = 0; z < map.GetLength(0); z++)
			for (int x = 0; x< map.GetLength(1); x++) 

				//Crea los objetos en funcion del id de la casilla. 
				//La Z posiciones del gameObject creado es invertida y las x y z intercambiadas para que se corresponda a la matriz
				switch(map[z,x]){
					//Bloque base
					case 0:
						actual = (GameObject) Instantiate (block,new Vector3(x,0,map.GetLength(0)-z -1),block.transform.rotation);
						actual.name = block.name; //Odio el (clone) =3
						break;

					//Camino enemigos
					case 1:
						actual = (GameObject) Instantiate (path,new Vector3(x,0,map.GetLength(0)-z -1),path.transform.rotation);
						actual.name = path.name; //Odio el (clone) =3
						break;
						
					//Bloque bloqueado
					case 2:
						actual = (GameObject) Instantiate (bloquedBlock, new Vector3(x,0,map.GetLength(0)-z -1), bloquedBlock.transform.rotation);
						actual.name = bloquedBlock.name; //Odio el (clone) =3
						break;
	
					//Borde vertical
					case 3:
						actual = (GameObject) Instantiate (border,new Vector3(x,0,map.GetLength(0)-z -1),border.transform.rotation);
						actual.name = border.name; //Odio el (clone) =3
						break;
					
					//Borde horizontal
					case 4:
						rotation = border.transform.rotation;
						rotation.eulerAngles.Set(0,90,0);
						actual = (GameObject) Instantiate (border,new Vector3(x,0,map.GetLength(0)-z -1), rotation);
						actual.name = border.name; //Odio el (clone) =3
						break;
				
					//Borde exterior
					case 5:
						actual = (GameObject) Instantiate (exteriorBorder,new Vector3(x,0,map.GetLength(0)-z -1),exteriorBorder.transform.rotation);
						actual.name = exteriorBorder.name; //Odio el (clone) =3
						break;
					
					//Bordo interior
					case 6:
						actual = (GameObject) Instantiate (interiorBorder,new Vector3(x,0,map.GetLength(0)-z -1),interiorBorder.transform.rotation);
						actual.name = interiorBorder.name; //Odio el (clone) =3
						break;




					//Whateva is this s***
					default: break;

				}

	}
}
