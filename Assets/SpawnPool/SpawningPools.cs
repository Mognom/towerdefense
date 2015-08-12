using UnityEngine;
using System.Collections.Generic;

public class SpawningPools : MonoBehaviour {


	private static bool inited;
	//El padre inicial de todas las instancias para facilitar su vista en el editor
	private static GameObject father;
	//Almacena las listas de instancias en un diccionario con clave el prefab
	private static Dictionary<GameObject, List<GameObject>> pools;

	//Almacena las instancias que estan siendo usadas con clave la instancia y valor el prefab(para poder almacenarlo de nuevo)
	private static Dictionary<GameObject,GameObject> activeObjects;	

	//Inicializa los diccionarios y crea el gameObject vacio que actuara como padre de las instancias
	public static void init(){

		pools = new Dictionary<GameObject, List<GameObject>> ();
		activeObjects = new Dictionary<GameObject, GameObject>();
		father = new GameObject ();
		father.name = "SpawnPool";
		inited = true;
	}

	/*
	 * Otorga una instancia del prefab pedido, y la coloca en la posicion y rotacion elegidas.
	 * En caso de no haber ninguna instancia libre crea una mas para la pool
	 * En caso de no haber ninguna pool del objeto crea una pool nueva
	 */
	public static GameObject spawn (GameObject prefab, Vector3 position, Quaternion rotation){
		//Si no ha sido inicializado prepara las pools
		if (!inited) {
			init ();
		}

		List<GameObject> prefabPool;
		GameObject result;
		//Si ya existia la pool previamente
		if (pools.ContainsKey (prefab)) {
			prefabPool = pools [prefab];
			//Hay objetos disponibles en la pool
			if (prefabPool.Count > 0) {
				//Obtiene el objeto y lo saca de la pool
				result = prefabPool [0];
				prefabPool.RemoveAt (0);

				result.SetActive (true);
				result.transform.position = position;
				result.transform.rotation = rotation;
			}
			//No hay objetos disponibles en la pool
			else {
				result = (GameObject) Instantiate (prefab, position, rotation);
				result.transform.SetParent(father.transform);
			}
		}
		//No existe la pool -> la crea
		else {
			pools.Add(prefab, new List<GameObject>());
			result = (GameObject) Instantiate ((Object)prefab, position, rotation);
			result.transform.SetParent(father.transform);
		}
		activeObjects.Add(result, prefab);
		return result;
	}


	//Desactiva el objeto para que este disponible en la pool de nuevo.
	public static void recycle (GameObject gObject){
		GameObject key;

		//Si ya existia la pool
		if (activeObjects.ContainsKey (gObject)) {

			gObject.SetActive (false);
			gObject.transform.SetParent (father.transform);

			key = activeObjects [gObject];
			pools [key].Add (gObject);
			activeObjects.Remove (gObject);
		} else
			Destroy (gObject);
	}
}

//SUGAAAAAAAAAAAAR
public static class SpawnPoolExtensions{

	//SPAWN EXTENSIONS
	public static GameObject spawn(this GameObject prefab, Vector3 position, Quaternion rotation){
		return SpawningPools.spawn(prefab, position, rotation);
	}

	public static GameObject spawn(this GameObject prefab, Vector3 position){
		return SpawningPools.spawn(prefab, position, prefab.transform.rotation);
	}

	public static GameObject spawn(this GameObject prefab){
		return SpawningPools.spawn(prefab, prefab.transform.position, prefab.transform.rotation);
	}

	public static GameObject spawn(this GameObject prefab, Quaternion rotation){
		return SpawningPools.spawn(prefab, prefab.transform.position, rotation);
	}

	//RECYCLE EXTENSIONS

	public static void recycle(this GameObject gObject){
		SpawningPools.recycle (gObject);

	}
}