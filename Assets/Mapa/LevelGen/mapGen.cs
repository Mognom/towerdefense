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
 * 3 = BORDE VERTICAL *2
 * 4 = BORDE HORIZONTAL *2
 * 5 = BORDE EXTERIOR *4
 * 6 = BORDE INTERIOR *4
 * 7 = esquina 90
 * 8 = ESQUINA -90
 * 
 */
public class mapGen : MonoBehaviour {

	//Definicion del mapa
	private int[,] map = {{5,3,3,3,3,5},
						  {3,7,1,1,7,3},
						  {3,1,6,6,1,0},
						  {3,1,6,6,1,0},
						  {3,7,1,1,7,3},
						  {5,3,3,3,3,5}}; 

						/*{{0,5,4,5},
						  {0,3,1,3},
						  {5,6,1,3},
						  {3,1,1,3},
						  {5,4,4,5}};*/

	//Bloques del mapa
	public GameObject block, bloquedBlock;
	public GameObject path, corner;
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
						actual = (GameObject) Instantiate (block,new Vector3(x,0,map.GetLength(0)-z -1)*2,block.transform.rotation);
						actual.name = block.name; //Odio el (clone) =3
						break;

					//Camino enemigos
					case 1:
						actual = (GameObject) Instantiate (path,new Vector3(x,0,map.GetLength(0)-z -1)*2,path.transform.rotation);
						actual.name = path.name; //Odio el (clone) =3
						break;
						
					//Bloque bloqueado
					case 2:
						actual = (GameObject) Instantiate (bloquedBlock, new Vector3(x,0,map.GetLength(0)-z -1)*2 , bloquedBlock.transform.rotation);
						actual.name = bloquedBlock.name; //Odio el (clone) =3
						break;

					//Borde
					case 3:
						rotation = border.transform.rotation;
						if(x+1 < map.GetLength(1) && (map[z,x+1] == 1 || map[z,x+1] == 7 || map[z,x+1] == 8))
							rotation = Quaternion.Euler(-90,-90,0);
						else
							if(x-1 > 0 && (map[z,x-1] == 1 || map[z,x-1] == 7 || map[z,x-1] == 8))
								rotation = Quaternion.Euler(-90,90,0);
							else
								if(z+1 < map.GetLength(0) && (map[z+1,x] == 1 || map[z+1,x] == 7 || map[z+1,x] == 8))
									rotation = Quaternion.Euler(-90,0,0);
								else
									rotation = Quaternion.Euler(-90,180,0);
						
						actual = (GameObject) Instantiate (border,new Vector3(x,0,map.GetLength(0)-z -1) *2 ,rotation);
						actual.name = border.name; //Odio el (clone) =3
						break;
				
					//Borde exterior
					case 5:
						rotation = border.transform.rotation;
						//Esquina derecha arriba
						if(x+1 < map.GetLength(1) && z+1 < map.GetLength(0) && (map[z+1,x+1] == 1 || map[z+1,x+1] == 7 || map[z+1,x+1] == 8))
							rotation = Quaternion.Euler(-90,270,0);
						
						//Esquina derecha abajo
						else if(x+1 < map.GetLength(1) && z-1 > 0 && (map[z-1,x+1] == 1 || map[z-1,x+1] == 7 || map[z-1,x+1] == 8))
							rotation = Quaternion.Euler(-90,180,0);
						
						//Esquina izquierda arriba
						else if(x-1 > 0 && z+1 < map.GetLength(0) && (map[z+1,x-1] == 1 || map[z+1,x-1] == 7 || map[z+1,x-1] == 8))
							rotation = Quaternion.Euler(-90,0,0);
						
						//Esquina izquierda abajo
						else if(x-1 > 0 && z-1 > 0 && (map[z-1,x-1] == 1 || map[z-1,x-1] == 7 || map[z-1,x-1] == 8))
							rotation = Quaternion.Euler(-90,90,0);
						
						actual = (GameObject) Instantiate (exteriorBorder,new Vector3(x,0,map.GetLength(0)-z -1)*2 ,rotation);
						actual.name = exteriorBorder.name; //Odio el (clone) =3
						break;
					
					
					//Borde interior
					case 6:
						rotation = border.transform.rotation;
						//Esquina derecha arriba
						if(x+1 < map.GetLength(1) && z+1 < map.GetLength(0) && (map[z+1,x] == 1 || map[z+1,x] == 7 || map[z+1,x] == 8) && (map[z,x+1] == 1 || map[z,x+1] == 7 || map[z,x+1] == 8))
							rotation = Quaternion.Euler(-90,0,0);
						
						//Esquina derecha abajo
						else if(x+1 < map.GetLength(1) && z-1 > 0 && (map[z-1,x] == 1 || map[z-1,x] == 7 || map[z-1,x] == 8) && (map[z,x+1] == 1 || map[z,x+1] == 7 || map[z,x+1] == 8))
							rotation = Quaternion.Euler(-90,270,0);
						
						//Esquina izquierda arriba
						else if(x-1 > 0 && z+1 < map.GetLength(0) && (map[z+1,x] == 1 || map[z+1,x] == 7 || map[z+1,x] == 8) && (map[z,x-1] == 1 || map[z+1,x] == 7 || map[z+1,x] == 8))
							rotation = Quaternion.Euler(-90,90,0);
						
						//Esquina izquierda abajo
						else if(x-1 > 0 && z-1 > 0 && (map[z-1,x] == 1 || map[z-1,x] == 7 || map[z-1,x] == 8) && (map[z,x-1] == 1 || map[z,x-1] == 7 || map[z,x-1] == 8))
							rotation = Quaternion.Euler(-90,180,0);
						
						
						actual = (GameObject) Instantiate (interiorBorder,new Vector3(x,0,map.GetLength(0)-z -1)*2, rotation);
						actual.name = interiorBorder.name; //Odio el (clone) =3
						break;
					
					//Esquina +90
					case 7:
						actual = (GameObject) Instantiate (corner,new Vector3(x,0,map.GetLength(0)-z -1)*2,corner.transform.rotation);
						actual.name = corner.name; //Odio el (clone) =3
						break;
					
					//Esquina -90
					case 8:
						actual = (GameObject) Instantiate (corner,new Vector3(x,0,map.GetLength(0)-z -1)*2,corner.transform.rotation);
						actual.name = corner.name; //Odio el (clone) =3
						break;
						




					//Whateva is this s***
					default: break;

				}

	}
}
